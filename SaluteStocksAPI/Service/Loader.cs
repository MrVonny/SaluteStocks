using System.Collections.Concurrent;
using SaluteStocksAPI.AlphaVantage;
using SaluteStocksAPI.DataBase;
using SaluteStocksAPI.Models.FundamentalData;

namespace SaluteStocksAPI.Service;

public class Loader : BackgroundService
{
    private readonly IDataBaseRepository _repository;
    private readonly LoaderSettings _settings;
    private AlphaVantageClient Client => AlphaVantageClientFactory.Create();
    private ConcurrentBag<string> SymbolList { get; set; }

    public Loader()
    {
        
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _repository.SetListing(Client.GetListing());
        while (!stoppingToken.IsCancellationRequested)
        {
            Task[] tasks = {
                RefreshEntity<CompanyOverview>(),
                RefreshEntity<BalanceSheet>(),
                RefreshEntity<CashFlow>(),
                RefreshEntity<CompanyOverview>(),
                RefreshEntity<Earnings>(),
                RefreshEntity<IncomeStatement>(),
            };
            
            await Task.WhenAll(tasks);

            await Task.Delay(_settings.CheckUpdateTime, stoppingToken);
        }
    }

    private async Task RefreshEntity<T>() where T : EntityInfo
    {
        Dictionary<Type, int> typeDict = new Dictionary<Type, int>
        {
            {typeof(BalanceSheet), 0},
            {typeof(CashFlow), 1},
            {typeof(CompanyOverview), 2},
            {typeof(Earnings), 3},
            {typeof(IncomeStatement), 4},
        };
        
        var symbol =  await _repository.GetOldestSymbol<T>();
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
        await _repository.Set(entity);
    }
}

internal class LoaderSettings
{
    public TimeSpan CheckUpdateTime => TimeSpan.FromSeconds(1);
}