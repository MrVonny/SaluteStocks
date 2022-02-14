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
    [JsonProperty("operatingCashflow")] public long OperatingCashFlow { get; set; }

    [JsonProperty("paymentsForOperatingActivities")]
    public long PaymentsForOperatingActivities { get; set; }

    [JsonProperty("proceedsFromOperatingActivities")]
    public long ProceedsFromOperatingActivities { get; set; }

    [JsonProperty("changeInOperatingLiabilities")]
    public long ChangeInOperatingLiabilities { get; set; }

    [JsonProperty("changeInOperatingAssets")]
    public long ChangeInOperatingAssets { get; set; }

    [JsonProperty("depreciationDepletionAndAmortization")]
    public long DepreciationDepletionAndAmortization { get; set; }

    [JsonProperty("capitalExpenditures")] public long CapitalExpenditures { get; set; }

    [JsonProperty("changeInReceivables")] public long ChangeInReceivables { get; set; }

    [JsonProperty("changeInInventory")] public long ChangeInInventory { get; set; }

    [JsonProperty("profitLoss")] public long ProfitLoss { get; set; }

    [JsonProperty("cashflowFromInvestment")]
    public long CashflowFromInvestment { get; set; }

    [JsonProperty("cashflowFromFinancing")]
    public long CashflowFromFinancing { get; set; }

    [JsonProperty("proceedsFromRepaymentsOfShortTermDebt")]
    public long ProceedsFromRepaymentsOfShortTermDebt { get; set; }

    [JsonProperty("paymentsForRepurchaseOfCommonStock")]
    public long PaymentsForRepurchaseOfCommonStock { get; set; }

    [JsonProperty("paymentsForRepurchaseOfEquity")]
    public long PaymentsForRepurchaseOfEquity { get; set; }

    [JsonProperty("paymentsForRepurchaseOfPreferredStock")]
    public long PaymentsForRepurchaseOfPreferredStock { get; set; }

    [JsonProperty("dividendPayout")] public long DividendPayout { get; set; }

    [JsonProperty("dividendPayoutCommonStock")]
    public long DividendPayoutCommonStock { get; set; }

    [JsonProperty("dividendPayoutPreferredStock")]
    public long DividendPayoutPreferredStock { get; set; }

    [JsonProperty("proceedsFromIssuanceOfCommonStock")]
    public long ProceedsFromIssuanceOfCommonStock { get; set; }

    [JsonProperty("proceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet")]
    public long ProceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet { get; set; }

    [JsonProperty("proceedsFromIssuanceOfPreferredStock")]
    public long ProceedsFromIssuanceOfPreferredStock { get; set; }

    [JsonProperty("proceedsFromRepurchaseOfEquity")]
    public long ProceedsFromRepurchaseOfEquity { get; set; }

    [JsonProperty("proceedsFromSaleOfTreasuryStock")]
    public long ProceedsFromSaleOfTreasuryStock { get; set; }

    [JsonProperty("changeInCashAndCashEquivalents")]
    public long ChangeInCashAndCashEquivalents { get; set; }

    [JsonProperty("changeInExchangeRate")] public long ChangeInExchangeRate { get; set; }

    [JsonProperty("netIncome")] public long NetIncome { get; set; }
}