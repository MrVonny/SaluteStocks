using Microsoft.EntityFrameworkCore;
using MisisClientServer.Screener;
using MisisClientServer.ViewModels;
using MisisClientServer.DataBase;
using MisisClientServer.Models.Extensions;

namespace MisisClientServer.Service;

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

    public async Task<List<CompanyIndexViewModel>> GetCompanies(List<string> tickers)
    {
        var result = await _repository.CompanyOverviews
            .Where(c => tickers.Contains(c.Symbol))
            .Select(c => new CompanyIndexViewModel()
            {
                Name = c.Name,
                Ticker = c.Symbol,
                Description = c.Description,
                Country = c.Country,
                Sector = c.Sector,
                Price = ""
            }).ToListAsync();
        return result;
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
        
        
        model.PERatio = new RangedValue<double>(
            await _repository.CompanyOverviews.MinAsync(x => x.PERatio.Value),
            await _repository.CompanyOverviews.MaxAsync(x => x.PERatio.Value));
        
        model.EPS = new RangedValue<double>(
            await _repository.CompanyOverviews.MinAsync(x => x.EPS.Value),
            await _repository.CompanyOverviews.MaxAsync(x => x.EPS.Value));
        
        model.Beta = new RangedValue<double>(
            await _repository.CompanyOverviews.MinAsync(x => x.Beta.Value),
            await _repository.CompanyOverviews.MaxAsync(x => x.Beta.Value));

        return model;
    }

    public async Task<int> Count(ScreenerModel screenerModel)
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

        return await companiesQuery.CountAsync();
    }
}

