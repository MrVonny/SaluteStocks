using Newtonsoft.Json;

namespace SaluteStocksAPI.Screener;

public class ScreenerModel
{
    #region Common

    [JsonProperty("currencies")]
    public string[] Currency { get; set; }
    public string[] Sector { get; set; }
    public string[] Country { get; set; }
    
    #endregion

    #region Financial

    [JsonProperty("marketCap")]
    public RangedValue<double>? MarketCap { get; set; }
    [JsonProperty("ebitda")]
    public RangedValue<double>? Ebitda { get; set; }
    [JsonProperty("debtEquity")]
    public RangedValue<double>? DebtToEquity { get; set; }
    [JsonProperty("peRatio")]
    public RangedValue<double>? PERatio { get; set; }
    public RangedValue<double>? EPS { get; set; }
    public RangedValue<double>? Beta { get; set; }

    #endregion

    #region Dynamic

    public RangedValue<double>? RevenueGrowth1Year { get; set; }
    public RangedValue<double>? RevenueGrowth5Year { get; set; }
    public RangedValue<double>? EpsGrowth1Year { get; set; }
    public RangedValue<double>? EpsGrowth5Year { get; set; }

    #endregion

    #region Dividend

    public RangedValue<DateTime>? NextDividend { get; set; }

    #endregion
    
}

