using Microsoft.EntityFrameworkCore.Design.Internal;
using SaluteStocksAPI.Models.FundamentalData;
using SaluteStocksAPI.Screener;
using Serilog;

namespace SaluteStocksAPI.Models.Extensions.Common;
public static class CompanyOverviewExtensionFunctions
{
    public static bool FuncDebtEquity(CompanyOverview x, RangedValue<decimal> rangedValue)
    {
        var currentYear = x.BalanceSheet.AnnualReports.Max(x => x.FiscalDateEnding);
        var lastReport = x.BalanceSheet.AnnualReports.Where(y => y.FiscalDateEnding == currentYear).ToList()[0];
        var totalLiabilities = lastReport.TotalLiabilities;
        var shareholderEquity = lastReport.TotalShareholderEquity;
        var objectsDebtEquity = Convert.ToDecimal(totalLiabilities) / shareholderEquity;
        return rangedValue.Max >= objectsDebtEquity && rangedValue.Min <= objectsDebtEquity;
    }

    public static bool FuncEpsGrowth1Year(CompanyOverview x, RangedValue<decimal> rangedValue)
    {
        var earnings = x.Earnings.AnnualEarnings;
        if (earnings.Count < 2)
        {
            return false;
        }

        earnings = earnings.OrderByDescending(x => x.FiscalDateEnding!.Value.Year ).ToList();



        
        if (earnings[0].FiscalDateEnding!.Value.Year - earnings[1].FiscalDateEnding!.Value.Year != 1)
        {
            return false;
        }
        if (earnings[0].FiscalDateEnding.Value.Year < 2020)
        {
            return false;
        }
        var epsDifference = earnings[0].ReportedEPS - earnings[1].ReportedEPS;
        // todo erase (double) after fix
        return epsDifference >= (double) rangedValue.Min &&  epsDifference <= (double) rangedValue.Max ? true : false ;
    }
    public static bool FuncEpsGrowth5Year(CompanyOverview x, RangedValue<decimal> rangedValue)
    {
        var earnings = x.Earnings.AnnualEarnings;
        if (earnings.Count < 6)
        {
            return false;
        }
        earnings.Sort((x, y) => x.FiscalDateEnding!.Value.Year);
            

        
        if (earnings[0].FiscalDateEnding!.Value.Year - earnings[5].FiscalDateEnding!.Value.Year != 5)
        {
            return false;
        }
        if (earnings[0].FiscalDateEnding.Value.Year < 2020)
        {
            return false;
        }
        var epsDifference = earnings[0].ReportedEPS - earnings[5].ReportedEPS;
        // todo erase (double) after fix
        return epsDifference >= (double) rangedValue.Min &&  epsDifference <= (double) rangedValue.Max ? true : false ;
    }
}
