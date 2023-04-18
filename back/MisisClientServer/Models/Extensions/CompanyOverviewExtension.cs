using System.Linq.Expressions;
using LinqKit;
using MisisClientServer.Models.FundamentalData;
using MisisClientServer.Screener;

namespace MisisClientServer.Models.Extensions;

public static class CompanyOverviewExtension
{
    #region Basic

    private static Expression<Func<CompanyOverview, BalanceSheetAnnualReport>> LastReportExpression =>
        co => co.BalanceSheet.AnnualReports[0];

    private static Expression<Func<CompanyOverview, double?>> DebtEquityExpression =>
        overview => ( LastReportExpression.Invoke(overview).TotalLiabilities )/
                    (LastReportExpression.Invoke(overview).TotalShareholderEquity);

    private static Expression<Func<double, bool>> IsInRangeExpression(RangedValue<double> rv)
    {
        return d => d >= rv.Min && d <= rv.Max;
    }
    #endregion
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
        return rangedValue.HasValue ? queryable.Where(x => x.MarketCapitalization.HasValue && rangedValue.Value.Max >= x.MarketCapitalization.Value && rangedValue.Value.Min <= x.MarketCapitalization.Value ) : queryable;
    }
    public static IQueryable<CompanyOverview> WhereEbitda(this IQueryable<CompanyOverview> queryable, RangedValue<double>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => x.EBITDA.HasValue && rangedValue.Value.Max >= x.EBITDA.Value && rangedValue.Value.Min <= x.EBITDA.Value) : queryable;
    }

    
    public static IQueryable<CompanyOverview> WhereDebtEquity(this IQueryable<CompanyOverview> queryable, RangedValue<double>? rangedValue)
    {
        Expression<Func<CompanyOverview, bool>> finalExpression = overview =>
            !DebtEquityExpression.Invoke(overview).HasValue ||
            IsInRangeExpression(rangedValue.Value).Invoke(DebtEquityExpression.Invoke(overview).Value);
        return rangedValue.HasValue ? queryable.Where(finalExpression.Expand()) : queryable;
    }
    //ToDo: реализовать оставшиеся методы
    
    public static IQueryable<CompanyOverview> WherePeRatio(this IQueryable<CompanyOverview> queryable, RangedValue<double>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => x.PERatio.HasValue && rangedValue.Value.Max >= x.PERatio.Value && rangedValue.Value.Min <= x.PERatio.Value) : queryable;
    }
    
    public static IQueryable<CompanyOverview> WhereEPS(this IQueryable<CompanyOverview> queryable, RangedValue<double>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => x.EPS.HasValue && rangedValue.Value.Max >= x.EPS.Value && rangedValue.Value.Min <= x.EPS.Value) : queryable;
    }
    public static IQueryable<CompanyOverview> WhereBeta(this IQueryable<CompanyOverview> queryable, RangedValue<double>? rangedValue)
    {
        return rangedValue.HasValue ? queryable.Where(x => x.Beta.HasValue && rangedValue.Value.Max >= x.Beta.Value && rangedValue.Value.Min <= x.Beta.Value) : queryable;

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