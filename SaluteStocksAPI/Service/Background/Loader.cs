using Microsoft.EntityFrameworkCore;
using SaluteStocksAPI.AlphaVantage;
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


        LoadMissingData(stoppingToken);

        while (!stoppingToken.IsCancellationRequested)
        {
            await using (db = scope.ServiceProvider.GetRequiredService<StocksContext>())
            {
                repository = new DataBaseRepository(db);

                
                Task[] tasks =
                {
                    RefreshEntity<BalanceSheet>(await repository.GetOldestSymbol<BalanceSheet>(), repository),
                    RefreshEntity<CashFlow>(await repository.GetOldestSymbol<CashFlow>(), repository),
                    RefreshEntity<CompanyOverview>(await repository.GetOldestSymbol<CompanyOverview>(), repository),
                    RefreshEntity<Earnings>(await repository.GetOldestSymbol<Earnings>(), repository),
                    RefreshEntity<IncomeStatement>(await repository.GetOldestSymbol<IncomeStatement>(), repository),
                };
                Log.Information("Waiting for the completion of tasks to refresh oldest entities.");
                try
                {
                    Task.WaitAll(tasks);
                }
                catch (Exception e)
                {
                    Log.Error(e,"Error occured in some tasks.");
                }
                
                Log.Information("All entities are refreshed! Success: {Success}. Fail: {Fail}",
                    tasks.Count(x => x.IsCompletedSuccessfully),
                    tasks.Count(x=>!x.IsCompletedSuccessfully));
            }

            Log.Information("Delay before refresh oldest entities {Delay}", _settings.CheckUpdateTime);
            await Task.Delay(_settings.CheckUpdateTime, stoppingToken);
        }
    }

    private async void LoadMissingData(CancellationToken stoppingToken)
    {
        Log.Information("Loading missing data.");
        
        
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scopeFactory.CreateScope();
            await using (var db = scope.ServiceProvider.GetRequiredService<StocksContext>())
            {
                var repository = new DataBaseRepository(db);
                var symbols = await db.Listing.Select(e => e.Symbol).ToListAsync(cancellationToken: stoppingToken);

                await LoadMissingEntities<BalanceSheet>();
                await LoadMissingEntities<CashFlow>();
                await LoadMissingEntities<CompanyOverview>();
                await LoadMissingEntities<Earnings>();
                await LoadMissingEntities<IncomeStatement>();
                
                async Task LoadMissingEntities<T>() where T : EntityInfo
                {
                    try
                    {
                        Log.Information("Loading missing entities for {Type}", typeof(T));
                        Log.Information("Getting already loaded entities");
                        var loadedSymbols = await db.Set<T>().Select(x => x.Symbol).Distinct()
                            .ToListAsync(cancellationToken: stoppingToken);
                        Log.Information("Already loaded: {Total}", loadedSymbols.Count);
                    
                        foreach (var symbol in symbols.Where(s=> !loadedSymbols.Contains(s)))
                        {
                            try
                            {
                                await RefreshEntity<T>(symbol, repository);
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
            await Task.Delay(_settings.LoadMissingDataDelay, stoppingToken);
        }
    }

    private async Task RefreshEntity<T>(string symbol, DataBaseRepository repository) where T : EntityInfo
    {
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