using Microsoft.EntityFrameworkCore;
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

    public async Task<Distribution> MarketCap(int pieces)
    {
        const double logBase = 5;
        // var gps = _context.CompanyOverviews.GroupBy(overview => overview.MarketCapitalization, overview2 => 1);
        var maxValue = (await _context.CompanyOverviews.MaxAsync(x => x.MarketCapitalization))!.Value;
        var minValue = (await _context.CompanyOverviews.MinAsync(x => x.MarketCapitalization))!.Value;

        double mult = Math.Pow(maxValue / minValue, 1.0 / pieces);
        
        var selectedGroups = _context.CompanyOverviews.Where(x=>x.MarketCapitalization.HasValue)
            .GroupBy(x => (long) (Math.Log(x.MarketCapitalization.Value/minValue)/Math.Log(mult)))
            .Select(x => new  DistributionValue(){Position = x.Key, Value = x.Count()});

        return new Distribution()
        {
            Property = "api shit",
            Values = await selectedGroups.ToListAsync()
        };

    }
    public Distribution Ebitda(int pieces) => throw new NotImplementedException();
    public Distribution DebtEquity(int pieces) => throw new NotImplementedException();
    public Distribution PeRation(int pieces) => throw new NotImplementedException();
    public Distribution EpsGrowth1Year(int pieces) => throw new NotImplementedException();
    public Distribution EpsGrowth3Years(int pieces) => throw new NotImplementedException();
}