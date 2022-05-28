using System.Collections.Concurrent;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
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
        
        var positions = GetLogarithmicPositions(minValue, maxValue, pieces + 1);
        
        var values = new List<DistributionValue>();
        for (int i = 0; i < pieces; i++)
        {
            var from = positions[i];
            var to = positions[i + 1];
            var count = await _repostiroty.CompanyOverviews.CountAsync(c =>
                c.MarketCapitalization.HasValue && c.MarketCapitalization.Value >= @from &&
                c.MarketCapitalization.Value <= to);
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

        var positions = GetLogarithmicPositions(minValue, maxValue, pieces + 1);

        var values = new List<DistributionValue>();
        for (int i = 0; i < pieces; i++)
        {
            var from = positions[i];
            var to = positions[i + 1];
            var count = await _repostiroty.CompanyOverviews.CountAsync(c =>
                c.EBITDA.HasValue && c.EBITDA.Value >= @from &&
                c.EBITDA.Value <= to);
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

    public async Task<Distribution> PeRation(int pieces)
    {
        pieces--;

        var maxValue = (await _repostiroty.CompanyOverviews.MaxAsync(x => x.PERatio))!.Value;
        var minValue = (await _repostiroty.CompanyOverviews.MinAsync(x => x.PERatio))!.Value;
        
        var positions = GetLogarithmicPositions(minValue, maxValue, pieces + 1);

        var values = new List<DistributionValue>();
        for (int i = 0; i < pieces; i++)
        {
            var from = positions[i];
            var to = positions[i + 1];
            var count = await _repostiroty.CompanyOverviews.CountAsync(c =>
                c.PERatio.HasValue && c.PERatio.Value >= @from &&
                c.PERatio.Value <= to);
            values.Add(new DistributionValue(from, count));
        }
        values.Add(new DistributionValue(positions.Last(), 0));
        
        return new Distribution()
        {
            Property = "P/E Ratio",
            Values = values
        };
    }
    public Distribution EpsGrowth1Year(int pieces) => throw new NotImplementedException();
    public Distribution EpsGrowth3Years(int pieces) => throw new NotImplementedException();

    public async Task<Distribution> Eps(int pieces)
    {
        pieces--;

        var maxValue = (await _repostiroty.CompanyOverviews.MaxAsync(x => x.EPS))!.Value;
        var minValue = (await _repostiroty.CompanyOverviews.MinAsync(x => x.EPS))!.Value;
        
        var positions = GetLogarithmicPositions(minValue, maxValue, pieces  + 1);

        var values = new List<DistributionValue>();
        for (int i = 0; i < pieces; i++)
        {
            var from = positions[i];
            var to = positions[i + 1];
            var count = await _repostiroty.CompanyOverviews.CountAsync(c =>
                c.EPS.HasValue && c.EPS.Value >= @from &&
                c.EPS.Value <= to);
            values.Add(new DistributionValue(from, count));
        }
        values.Add(new DistributionValue(positions.Last(), 0));
        
        return new Distribution()
        {
            Property = "EPS",
            Values = values
        };
    }
    
    public async Task<Distribution> Beta(int pieces)
    {
        pieces--;

        var maxValue = (await _repostiroty.CompanyOverviews.MaxAsync(x => x.Beta))!.Value;
        var minValue = (await _repostiroty.CompanyOverviews.MinAsync(x => x.Beta))!.Value;
        
        var positions = GetLogarithmicPositions(minValue, maxValue, pieces + 1);

        var values = new List<DistributionValue>();
        for (int i = 0; i < pieces; i++)
        {
            var from = positions[i];
            var to = positions[i + 1];
            var count = await _repostiroty.CompanyOverviews.CountAsync(c =>
                c.Beta.HasValue && c.Beta.Value >= @from &&
                c.Beta.Value <= to);
            values.Add(new DistributionValue(from, count));
        }
        values.Add(new DistributionValue(positions.Last(), 0));
        
        return new Distribution()
        {
            Property = "Beta",
            Values = values
        };
    }


    private double[] GetLogarithmicPositions(double min, double max, int positions, double expo = 0.2)
    {
        if (min >= 0)
        {
            var k = (max - min) / (Math.Exp(expo*(positions-1)) - 1);
            return Enumerable.Range(0, positions ).Select(x => k * (Math.Exp(expo*x) - 1) + min).ToArray();
        }
        else
        {
            positions--;
            double Sigm(double x) => 1 / (1 + Math.Exp(-0.5*x));

            var ratio = Math.Log(max / Math.Abs(min), 5);
            
            int leftPositions = (int) Math.Round(positions * Sigm(-ratio));
            int rightPositions = (int) Math.Round(positions * Sigm(ratio));
            
            var kr = max / (Math.Exp(expo*rightPositions) - 1);
            var kl = min / (Math.Exp(expo*leftPositions) - 1);

            return Enumerable.Range(-leftPositions, leftPositions)
                .Select(x => kl * (Math.Exp(expo * -x) - 1))
                .Concat(
                    Enumerable.Range(0, rightPositions + 1)
                    .Select(x => kr * (Math.Exp(expo * x) - 1)))
                .ToArray();
        }
        
    }
}