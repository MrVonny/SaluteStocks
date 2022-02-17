namespace SaluteStocksAPI.Screener;

public class Screener
{
    #region Common

    public string Currency { get; set; }
    public string Sector { get; set; }
    public string Country { get; set; }
    
    #endregion

    #region Financial

    public RangedValue<decimal>? MarketCap { get; set; }
    public RangedValue<decimal>? Ebitda { get; set; }
    public RangedValue<decimal>? DebtEquity { get; set; }
    public RangedValue<decimal>? PERatio { get; set; }
    public RangedValue<decimal>? EPS { get; set; }
    public RangedValue<decimal>? Beta { get; set; }

    #endregion

    #region Dynamic

    public RangedValue<decimal>? RevenueGrowth1Year { get; set; }
    public RangedValue<decimal>? RevenueGrowth5Year { get; set; }
    public RangedValue<decimal>? EpsGrowth1Year { get; set; }
    public RangedValue<decimal>? EpsGrowth5Year { get; set; }

    #endregion

    #region Dividend

    public RangedValue<DateTime>? NextDividend { get; set; }

    #endregion
    
}

