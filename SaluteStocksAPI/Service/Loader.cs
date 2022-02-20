using System.Collections.Concurrent;
using SaluteStocksAPI.AlphaVantage;

namespace SaluteStocksAPI.Service;

public class Loader
{
    private readonly IDataBaseRepository _repository;
    private AlphaVantageClient Client => AlphaVantageClientFactory.Create();
    private ConcurrentBag<string> SymbolList { get; set; }

    public Loader()
    {
        SymbolList = new ConcurrentBag<string>(Client.GetListing().Result.Select(x=>x.Symbol));
        
    }

    public void Do()
    {
        while (true)
        {
            Task.Run(() =>
            {
                var symbol =  _repository.GetOldestCompanyOverviewSymbol().Result;
                var companyOverview = Client.GetCompanyOverview(symbol).Result;
                _repository.SetCompanyOverview(companyOverview);
            });
            Thread.Sleep(100);
        }
    }
}