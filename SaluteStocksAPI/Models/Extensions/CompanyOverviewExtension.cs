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
        return countries is { Length: > 0 } ? queryable.Where(x => countries.Contains(x.Country)) : queryable;
    }
    #endregion
    
    #region Financial
    public static IQueryable<CompanyOverview> WhereMarketCap(this IQueryable<CompanyOverview> queryable, RangedValue<double>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => !x.MarketCapitalization.HasValue || rangedValue.Value.IsInRange(x.MarketCapitalization.Value)) : queryable;
    }
    public static IQueryable<CompanyOverview> WhereEbitda(this IQueryable<CompanyOverview> queryable, RangedValue<double>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => !x.EBITDA.HasValue || rangedValue.Value.IsInRange(x.EBITDA.Value)) : queryable;
    }

    
    public static IQueryable<CompanyOverview> WhereDebtEquity(this IQueryable<CompanyOverview> queryable, RangedValue<double>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => rangedValue.Value.IsInRange(x.DebtEquity)) : queryable;
    }
    //ToDo: реализовать оставшиеся методы
    
    public static IQueryable<CompanyOverview> WherePeRatio(this IQueryable<CompanyOverview> queryable, RangedValue<double>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => !x.PERatio.HasValue || rangedValue.Value.IsInRange(x.PERatio.Value)) : queryable;
    }
    
    public static IQueryable<CompanyOverview> WhereEPS(this IQueryable<CompanyOverview> queryable, RangedValue<double>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => !x.EPS.HasValue || rangedValue.Value.IsInRange(x.EPS.Value)) : queryable;
    }
    public static IQueryable<CompanyOverview> WhereBeta(this IQueryable<CompanyOverview> queryable, RangedValue<double>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => !x.Beta.HasValue || rangedValue.Value.IsInRange(x.Beta.Value)) : queryable;
        
    }
    
    #endregion

    #region Dynamic
    public static IQueryable<CompanyOverview> WhereEpsGrowth1Year(this IQueryable<CompanyOverview> queryable, RangedValue<double>? rangedValue)
    {
        
        return rangedValue.HasValue ? queryable.Where(x => !x.EPSGrowthSomeYears(1).HasValue ||
                                                           rangedValue.Value.IsInRange(x.EPSGrowthSomeYears(1).Value)) : queryable;
    }
    public static IQueryable<CompanyOverview> WhereEpsGrowth5Year(this IQueryable<CompanyOverview> queryable, RangedValue<double>? rangedValue)
    {  
        return rangedValue.HasValue ? queryable.Where(x => !x.EPSGrowthSomeYears(5).HasValue ||
                                                           rangedValue.Value.IsInRange(x.EPSGrowthSomeYears(5).Value) ) : queryable;
    }
    public static IQueryable<CompanyOverview> WhereRevenueGrowth1Year(this IQueryable<CompanyOverview> queryable, RangedValue<double>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => !x.RevenueGrowthSomeYears(1).HasValue ||
                                                           rangedValue.Value.IsInRange(x.RevenueGrowthSomeYears(1).Value)) : queryable;
    }
    public static IQueryable<CompanyOverview> WhereRevenueGrowth5Year(this IQueryable<CompanyOverview> queryable, RangedValue<double>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => !x.RevenueGrowthSomeYears(5).HasValue || 
                                                           rangedValue.Value.IsInRange(x.RevenueGrowthSomeYears(5).Value)) : queryable;
    }
    #endregion

    #region Dividend

    public static IQueryable<CompanyOverview> WhereNextDividend(this IQueryable<CompanyOverview> queryable, RangedValue<DateTime>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => !x.DividendDate.HasValue || rangedValue.Value.IsInRange(x.DividendDate.Value)) : queryable;
    }

    #endregion
    
    
}