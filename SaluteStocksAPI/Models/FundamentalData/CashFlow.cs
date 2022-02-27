using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SaluteStocksAPI.DataBase;

namespace SaluteStocksAPI.Models.FundamentalData;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class CashFlow : CompanyEntityInfo
{
    [JsonProperty("annualReports")] public List<CashFlowAnnualReport> AnnualReports { get; set; }

    [JsonProperty("quarterlyReports")] public List<CashFlowQuarterlyReport> QuarterlyReports { get; set; }
}

public class CashFlowReport
{
    [JsonIgnore]
    [Key]
    public int Id { get; set; }
    
    public string Symbol { get; set; }
    
    [JsonIgnore]
    public CashFlow CashFlow { get; set; }
    
    [JsonProperty("fiscalDateEnding")] public string FiscalDateEnding { get; set; }

    [JsonProperty("reportedCurrency")] public string ReportedCurrency { get; set; }
    /// <summary>
    /// Сумма притока (оттока) денежных средств от операционной деятельности, включая прекращенную деятельность. Денежные потоки от операционной деятельности включают операции, корректировки и изменения стоимости, не определяемые как инвестиционная или финансовая деятельность.
    /// </summary>
    [JsonProperty("operatingCashflow")] public long? OperatingCashFlow { get; set; }

    /// <summary>
    /// Общая сумма денежных средств, выплаченных за операционную деятельность в текущем периоде.
    /// </summary>
    [JsonProperty("paymentsForOperatingActivities")]
    public long? PaymentsForOperatingActivities { get; set; }

    /// <summary>
    /// Общая сумма денежных средств, полученных от операционной деятельности в текущем периоде.
    /// </summary>
    [JsonProperty("proceedsFromOperatingActivities")]
    public long? ProceedsFromOperatingActivities { get; set; }

    /// <summary>
    /// Увеличение (уменьшение) в течение отчетного периода совокупной суммы обязательств, возникающих в результате деятельности, приносящей операционный доход.
    /// </summary>
    [JsonProperty("changeInOperatingLiabilities")]
    public long? ChangeInOperatingLiabilities { get; set; }

    /// <summary>
    /// Увеличение (уменьшение) в течение отчетного периода совокупной суммы активов, используемых для получения операционных доходов.
    /// </summary>
    [JsonProperty("changeInOperatingAssets")]
    public long? ChangeInOperatingAssets { get; set; }

    /// <summary>
    /// Совокупный расход, признанный в текущем периоде, который распределяет стоимость материальных активов, нематериальных активов или истощающихся активов на периоды, которые получают выгоду от использования активов.
    /// </summary>
    [JsonProperty("depreciationDepletionAndAmortization")]
    public long? DepreciationDepletionAndAmortization { get; set; }

    /// <summary>
    /// Отток денежных средств на приобретение и капитальный ремонт основных средств (капитальные затраты), программного обеспечения и других нематериальных активов.
    /// </summary>
    [JsonProperty("capitalExpenditures")] public long? CapitalExpenditures { get; set; }

    /// <summary>
    /// Увеличение (уменьшение) в течение отчетного периода общей суммы к оплате в течение одного года (или одного операционного цикла) со всех сторон, связанное с лежащими в основе операциями, классифицируемыми как операционная деятельность.
    /// </summary>
    [JsonProperty("changeInReceivables")] public long? ChangeInReceivables { get; set; }

    /// <summary>
    /// Увеличение (уменьшение) в течение отчетного периода совокупной стоимости всех товарно-материальных запасов, имеющихся у отчитывающейся организации, связанное с базовыми операциями, классифицируемыми как операционная деятельность.
    /// </summary>
    [JsonProperty("changeInInventory")] public long? ChangeInInventory { get; set; }

    /// <summary>
    /// Консолидированная прибыль или убыток за период за вычетом налога на прибыль, включая часть, относящуюся к неконтролирующей доле участия.
    /// </summary>
    [JsonProperty("profitLoss")] public long? ProfitLoss { get; set; }

    /// <summary>
    /// Сумма притока (оттока) денежных средств от инвестиционной деятельности, включая прекращенную деятельность. Денежные потоки от инвестиционной деятельности включают в себя выдачу и получение кредитов, а также приобретение и продажу долговых или долевых инструментов, а также основных средств и других производственных активов.
    /// </summary>
    [JsonProperty("cashflowFromInvestment")]
    public long? CashflowFromInvestment { get; set; }

    /// <summary>
    /// Сумма притока (оттока) денежных средств от финансовой деятельности, включая прекращенную деятельность. Денежные потоки от финансовой деятельности включают в себя получение ресурсов от собственников и предоставление им дохода и возврата их инвестиций; заимствование денег и погашение заемных сумм или погашение обязательства; получение и оплата других ресурсов, полученных от кредиторов по долгосрочному кредиту.
    /// </summary>
    [JsonProperty("cashflowFromFinancing")]
    public long? CashflowFromFinancing { get; set; }

