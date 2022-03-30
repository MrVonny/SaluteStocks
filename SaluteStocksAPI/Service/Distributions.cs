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

    public Distribution MarketCap(int pieces)
    {
        var gps = _context.CompanyOverviews.GroupBy(overview => overview.MarketCapitalization, overview2 => 1);
            decimal maxval = gps.Max(x => x.Key.Value);
        var ans = gps.Select(
            x => new DistributionValue
            {
                Position = x.Key.Value,
                Value = x.Count()
            });
        return new Distribution
        {
            Property = "api shit",
            Values = ans.ToList()
        };

    }
    public Distribution Ebitda(int pieces) => throw new NotImplementedException();
    public Distribution DebtEquity(int pieces) => throw new NotImplementedException();
    public Distribution PeRation(int pieces) => throw new NotImplementedException();
    public Distribution EpsGrowth1Year(int pieces) => throw new NotImplementedException();
    public Distribution EpsGrowth3Years(int pieces) => throw new NotImplementedException();
}