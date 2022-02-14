using System.Collections.Generic;
using Newtonsoft.Json;
using SaluteStocksAPI.Models.FundamentalData.Common;

namespace SaluteStocksAPI.Models.FundamentalData;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class CashFlow
{
    [JsonProperty("symbol")] public string Symbol { get; set; }

    [JsonProperty("annualReports")] public List<CashFlowReport> AnnualReports { get; set; }

    [JsonProperty("quarterlyReports")] public List<CashFlowReport> QuarterlyReports { get; set; }
}

public class CashFlowReport : Report
{
    [JsonProperty("operatingCashflow")] public string OperatingCashFlow { get; set; }

    [JsonProperty("paymentsForOperatingActivities")]
    public string PaymentsForOperatingActivities { get; set; }

    [JsonProperty("proceedsFromOperatingActivities")]
    public string ProceedsFromOperatingActivities { get; set; }

    [JsonProperty("changeInOperatingLiabilities")]
    public string ChangeInOperatingLiabilities { get; set; }

    [JsonProperty("changeInOperatingAssets")]
    public string ChangeInOperatingAssets { get; set; }

    [JsonProperty("depreciationDepletionAndAmortization")]
    public string DepreciationDepletionAndAmortization { get; set; }

    [JsonProperty("capitalExpenditures")] public string CapitalExpenditures { get; set; }

    [JsonProperty("changeInReceivables")] public string ChangeInReceivables { get; set; }

    [JsonProperty("changeInInventory")] public string ChangeInInventory { get; set; }

    [JsonProperty("profitLoss")] public string ProfitLoss { get; set; }

    [JsonProperty("cashflowFromInvestment")]
    public string CashflowFromInvestment { get; set; }

    [JsonProperty("cashflowFromFinancing")]
    public string CashflowFromFinancing { get; set; }

    [JsonProperty("proceedsFromRepaymentsOfShortTermDebt")]
    public string ProceedsFromRepaymentsOfShortTermDebt { get; set; }

    [JsonProperty("paymentsForRepurchaseOfCommonStock")]
    public string PaymentsForRepurchaseOfCommonStock { get; set; }

    [JsonProperty("paymentsForRepurchaseOfEquity")]
    public string PaymentsForRepurchaseOfEquity { get; set; }

    [JsonProperty("paymentsForRepurchaseOfPreferredStock")]
    public string PaymentsForRepurchaseOfPreferredStock { get; set; }

    [JsonProperty("dividendPayout")] public string DividendPayout { get; set; }

    [JsonProperty("dividendPayoutCommonStock")]
    public string DividendPayoutCommonStock { get; set; }

    [JsonProperty("dividendPayoutPreferredStock")]
    public string DividendPayoutPreferredStock { get; set; }

    [JsonProperty("proceedsFromIssuanceOfCommonStock")]
    public string ProceedsFromIssuanceOfCommonStock { get; set; }

    [JsonProperty("proceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet")]
    public string ProceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet { get; set; }

    [JsonProperty("proceedsFromIssuanceOfPreferredStock")]
    public string ProceedsFromIssuanceOfPreferredStock { get; set; }

    [JsonProperty("proceedsFromRepurchaseOfEquity")]
    public string ProceedsFromRepurchaseOfEquity { get; set; }

    [JsonProperty("proceedsFromSaleOfTreasuryStock")]
    public string ProceedsFromSaleOfTreasuryStock { get; set; }

    [JsonProperty("changeInCashAndCashEquivalents")]
    public string ChangeInCashAndCashEquivalents { get; set; }

    [JsonProperty("changeInExchangeRate")] public string ChangeInExchangeRate { get; set; }

    [JsonProperty("netIncome")] public string NetIncome { get; set; }
}