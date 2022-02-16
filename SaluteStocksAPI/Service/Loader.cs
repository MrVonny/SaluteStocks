using System.Collections.Concurrent;
using SaluteStocksAPI.AlphaVantage;

namespace SaluteStocksAPI.Service;

public class Loader
{
    private readonly IDataBaseRepository _repository;
    private AlphaVantageClient Client => AlphaVantageClientFactory.Create();
    private ConcurrentBag<Tuple<string, DateTime>> SymbolList { get; set; }

    public Loader()
    {
        SymbolList = new ConcurrentBag<Tuple<string, DateTime>>(_repository.GetListingWithLastUpdateDate().Result);
        
    }

    public void Do()
    {
        while (true)
        {
            Task.Run(() =>
            {
                var symbol = SymbolList.MinBy(x => x.Item2)?.Item1;
                var companyOverview = Client.GetCompanyOverview(symbol).Result;
                _repository.SetCompanyOverview(companyOverview);
            });
            Thread.Sleep(100);
        }
    }
}