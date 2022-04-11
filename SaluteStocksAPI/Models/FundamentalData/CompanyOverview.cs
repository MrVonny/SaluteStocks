using System.Linq.Expressions;
using Newtonsoft.Json;
using SaluteStocksAPI.DataBase;

namespace SaluteStocksAPI.Models.FundamentalData;
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

public class CompanyOverview : EntityInfo
{
    [JsonProperty("AssetType")] public string AssetType { get; set; }

    [JsonProperty("Name")] public string Name { get; set; }

    [JsonProperty("Description")] public string Description { get; set; }

    [JsonProperty("CIK")] public long? CIK { get; set; }

    [JsonProperty("Exchange")] public string Exchange { get; set; }

    [JsonProperty("Currency")] public string Currency { get; set; }

    [JsonProperty("Country")] public string Country { get; set; }

    [JsonProperty("Sector")] public string Sector { get; set; }

    [JsonProperty("Industry")] public string Industry { get; set; }

    [JsonProperty("Address")] public string Address { get; set; }

    [JsonProperty("FiscalYearEnd")] public string FiscalYearEnd { get; set; }

    [JsonProperty("LatestQuarter")] public DateTime? LatestQuarter { get; set; }

    [JsonProperty("MarketCapitalization")] public long? MarketCapitalization { get; set; }

    [JsonProperty("EBITDA")] public long? EBITDA { get; set; }
    [JsonProperty("PERatio")] public double? PERatio { get; set; }

    [JsonProperty("PEGRatio")] public double? PEGRatio { get; set; }

    [JsonProperty("BookValue")] public double? BookValue { get; set; }

    [JsonProperty("DividendPerShare")] public double? DividendPerShare { get; set; }

    [JsonProperty("DividendYield")] public double? DividendYield { get; set; }

    [JsonProperty("EPS")] public double? EPS { get; set; }

    [JsonProperty("RevenuePerShareTTM")] public double? RevenuePerShareTTM { get; set; }

    [JsonProperty("ProfitMargin")] public double? ProfitMargin { get; set; }

    [JsonProperty("OperatingMarginTTM")] public double? OperatingMarginTTM { get; set; }

    [JsonProperty("ReturnOnAssetsTTM")] public double? ReturnOnAssetsTTM { get; set; }

    [JsonProperty("ReturnOnEquityTTM")] public double? ReturnOnEquityTTM { get; set; }

    [JsonProperty("RevenueTTM")] public long? RevenueTTM { get; set; }

    [JsonProperty("GrossProfitTTM")] public long? GrossProfitTTM { get; set; }

    [JsonProperty("DilutedEPSTTM")] public double? DilutedEPSTTM { get; set; }

    [JsonProperty("QuarterlyEarningsGrowthYOY")]
    public double? QuarterlyEarningsGrowthYOY { get; set; }

    [JsonProperty("QuarterlyRevenueGrowthYOY")]
    public double? QuarterlyRevenueGrowthYOY { get; set; }

    [JsonProperty("AnalystTargetPrice")] public double? AnalystTargetPrice { get; set; }

    [JsonProperty("TrailingPE")] public double? TrailingPE { get; set; }

    [JsonProperty("ForwardPE")] public double? ForwardPE { get; set; }

    [JsonProperty("PriceToSalesRatioTTM")] public double? PriceToSalesRatioTTM { get; set; }

    [JsonProperty("PriceToBookRatio")] public double? PriceToBookRatio { get; set; }

    [JsonProperty("EVToRevenue")] public double? EVToRevenue { get; set; }

    [JsonProperty("EVToEBITDA")] public double? EVToEBITDA { get; set; }

    [JsonProperty("Beta")] public double? Beta { get; set; }

    [JsonProperty("52WeekHigh")] public double? _52WeekHigh { get; set; }

    [JsonProperty("52WeekLow")] public double? _52WeekLow { get; set; }

    [JsonProperty("50DayMovingAverage")] public double? _50DayMovingAverage { get; set; }

    [JsonProperty("200DayMovingAverage")] public double? _200DayMovingAverage { get; set; }

    [JsonProperty("SharesOutstanding")] public long? SharesOutstanding { get; set; }

    [JsonProperty("DividendDate")] public DateTime? DividendDate { get; set; }

    [JsonProperty("ExDividendDate")] public DateTime? ExDividendDate { get; set; }


    public double DebtEquity
    {
        get
        {
            var currentYear = BalanceSheet.AnnualReports.Max(x => x.FiscalDateEnding);
            var lastReport = BalanceSheet.AnnualReports.Single(y => y.FiscalDateEnding == currentYear);
            var totalLiabilities = lastReport.TotalLiabilities.Value;
            var shareholderEquity = lastReport.TotalShareholderEquity.Value;
            return totalLiabilities / shareholderEquity;
        }
    }
    
    
    public double? EPSGrowthSomeYears(short some)
    {
        var earnings = Earnings.AnnualEarnings.OrderByDescending(x => x.FiscalDateEnding!.Value.Year).ToList();
        if (earnings.Count < some + 1)
        {
            return null;
        }

        if (earnings[0].FiscalDateEnding!.Value.Year - earnings[some].FiscalDateEnding!.Value.Year !=
            some) // there are missing years in X last AnnualReports
        {
            return null;
        }

        if (earnings[0].FiscalDateEnding.Value.Year < 2020) // data is too old
        {
            return null;
        }

        return earnings[some].ReportedEPS.Value / earnings[0].ReportedEPS.Value - 1;
    }

    public double? RevenueGrowthSomeYears(short some) {
        
        //throw new NotImplementedException();
        if (IncomeStatement.AnnualReports.Count < some + 1)
        {
            return null;
        }

        
        var sorted = IncomeStatement.AnnualReports.OrderByDescending(x => x.FiscalDateEnding.Year).ToList();
         if (sorted[0].FiscalDateEnding.Year >= DateTime.Now.Year - 2 &&
             sorted[some].FiscalDateEnding.Year >= DateTime.Now.Year - some - 2)
         {
             return sorted[0].TotalRevenue.Value / sorted[some].TotalRevenue.Value;
         }

        return null;
    } 
    [JsonIgnore]
    public BalanceSheet BalanceSheet { get; set; }
    [JsonIgnore]
    public CashFlow CashFlow { get; set; }
    [JsonIgnore]
    public Earnings Earnings { get; set; }
    [JsonIgnore]
    public IncomeStatement IncomeStatement { get; set; }
}

