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
        return rangedValue.HasValue ? queryable.Where(x => x.DebtEquity >= rangedValue.Value.Min &&
                                                           x.DebtEquity >= rangedValue.Value.Max ) : queryable;
    }
    //ToDo: реализовать оставшиеся методы
    
    public static IQueryable<CompanyOverview> WherePeRatio(this IQueryable<CompanyOverview> queryable, RangedValue<decimal>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => (decimal) x.PERatio.Value > rangedValue.Value.Min &&
                                                            (decimal) x.PERatio.Value <= rangedValue.Value.Max) : queryable;
    }
    
    public static IQueryable<CompanyOverview> WhereEPS(this IQueryable<CompanyOverview> queryable, RangedValue<decimal>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => (decimal) x.EPS.Value > rangedValue.Value.Min &&
                                                           (decimal) x.EPS.Value <= rangedValue.Value.Max) : queryable;
    }
    public static IQueryable<CompanyOverview> WhereBeta(this IQueryable<CompanyOverview> queryable, RangedValue<decimal>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => (decimal) x.Beta.Value > rangedValue.Value.Min &&
                                                           (decimal) x.Beta.Value <= rangedValue.Value.Max) : queryable;
        
    }
    
    #endregion

    #region Dynamic
    public static IQueryable<CompanyOverview> WhereEpsGrowth1Year(this IQueryable<CompanyOverview> queryable, RangedValue<decimal>? rangedValue)
    {
        
        return rangedValue.HasValue ? queryable.Where(x => !x.EPSGrowthXYears(1).HasValue ||
                                                           rangedValue.Value.Max >= x.DebtEquity && 
                                                           rangedValue.Value.Min <= x.DebtEquity ) : queryable;
    }
    public static IQueryable<CompanyOverview> WhereEpsGrowth5Year(this IQueryable<CompanyOverview> queryable, RangedValue<decimal>? rangedValue)
    {  
        return rangedValue.HasValue ? queryable.Where(x => !x.EPSGrowthXYears(1).HasValue ||
                                                           x.EPSGrowthXYears(5) >= rangedValue.Value.Min && 
                                                           x.EPSGrowthXYears(5) <= rangedValue.Value.Max ) : queryable;
    }
    public static IQueryable<CompanyOverview> WhereRevenueGrowth1Year(this IQueryable<CompanyOverview> queryable, RangedValue<decimal>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => !x.RevenueGrowthXYears(1).HasValue ||
                                                           x.RevenueGrowthXYears(1) >= rangedValue.Value.Min && 
                                                           x.RevenueGrowthXYears(1) <= rangedValue.Value.Max ) : queryable;
    }
    public static IQueryable<CompanyOverview> WhereRevenueGrowth5Year(this IQueryable<CompanyOverview> queryable, RangedValue<decimal>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => !x.RevenueGrowthXYears(5).HasValue || 
                                                           x.RevenueGrowthXYears(5).Value >= rangedValue.Value.Min &&
                                                           x.RevenueGrowthXYears(5).Value <= rangedValue.Value.Max) : queryable;
    }
    #endregion

    #region Dividend

    public static IQueryable<CompanyOverview> WhereNextDividend(this IQueryable<CompanyOverview> queryable, RangedValue<DateTime>? rangedValue)
    {
        // throw new NotImplementedException("How to calculate dividend");
        return rangedValue.HasValue ? queryable.Where(x => x.DividendDate.Value >= rangedValue.Value.Min &&
                                                           x.DividendDate.Value <= rangedValue.Value.Max ) : queryable;
    }

    #endregion
    
    
}