using System.Collections.Concurrent;
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

        pieces--;
        const double expo = 0.2;
        
        var maxValue = (await _repostiroty.CompanyOverviews.MaxAsync(x => x.MarketCapitalization))!.Value;
        var minValue = (await _repostiroty.CompanyOverviews.MinAsync(x => x.MarketCapitalization))!.Value;
        
        
        var k = (maxValue - minValue) / (Math.Exp(expo*pieces) - 1);
        var positions = Enumerable.Range(0, pieces + 1).Select(x => k * (Math.Exp(expo*x) - 1) + minValue).ToArray();

        var values = new List<DistributionValue>();
        for (int i = 0; i < pieces; i++)
        {
            var from = positions[i];
            var to = positions[i + 1];
            var count = await _repostiroty.CompanyOverviews.CountAsync(c =>
                c.MarketCapitalization.HasValue && c.MarketCapitalization.Value > @from &&
                c.MarketCapitalization.Value < to);
            values.Add(new DistributionValue(from/10e9, count));
        }
        values.Add(new DistributionValue(positions.Last()/10e9, 0));
        
        return new Distribution()
        {
            Property = "Market Cap",
            Values = values
        };

    }

    public async Task<Distribution> Ebitda(int pieces)
    {
        pieces--;
        const double expo = 0.2;

        var maxValue = (await _repostiroty.CompanyOverviews.MaxAsync(x => x.EBITDA))!.Value;
        var minValue = (await _repostiroty.CompanyOverviews.MinAsync(x => x.EBITDA))!.Value;
        
        var positions = Enumerable.Range(0, pieces + 1).Select(x => minValue + (maxValue - minValue) * (double) x / pieces).ToArray();

        var values = new List<DistributionValue>();
        for (int i = 0; i < pieces; i++)
        {
            var from = positions[i];
            var to = positions[i + 1];
            var count = await _repostiroty.CompanyOverviews.CountAsync(c =>
                c.EBITDA.HasValue && c.EBITDA.Value > @from &&
                c.MarketCapitalization.Value < to);
            values.Add(new DistributionValue(from / 10e9, count));
        }

        values.Add(new DistributionValue(positions.Last() / 10e9, 0));

        return new Distribution()
        {
            Property = "Ebidta",
            Values = values
        };
    }

    public Distribution DebtEquity(int pieces) => throw new NotImplementedException();
    public Distribution PeRation(int pieces) => throw new NotImplementedException();
    public Distribution EpsGrowth1Year(int pieces) => throw new NotImplementedException();
    public Distribution EpsGrowth3Years(int pieces) => throw new NotImplementedException();
}