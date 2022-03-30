using Newtonsoft.Json;
using SaluteStocksAPI.DataBase;

namespace SaluteStocksAPI.Models.FundamentalData;
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

public class CompanyOverview : EntityInfo
{
    [JsonProperty("AssetType")] public string AssetType { get; set; }

    [JsonProperty("Name")] public string Name { get; set; }

    [JsonProperty("Description")] public string Description { get; set; }

    [JsonProperty("CIK")] public decimal? CIK { get; set; }

    [JsonProperty("Exchange")] public string Exchange { get; set; }

    [JsonProperty("Currency")] public string Currency { get; set; }

    [JsonProperty("Country")] public string Country { get; set; }

    [JsonProperty("Sector")] public string Sector { get; set; }

    [JsonProperty("Industry")] public string Industry { get; set; }

    [JsonProperty("Address")] public string Address { get; set; }

    [JsonProperty("FiscalYearEnd")] public string FiscalYearEnd { get; set; }

    [JsonProperty("LatestQuarter")] public DateTime? LatestQuarter { get; set; }

    [JsonProperty("MarketCapitalization")] public decimal? MarketCapitalization { get; set; }

    [JsonProperty("EBITDA")] public decimal? EBITDA { get; set; }

    [JsonProperty("PERatio")] public decimal? PERatio { get; set; }

    [JsonProperty("PEGRatio")] public decimal? PEGRatio { get; set; }

    [JsonProperty("BookValue")] public decimal? BookValue { get; set; }

    [JsonProperty("DividendPerShare")] public decimal? DividendPerShare { get; set; }

    [JsonProperty("DividendYield")] public decimal? DividendYield { get; set; }

    [JsonProperty("EPS")] public decimal? EPS { get; set; }

    [JsonProperty("RevenuePerShareTTM")] public decimal? RevenuePerShareTTM { get; set; }

    [JsonProperty("ProfitMargin")] public decimal? ProfitMargin { get; set; }

    [JsonProperty("OperatingMarginTTM")] public decimal? OperatingMarginTTM { get; set; }

    [JsonProperty("ReturnOnAssetsTTM")] public decimal? ReturnOnAssetsTTM { get; set; }

    [JsonProperty("ReturnOnEquityTTM")] public decimal? ReturnOnEquityTTM { get; set; }

    [JsonProperty("RevenueTTM")] public decimal? RevenueTTM { get; set; }

    [JsonProperty("GrossProfitTTM")] public decimal? GrossProfitTTM { get; set; }

    [JsonProperty("DilutedEPSTTM")] public decimal? DilutedEPSTTM { get; set; }

    [JsonProperty("QuarterlyEarningsGrowthYOY")]
    public decimal? QuarterlyEarningsGrowthYOY { get; set; }

    [JsonProperty("QuarterlyRevenueGrowthYOY")]
    public decimal? QuarterlyRevenueGrowthYOY { get; set; }

    [JsonProperty("AnalystTargetPrice")] public decimal? AnalystTargetPrice { get; set; }

    [JsonProperty("TrailingPE")] public decimal? TrailingPE { get; set; }

    [JsonProperty("ForwardPE")] public decimal? ForwardPE { get; set; }

    [JsonProperty("PriceToSalesRatioTTM")] public decimal? PriceToSalesRatioTTM { get; set; }

    [JsonProperty("PriceToBookRatio")] public decimal? PriceToBookRatio { get; set; }

    [JsonProperty("EVToRevenue")] public decimal? EVToRevenue { get; set; }

    [JsonProperty("EVToEBITDA")] public decimal? EVToEBITDA { get; set; }

    [JsonProperty("Beta")] public decimal? Beta { get; set; }

    [JsonProperty("52WeekHigh")] public decimal? _52WeekHigh { get; set; }

    [JsonProperty("52WeekLow")] public decimal? _52WeekLow { get; set; }

    [JsonProperty("50DayMovingAverage")] public decimal? _50DayMovingAverage { get; set; }

    [JsonProperty("200DayMovingAverage")] public decimal? _200DayMovingAverage { get; set; }

    [JsonProperty("SharesOutstanding")] public decimal? SharesOutstanding { get; set; }

    [JsonProperty("DividendDate")] public DateTime? DividendDate { get; set; }

    [JsonProperty("ExDividendDate")] public DateTime? ExDividendDate { get; set; }


    public decimal DebtEquity
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
    
    public decimal? EPSGrowthSomeYears(short some)
    {
        var earnings = Earnings.AnnualEarnings.OrderByDescending(x => x.FiscalDateEnding!.Value.Year).ToList();
        if (earnings.Count < some+1)
        {
            return null;
        }
        if (earnings[0].FiscalDateEnding!.Value.Year - earnings[some].FiscalDateEnding!.Value.Year != some) // there are missing years in X last AnnualReports
        {
            return null;
        }
        if (earnings[0].FiscalDateEnding.Value.Year < 2020) // data is too old
        {
            return null;
        }
        return earnings[0].ReportedEPS.Value / earnings[some].ReportedEPS.Value;
    }
    public decimal? RevenueGrowthSomeYears(short some) {
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