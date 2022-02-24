using Microsoft.EntityFrameworkCore;
using SaluteStocksAPI.AlphaVantage;
using SaluteStocksAPI.DataBase;
using SaluteStocksAPI.Models.FundamentalData;

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
        
        await repository.SetListing(await Client.GetListing());
        
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

                await Task.WhenAll(tasks);
            }

            await Task.Delay(_settings.CheckUpdateTime, stoppingToken);
        }
    }

    private async void LoadMissingData(CancellationToken stoppingToken)
    {
        using var scope = _scopeFactory.CreateScope();
        
        while (!stoppingToken.IsCancellationRequested)
        {
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
                    var loadedSymbols = await db.Set<T>().Select(x => x.Symbol).Distinct()
                        .ToListAsync(cancellationToken: stoppingToken);
                    
                    foreach (var symbol in symbols.Where(s=> !loadedSymbols.Contains(s)))
                    {
                        await RefreshEntity<T>(symbol, repository);
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
        
        EntityInfo entity = Types[typeof(T)] switch
        {
            0 => await Client.GetBalanceSheet(symbol),
            1 => await Client.GetCashFlow(symbol),
            2 => await Client.GetCompanyOverview(symbol),
            3 => await Client.GetCompanyEarnings(symbol),
            4 => await Client.GetIncomeStatement(symbol),
            _ => throw new ArgumentOutOfRangeException()
        };
        
        entity.LastLocalRefresh = DateTime.Now;
        await repository.AddOrUpdate(entity);
        
        await Task.Delay(_settings.LoadMissingDataDelay);
    }
}

public class LoaderSettings
{
    public TimeSpan CheckUpdateTime = TimeSpan.FromSeconds(2);
    public TimeSpan LoadMissingDataDelay = TimeSpan.FromHours(6);
}