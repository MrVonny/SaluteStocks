using Microsoft.EntityFrameworkCore;
using SaluteStocksAPI.DataBase;
using SaluteStocksAPI.Models.Extensions;
using SaluteStocksAPI.Screener;

namespace SaluteStocksAPI.Service;

public class ScreenerService
{
    private readonly DataBaseRepository _repository;

    public Distributions Distributions { get; }

    public ScreenerService(DataBaseRepository repository)
    {
        _repository = repository;
        Distributions =  new Distributions(repository);
    }

    public async Task<List<string>> GetStockSymbols(ScreenerModel screenerModel)
    {
        var companiesQuery = _repository.CompanyOverviews
            .AsNoTracking()
            //Currency
            .WhereCurrency(screenerModel.Currency)
            .WhereSector(screenerModel.Sector)
            .WhereCountry(screenerModel.Country)
            //Financial
            .WhereMarketCap(screenerModel.MarketCap)
            .WhereEbitda(screenerModel.Ebitda)
            //ToDo: Uncomment when implemented
            .WhereDebtEquity(screenerModel.DebtToEquity)
            .WherePeRatio(screenerModel.PERatio)
            .WhereEPS(screenerModel.EPS)
            .WhereBeta(screenerModel.Beta)
            //Dynamic
            .WhereEpsGrowth1Year(screenerModel.EpsGrowth1Year)
            .WhereEpsGrowth5Year(screenerModel.EpsGrowth5Year)
            .WhereRevenueGrowth1Year(screenerModel.RevenueGrowth1Year)
            .WhereRevenueGrowth5Year(screenerModel.RevenueGrowth5Year)
            //Dividend
            .WhereNextDividend(screenerModel.NextDividend);

            return await companiesQuery.Select(x => x.Symbol).ToListAsync();
    }


    public async Task<ScreenerModel> GetInitialModelAsync()
    {
        var model = new ScreenerModel();

        model.MarketCap = new RangedValue<double>(
            await _repository.CompanyOverviews.MinAsync(x => x.MarketCapitalization.Value) / 10e9,
            await _repository.CompanyOverviews.MaxAsync(x => x.MarketCapitalization.Value) / 10e9);
        
        model.Ebitda = new RangedValue<double>(
            await _repository.CompanyOverviews.MinAsync(x => x.EBITDA.Value) / 10e9,
            await _repository.CompanyOverviews.MaxAsync(x => x.EBITDA.Value) / 10e9);
        
        // model.DebtToEquity = new RangedValue<double>(
        //     (await _repository.CompanyOverviews.ToListAsync()).Min(x => x.DebtEquity),
        //     (await _repository.CompanyOverviews.ToListAsync()).Max(x => x.DebtEquity));
        
        model.PERatio = new RangedValue<double>(
            await _repository.CompanyOverviews.MinAsync(x => x.PERatio.Value),
            await _repository.CompanyOverviews.MaxAsync(x => x.PERatio.Value));
        
        // model.PERatio = new RangedValue<double>(
        //     _repository.CompanyOverviews.Min(x => x.EPSGrowthSomeYears().Value),
        //     _repository.CompanyOverviews.Max(x => x.PERatio.Value));

        return model;
    }
}

