using System.Collections.Concurrent;
using SaluteStocksAPI.AlphaVantage;
using SaluteStocksAPI.DataBase;
using SaluteStocksAPI.Models.FundamentalData;

namespace SaluteStocksAPI.Service.Background;

public class Loader : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    private readonly LoaderSettings _settings;
    private AlphaVantageClient Client => AlphaVantageClientFactory.Create();
    private ConcurrentBag<string> SymbolList { get; set; }

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

        async Task RefreshEntity<T>() where T : EntityInfo
        {
            Dictionary<Type, int> typeDict = new Dictionary<Type, int>
            {
                { typeof(BalanceSheet), 0 },
                { typeof(CashFlow), 1 },
                { typeof(CompanyOverview), 2 },
                { typeof(Earnings), 3 },
                { typeof(IncomeStatement), 4 },
            };

            // ReSharper disable once AccessToModifiedClosure
            var symbol = await repository.GetOldestSymbol<T>();
            EntityInfo entity = typeDict[typeof(T)] switch
            {
                0 => await Client.GetBalanceSheet(symbol),
                1 => await Client.GetCashFlow(symbol),
                2 => await Client.GetCompanyOverview(symbol),
                3 => await Client.GetCompanyEarnings(symbol),
                4 => await Client.GetIncomeStatement(symbol),
                _ => throw new ArgumentOutOfRangeException()
            };

            entity.LastLocalRefresh = DateTime.Now;
            // ReSharper disable once AccessToModifiedClosure
            await repository.Set(entity);
        }

        await repository.SetListing(await Client.GetListing());

        while (!stoppingToken.IsCancellationRequested)
        {
            await using (db = scope.ServiceProvider.GetRequiredService<StocksContext>())
            {
                repository = new DataBaseRepository(db);

                Task[] tasks =
                {
                    RefreshEntity<BalanceSheet>(),
                    RefreshEntity<CashFlow>(),
                    RefreshEntity<CompanyOverview>(),
                    RefreshEntity<Earnings>(),
                    RefreshEntity<IncomeStatement>(),
                };

                await Task.WhenAll(tasks);
            }

            await Task.Delay(_settings.CheckUpdateTime, stoppingToken);
        }
    }

   
}

public class LoaderSettings
{
    public TimeSpan CheckUpdateTime = TimeSpan.FromSeconds(1);
}