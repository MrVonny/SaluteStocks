using Microsoft.EntityFrameworkCore;
using SaluteStocksAPI.DataBase;
using SaluteStocksAPI.Models.Distribution;

namespace SaluteStocksAPI.Service;

public class Distributions
{
    private readonly DataBaseRepository _repostiroty;

    public Distributions(DataBaseRepository repostiroty)
    {
        _repostiroty = repostiroty;
    }


    public async Task<Distribution> MarketCap(int pieces)
    {
        const double logBase = 5;
        // var gps = _context.CompanyOverviews.GroupBy(overview => overview.MarketCapitalization, overview2 => 1);
        var maxValue = (await _repostiroty.CompanyOverviews.MaxAsync(x => x.MarketCapitalization))!.Value;
        var minValue = (await _repostiroty.CompanyOverviews.MinAsync(x => x.MarketCapitalization))!.Value;

        double mult = Math.Pow(maxValue / minValue, 1.0 / pieces);
        
        var selectedGroups = _repostiroty.CompanyOverviews.Where(x=>x.MarketCapitalization.HasValue)
            .GroupBy(x => (long) (Math.Log(x.MarketCapitalization.Value/minValue)/Math.Log(mult)))
            .Select(x => new  {Position = x.Key, Value = x.Count()});
        var res = (await selectedGroups.ToListAsync()).Select(x =>
            new DistributionValue(new KeyValuePair<double, int>(x.Position, x.Value)));
        
        return new Distribution()
        {
            Property = "api shit",
            Values = res.ToList()
        };

    }
    public Distribution Ebitda(int pieces) => throw new NotImplementedException();
    public Distribution DebtEquity(int pieces) => throw new NotImplementedException();
    public Distribution PeRation(int pieces) => throw new NotImplementedException();
    public Distribution EpsGrowth1Year(int pieces) => throw new NotImplementedException();
    public Distribution EpsGrowth3Years(int pieces) => throw new NotImplementedException();
}