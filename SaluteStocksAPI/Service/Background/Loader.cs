using Microsoft.EntityFrameworkCore;
using SaluteStocksAPI.AlphaVantage;
using SaluteStocksAPI.AlphaVantage.Exceptions;
using SaluteStocksAPI.DataBase;
using SaluteStocksAPI.Models.FundamentalData;
using Serilog;

namespace SaluteStocksAPI.Service.Background;

public class Loader : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    private readonly LoaderSettings _settings;
    private AlphaVantageClient Client => AlphaVantageClientFactory.Create();

    private readonly Dictionary<Type, int> Types = new Dictionary<Type, int>
    {
        { typeof(BalanceSheet), 0 },
        { typeof(CashFlow), 1 },
        { typeof(CompanyOverview), 2 },
        { typeof(Earnings), 3 },
        { typeof(IncomeStatement), 4 },
    };

    public Loader(LoaderSettings settings, IServiceScopeFactory scopeFactory)
    {
        _settings = settings;
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            using var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<StocksContext>();
            var repository = new DataBaseRepository(db);
            try
            {
                await repository.SetListing(await Client.GetListing());
            }
            catch (Exception e)
            {
                Log.Error(e, "Failed to update listing");
            }


            await LoadMissingData(stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                await using (db = scope.ServiceProvider.GetRequiredService<StocksContext>())
                {
                    repository = new DataBaseRepository(db);


                    Task[] tasks =
                    {
                    RefreshEntity<BalanceSheet>(await repository.GetOldestSymbol<BalanceSheet>()),
                    RefreshEntity<CashFlow>(await repository.GetOldestSymbol<CashFlow>()),
                    RefreshEntity<CompanyOverview>(await repository.GetOldestSymbol<CompanyOverview>()),
                    RefreshEntity<Earnings>(await repository.GetOldestSymbol<Earnings>()),
                    RefreshEntity<IncomeStatement>(await repository.GetOldestSymbol<IncomeStatement>()),
                };
                    Log.Information("Waiting for the completion of tasks to refresh oldest entities.");
                    try
                    {
                        Task.WaitAll(tasks);
                    }
                    catch (Exception e)
                    {
                        Log.Error(e, "Error occured in some tasks.");
                    }

                    Log.Information("All entities are refreshed! Success: {Success}. Fail: {Fail}",
                        tasks.Count(x => x.IsCompletedSuccessfully),
                        tasks.Count(x => !x.IsCompletedSuccessfully));
                }

                Log.Information("Delay before refresh oldest entities {Delay}", _settings.CheckUpdateTime);
                await Task.Delay(_settings.CheckUpdateTime, stoppingToken);
            }
        }
        catch(Exception e)
        {
            Log.Fatal(e, "Error in background service.");
            throw;
        }   
    }

    private async Task LoadMissingData(CancellationToken stoppingToken)
    {
        Log.Information("Loading missing data.");
        
        
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                await using var db = scope.ServiceProvider.GetRequiredService<StocksContext>();
                var repository = new DataBaseRepository(db);
                var symbols = await db.Listing.Select(e => e.Symbol).ToListAsync(cancellationToken: stoppingToken);

                var tasks = new[]
                {
                    LoadMissingEntities<BalanceSheet>(),
                    LoadMissingEntities<CashFlow>(),
                    LoadMissingEntities<CompanyOverview>(),
                    LoadMissingEntities<Earnings>(),
                    LoadMissingEntities<IncomeStatement>(),
                };
                    
                try
                {
                    Task.WaitAll(tasks);
                }
                catch (Exception e)
                {
                    Log.Error(e,"Error occured in some tasks.");
                }
                async Task LoadMissingEntities<T>() where T : EntityInfo
                {
                    try
                    {
                        using var localScope = _scopeFactory.CreateScope();
                        await using var localdb = localScope.ServiceProvider.GetRequiredService<StocksContext>();
                        Log.Information("Loading missing entities for {Type}", typeof(T));
                        Log.Information("Getting already loaded entities");
                        var loadedSymbols = await localdb.Set<T>().Where(x=>x.ExistInApi.HasValue).Select(x => x.Symbol).Distinct()
                            .ToListAsync(cancellationToken: stoppingToken);
                        Log.Information("Already loaded: {Total}", loadedSymbols.Count);

                        foreach (var symbol in symbols.Where(s => !loadedSymbols.Contains(s)))
                        {
                            try
                            {
                                await RefreshEntity<T>(symbol);
                            }
                            catch
                            {
                                // ignored
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Log.Error(e, "Failed to load missing entities for {Type}", typeof(T));
                    }
                }
            }
            catch (Exception e)
            {
                Log.Warning(e, "Unexpected error while loading missing entities");
            }
            finally
            {
                await Task.Delay(_settings.LoadMissingDataDelay, stoppingToken);
            }
        }
    }

    private async Task RefreshEntity<T>(string symbol) where T : EntityInfo
    {
        using var localScope = _scopeFactory.CreateScope();
        await using var localdb = localScope.ServiceProvider.GetRequiredService<StocksContext>();
        var repository = new DataBaseRepository(localdb);
        if (symbol is null)
            return;
        Log.Information("Trying to refresh entity {EntityType} with Symbol {Symbol}", typeof(T), symbol);
        try
        {
            EntityInfo entity = Types[typeof(T)] switch
            {
                0 => await Client.GetBalanceSheet(symbol),
                1 => await Client.GetCashFlow(symbol),
                2 => await Client.GetCompanyOverview(symbol),
                3 => await Client.GetCompanyEarnings(symbol),
                4 => await Client.GetIncomeStatement(symbol),
                _ => throw new ArgumentOutOfRangeException()
            };
            entity.ExistInApi = true;

            if (Types[typeof(T)] != 2)
            {
                var companyOverview = ((CompanyEntityInfo)entity).CompanyOverview =
                    await repository.Get<CompanyOverview>(symbol);
                if (companyOverview == null)
                {
                    companyOverview = await Client.GetCompanyOverview(symbol) ??
                                      throw new NullReferenceException("Company Overview can't be null");
                    await repository.AddOrUpdate(companyOverview);
                }

            }

            entity.LastLocalRefresh = DateTime.Now;
            await repository.AddOrUpdate((T)entity);
        }
        catch (AlphaVantageEmptyResponse e)
        {
            if (Types[typeof(T)] != 2)
            {
                CompanyEntityInfo entity = Activator.CreateInstance<T>() as CompanyEntityInfo;
                entity.Symbol = symbol;
                entity.ExistInApi = false;
                entity.LastLocalRefresh = DateTime.Now;
                var companyOverview = entity.CompanyOverview =
                    await repository.Get<CompanyOverview>(symbol);
                if (companyOverview == null)
                {
                    try
                    {
                        companyOverview = await Client.GetCompanyOverview(symbol) ?? throw new InvalidOperationException();
                        entity.CompanyOverview = companyOverview;
                        await repository.AddOrUpdate(companyOverview);
                    }
                    catch (AlphaVantageEmptyResponse)
                    {
                        companyOverview = new CompanyOverview()
                            { Symbol = symbol, ExistInApi = false, LastLocalRefresh = DateTime.Now };
                        entity.CompanyOverview = companyOverview;
                        await repository.AddOrUpdate(companyOverview);
                    }
                }
                await repository.AddOrUpdate(entity as T);
            }
            else
            {
                await repository.AddOrUpdate(new CompanyOverview()
                    { Symbol = symbol, ExistInApi = false, LastLocalRefresh = DateTime.Now });
            }

            
            
            Log.Warning(e, "Alpha Vantage has no {T} for symbol {Symbol}", typeof(T), symbol);
        }
        catch (AlphaVantageRequestLimit e)
        {
            Log.Warning(e, "Reached the API limit when getting {T} for symbol {Symbol}", typeof(T), symbol);
        }
        catch (Exception e)
        {
            Log.Error(e, "Failed to refresh  entity {EntityType} with Symbol {Symbol}", typeof(T), symbol);
            throw;
        }
        finally
        {
            await Task.Delay(_settings.CheckUpdateTime);
        }
    }
}

public class LoaderSettings
{
    public TimeSpan CheckUpdateTime = TimeSpan.FromSeconds(2);
    public TimeSpan LoadMissingDataDelay = TimeSpan.FromHours(6);
}