using SaluteStocksAPI.DataBase;
using SaluteStocksAPI.Models.Distribution;

namespace SaluteStocksAPI.Service;

public class Distributions
{
    private readonly StocksContext _context;

    public Distributions(StocksContext context)
    {
        _context = context;
    }

    public Distribution MarketCap(int pieces) => throw new NotImplementedException();
    public Distribution Ebitda(int pieces) => throw new NotImplementedException();
    public Distribution DebtEquity(int pieces) => throw new NotImplementedException();
    public Distribution PeRation(int pieces) => throw new NotImplementedException();
    public Distribution EpsGrowth1Year(int pieces) => throw new NotImplementedException();
    public Distribution EpsGrowth3Years(int pieces) => throw new NotImplementedException();
}