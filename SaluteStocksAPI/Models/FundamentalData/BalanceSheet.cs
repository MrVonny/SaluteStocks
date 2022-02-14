using System.Collections.Generic;
using Newtonsoft.Json;
using SaluteStocksAPI.Models.FundamentalData.Common;

namespace SaluteStocksAPI.Models.FundamentalData;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class BalanceSheet
{
    [JsonProperty("symbol")] public string Symbol { get; set; }

    [JsonProperty("annualReports")] public List<BalanceSheetReport> AnnualReports { get; set; }

    [JsonProperty("quarterlyReports")] public List<BalanceSheetReport> QuarterlyReports { get; set; }
}

public class BalanceSheetReport : Report
{
    [JsonProperty("totalAssets")] public string TotalAssets { get; set; }

    [JsonProperty("totalCurrentAssets")] public string TotalCurrentAssets { get; set; }

    [JsonProperty("cashAndCashEquivalentsAtCarryingValue")]
    public string CashAndCashEquivalentsAtCarryingValue { get; set; }

    [JsonProperty("cashAndShortTermInvestments")]
    public string CashAndShortTermInvestments { get; set; }

    [JsonProperty("inventory")] public string Inventory { get; set; }

    [JsonProperty("currentNetReceivables")]
    public string CurrentNetReceivables { get; set; }

    [JsonProperty("totalNonCurrentAssets")]
    public string TotalNonCurrentAssets { get; set; }

    [JsonProperty("propertyPlantEquipment")]
    public string PropertyPlantEquipment { get; set; }

    [JsonProperty("accumulatedDepreciationAmortizationPPE")]
    public string AccumulatedDepreciationAmortizationPPE { get; set; }

    [JsonProperty("intangibleAssets")] public string IntangibleAssets { get; set; }

    [JsonProperty("intangibleAssetsExcludingGoodwill")]
    public string IntangibleAssetsExcludingGoodwill { get; set; }

    [JsonProperty("goodwill")] public string Goodwill { get; set; }

    [JsonProperty("investments")] public string Investments { get; set; }

    [JsonProperty("longTermInvestments")] public string LongTermInvestments { get; set; }

    [JsonProperty("shortTermInvestments")] public string ShortTermInvestments { get; set; }

    [JsonProperty("otherCurrentAssets")] public string OtherCurrentAssets { get; set; }

    [JsonProperty("otherNonCurrrentAssets")]
    public string OtherNonCurrentAssets { get; set; }

    [JsonProperty("totalLiabilities")] public string TotalLiabilities { get; set; }

    [JsonProperty("totalCurrentLiabilities")]
    public string TotalCurrentLiabilities { get; set; }

    [JsonProperty("currentAccountsPayable")]
    public string CurrentAccountsPayable { get; set; }

    [JsonProperty("deferredRevenue")] public string DeferredRevenue { get; set; }

    [JsonProperty("currentDebt")] public string CurrentDebt { get; set; }

    [JsonProperty("shortTermDebt")] public string ShortTermDebt { get; set; }

    [JsonProperty("totalNonCurrentLiabilities")]
    public string TotalNonCurrentLiabilities { get; set; }

    [JsonProperty("capitalLeaseObligations")]
    public string CapitalLeaseObligations { get; set; }

    [JsonProperty("longTermDebt")] public string LongTermDebt { get; set; }

    [JsonProperty("currentLongTermDebt")] public string CurrentLongTermDebt { get; set; }

    [JsonProperty("longTermDebtNoncurrent")]
    public string LongTermDebtNoncurrent { get; set; }

    [JsonProperty("shortLongTermDebtTotal")]
    public string ShortLongTermDebtTotal { get; set; }

    [JsonProperty("otherCurrentLiabilities")]
    public string OtherCurrentLiabilities { get; set; }

    [JsonProperty("otherNonCurrentLiabilities")]
    public string OtherNonCurrentLiabilities { get; set; }

    [JsonProperty("totalShareholderEquity")]
    public string TotalShareholderEquity { get; set; }

    [JsonProperty("treasuryStock")] public string TreasuryStock { get; set; }

    [JsonProperty("retainedEarnings")] public string RetainedEarnings { get; set; }

    [JsonProperty("commonStock")] public string CommonStock { get; set; }

    [JsonProperty("commonStockSharesOutstanding")]
    public string CommonStockSharesOutstanding { get; set; }
}