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
        
        // var selectedGroups = await _repostiroty.CompanyOverviews.Where(x => x.MarketCapitalization.HasValue)
        //     .GroupBy(x => (int)(Math.Log(x.MarketCapitalization.Value / minValue) / Math.Log(mult)))
        //     .Select(x => new { Position = x.First().MarketCapitalization.Value, Value = x.Count() })
        //     .ToListAsync();
        //
        //     
        // var ansWithoutZeroes = selectedGroups.Select(x => new DistributionValue(x.Position, x.Value)).ToList();
        // var ans = new List<DistributionValue>(pieces + 1);
        // int counter = 0;
        // foreach (DistributionValue val in ansWithoutZeroes)
        // {
        //     for (; counter < val.Position; counter++)
        //     {
        //         ans.Add(new DistributionValue(counter, 0));
        //     }
        //     ans.Add(new DistributionValue(counter, val.Value));
        //     counter++;
        // }
        
        
        // var maxValue = (await _repostiroty.CompanyOverviews.MaxAsync(x => x.MarketCapitalization))!.Value;
        // var minValue = (await _repostiroty.CompanyOverviews.MinAsync(x => x.MarketCapitalization))!.Value;
        //
        // var values = new List<DistributionValue>();
        // var shift = (maxValue - minValue) / pieces;
        // for (var i = 0; i < pieces; i++)
        // {
        //     var count = await _repostiroty.CompanyOverviews.CountAsync(x =>
        //         x.MarketCapitalization > i * shift && x.MarketCapitalization < (i + 1) * shift);
        //     values.Add(new DistributionValue((i+0.5)*shift/10e9 , count));
        // }
        //
        return new Distribution()
        {
            Property = "api shit",
            Values = values
        };

    }
    public Distribution Ebitda(int pieces) => throw new NotImplementedException();
    public Distribution DebtEquity(int pieces) => throw new NotImplementedException();
    public Distribution PeRation(int pieces) => throw new NotImplementedException();
    public Distribution EpsGrowth1Year(int pieces) => throw new NotImplementedException();
    public Distribution EpsGrowth3Years(int pieces) => throw new NotImplementedException();
}