    /// <summary>
    /// Чистый приток или отток денежных средств по займам с первоначальным сроком погашения в течение одного года или обычного операционного цикла, если он дольше.
    /// </summary>
    [JsonProperty("proceedsFromRepaymentsOfShortTermDebt")]
    public long? ProceedsFromRepaymentsOfShortTermDebt { get; set; }

    /// <summary>
    /// Отток денежных средств для выкупа обыкновенных акций в течение периода.
    /// </summary>
    [JsonProperty("paymentsForRepurchaseOfCommonStock")]
    public long? PaymentsForRepurchaseOfCommonStock { get; set; }

    /// <summary>
    /// Отток денежных средств для выкупа обыкновенных и привилегированных акций.
    /// </summary>
    [JsonProperty("paymentsForRepurchaseOfEquity")]
    public long? PaymentsForRepurchaseOfEquity { get; set; }

    /// <summary>
    /// Отток денежных средств для повторного приобретения привилегированных акций в течение периода.
    /// </summary>
    [JsonProperty("paymentsForRepurchaseOfPreferredStock")]
    public long? PaymentsForRepurchaseOfPreferredStock { get; set; }

    /// <summary>
    /// Отток денежных средств в виде распределения капитала и дивидендов владельцам обыкновенных акций, владельцев привилегированных акций и неконтролирующих долей участия.
    /// </summary>
    [JsonProperty("dividendPayout")] public long? DividendPayout { get; set; }

    /// <summary>
    /// Сумма оттока денежных средств в виде дивидендов по обыкновенным обыкновенным акциям материнской компании.
    /// </summary>
    [JsonProperty("dividendPayoutCommonStock")]
    public long? DividendPayoutCommonStock { get; set; }

    /// <summary>
    /// Сумма оттока денежных средств в виде обыкновенных дивидендов держателям привилегированных акций материнской компании.
    /// </summary>
    [JsonProperty("dividendPayoutPreferredStock")]
    public long? DividendPayoutPreferredStock { get; set; }

    /// <summary>
    /// Приток денежных средств от дополнительного вклада в капитал предприятия.
    /// </summary>
    [JsonProperty("proceedsFromIssuanceOfCommonStock")]
    public long? ProceedsFromIssuanceOfCommonStock { get; set; }

    /// <summary>
    /// Приток денежных средств, связанный с ценным инструментом, который либо представляет кредитора, либо отношения собственности с держателем инвестиционной ценной бумаги со сроком погашения более одного года или обычного операционного цикла, если он дольше. Включает поступления от (а) долга, (б) обязательств по капитальной аренде, (в) обязательных погашаемых капитальных ценных бумаг и (г) любой комбинации (а), (б) или (в).
    /// </summary>
    [JsonProperty("proceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet")]
    public long? ProceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet { get; set; }

    /// <summary>
    /// Доходы от выпуска акций, предусматривающих выплату определенного дивиденда акционерам до любых дивидендов держателю обыкновенных акций, который имеет преимущество перед держателями обыкновенных акций в случае ликвидации, и от предоставления прав на покупку обыкновенных акций по заранее установленной цене.
    /// </summary>
    [JsonProperty("proceedsFromIssuanceOfPreferredStock")]
    public long? ProceedsFromIssuanceOfPreferredStock { get; set; }

    /// <summary>
    /// Чистый приток или отток денежных средств в результате операции с акциями предприятия.
    /// </summary>
    [JsonProperty("proceedsFromRepurchaseOfEquity")]
    public long? ProceedsFromRepurchaseOfEquity { get; set; }

    /// <summary>
    /// Приток денежных средств от выпуска акций, которые ранее были выкуплены организацией.
    /// </summary>
    [JsonProperty("proceedsFromSaleOfTreasuryStock")]
    public long? ProceedsFromSaleOfTreasuryStock { get; set; }

    /// <summary>
    /// Сумма увеличения (уменьшения) денежных средств и их эквивалентов. Денежные средства и их эквиваленты представляют собой сумму наличной валюты, а также депозиты до востребования в банках или финансовых учреждениях. Включает другие виды счетов, которые имеют общие характеристики депозитов до востребования. Также включает краткосрочные, высоколиквидные инвестиции, которые легко конвертируются в известные суммы денежных средств и настолько близки к сроку погашения, что представляют незначительный риск изменения стоимости из-за изменений процентных ставок. Включает эффект от изменения обменного курса.
    /// </summary>
    [JsonProperty("changeInCashAndCashEquivalents")]
    public long? ChangeInCashAndCashEquivalents { get; set; }

    /// <summary>
    /// Сумма увеличения (уменьшения) под влиянием изменения обменного курса денежных средств и их эквивалентов в иностранной валюте.
    /// </summary>
    [JsonProperty("changeInExchangeRate")] public long? ChangeInExchangeRate { get; set; }

    /// <summary>
    /// Часть прибыли или убытка за период за вычетом налога на прибыль, приходящаяся на материнскую компанию.
    /// </summary>
    [JsonProperty("netIncome")] public long? NetIncome { get; set; }
}

public class CashFlowAnnualReport : CashFlowReport
{
    
}

public class CashFlowQuarterlyReport : CashFlowReport
{
    
}