using SaluteStocksAPI.Models.FundamentalData;
using SaluteStocksAPI.Screener;

namespace SaluteStocksAPI.Models.Extensions;

public static class CompanyOverviewExtension
{
    #region Common
    public static IQueryable<CompanyOverview> WhereCurrency(this IQueryable<CompanyOverview> queryable, params string[] currencies)
    {
        return currencies is { Length: > 0 } ? queryable.Where(x => currencies.Contains(x.Currency)) : queryable;
    }
    
    public static IQueryable<CompanyOverview> WhereSector(this IQueryable<CompanyOverview> queryable, params string[] sectors)
    {
        return sectors is { Length: > 0 } ? queryable.Where(x => sectors.Contains(x.Sector)) : queryable;
    }
    public static IQueryable<CompanyOverview> WhereCountry(this IQueryable<CompanyOverview> queryable, params string[] countries)
    {
        return countries is { Length: > 0 } ? queryable.Where(x => countries.Contains(x.Currency)) : queryable;
    }
    #endregion
    
    #region Financial
    public static IQueryable<CompanyOverview> WhereMarketCap(this IQueryable<CompanyOverview> queryable, RangedValue<decimal>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => x.MarketCapitalization.Value > rangedValue.Value.Min 
                                                           && x.MarketCapitalization.Value < rangedValue.Value.Max) : queryable;
    }
    public static IQueryable<CompanyOverview> WhereEbitda(this IQueryable<CompanyOverview> queryable, RangedValue<decimal>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => x.EBITDA.Value > rangedValue.Value.Min 
                                                           && x.EBITDA.Value < rangedValue.Value.Max) : queryable;
    }
    public static IQueryable<CompanyOverview> WhereDebtEquity(this IQueryable<CompanyOverview> queryable, RangedValue<decimal>? rangedValue)
    {
        //ToDo: fix this
        throw new NotImplementedException("We don't know how to calculate D/E ratio yet.");
    }
    //ToDo: реализовать оставшиеся методы
    
    #endregion

    #region Dynamic

    

    #endregion

    #region Dividend

    

    #endregion
    
    
}