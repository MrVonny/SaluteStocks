using System.Collections.Generic;
using Newtonsoft.Json;
using SaluteStocksAPI.Models.FundamentalData.Common;

namespace SaluteStocksAPI.Models.FundamentalData;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class BalanceSheet
{
    /// <summary>
    /// e.g. SBER, AAPL, IBM, YDX.FRK
    /// </summary>
    
    [JsonProperty("symbol")] public string Symbol { get; set; }
    
    
    
    [JsonProperty("annualReports")] public List<BalanceSheetReport> AnnualReports { get; set; }

    [JsonProperty("quarterlyReports")] public List<BalanceSheetReport> QuarterlyReports { get; set; }
}

public class BalanceSheetReport : Report
{
    // https://documentation.alphavantage.co/FundamentalDataDocs/gaap_documentation.html#BalanceSheet
    /// <summary>
    /// полная балансовая стоимость на данный момент
    /// </summary>
    [JsonProperty("totalAssets")] public ulong TotalAssets { get; set; }
    
    /// <summary>
    /// балансовая стоимость, запланированная быть потраченной в течении года
    /// </summary>
    [JsonProperty("totalCurrentAssets")] public ulong TotalCurrentAssets { get; set; }
    
    /// <summary>
    /// Количество наличной валюты, а также депозиты до востребования в банках или финансовых учреждениях. Включает другие виды счетов, которые имеют общие характеристики депозитов до востребования.
    /// </summary>
    [JsonProperty("cashAndCashEquivalentsAtCarryingValue")]
    public ulong CashAndCashEquivalentsAtCarryingValue { get; set; }
    
    /// <summary>
    /// Денежные средства включают валюту в кассе, а также депозиты до востребования в банках или финансовых учреждениях. Он также включает другие виды счетов, которые имеют общие характеристики депозитов до востребования в том смысле, что клиент может вносить дополнительные средства в любое время и фактически может снимать средства в любое время без предварительного уведомления или штрафа.
    /// </summary>
    [JsonProperty("cashAndShortTermInvestments")] public ulong CashAndShortTermInvestments { get; set; }
    
    /// <summary>
    /// Сумма запасов после оценки и LIFO, которая, как ожидается, будет продана или потреблена в течение одного года или операционного цикла, если он дольше.
    /// </summary>
    [JsonProperty("inventory")] public ulong Inventory { get; set; }
    
    /// <summary>
    /// Общая сумма, причитающаяся предприятию в течение одного года с отчетной даты (или одного операционного цикла, если он дольше) из внешних источников, включая торговую дебиторскую задолженность, векселя и ссуды к получению, а также любые другие виды дебиторской задолженности, за вычетом резервов устанавливается с целью сокращения такой дебиторской задолженности до суммы, приблизительно равной ее чистой стоимости реализации.
    /// </summary>
    [JsonProperty("currentNetReceivables")] public ulong CurrentNetReceivables { get; set; }

    /// <summary>
    /// Сумма балансовой стоимости на отчетную дату всех активов, которые, как ожидается, будут реализованы в виде денежных средств, проданы или потреблены через один год или по истечении обычного операционного цикла, если он дольше.
    /// </summary>
    [JsonProperty("totalNonCurrentAssets")]
    public ulong TotalNonCurrentAssets { get; set; }

    /// <summary>
    /// Сумма после накопленного износа, истощения и амортизации материальных активов, используемых в ходе обычной деятельности для производства товаров и услуг и не предназначенных для перепродажи. Примеры включают, помимо прочего, землю, здания, машины и оборудование, офисное оборудование, а также мебель и приспособления.
    /// </summary>
    [JsonProperty("propertyPlantEquipment")]
    public ulong PropertyPlantEquipment { get; set; }

    /// <summary>
    /// Сумма накопленного износа, истощения и амортизации физических активов, используемых в ходе обычной деятельности для производства товаров и услуг.
    /// </summary>
    [JsonProperty("accumulatedDepreciationAmortizationPPE")]
    public ulong AccumulatedDepreciationAmortizationPPE { get; set; }
    
    /// <summary>
    /// Балансовая стоимость нематериальных активов с ограниченным сроком службы, нематериальных активов с неопределенным сроком службы и деловой репутации. Деловая репутация представляет собой актив, представляющий собой будущие экономические выгоды от других активов, приобретенных при объединении бизнеса, которые не идентифицируются и не признаются отдельно. Нематериальные активы – это активы, не включающие финансовые активы, не имеющие физического содержания.
    /// </summary>
    [JsonProperty("intangibleAssets")] public ulong IntangibleAssets { get; set; }

    /// <summary>
    /// Сумма балансовой стоимости всех нематериальных активов, за исключением деловой репутации, на отчетную дату за вычетом накопленной амортизации и обесценения.
    /// </summary>
    [JsonProperty("intangibleAssetsExcludingGoodwill")]
    public ulong IntangibleAssetsExcludingGoodwill { get; set; }

    /// <summary>
    /// Сумма после накопленного убытка от обесценения актива, представляющая будущие экономические выгоды от других активов, приобретенных при объединении бизнеса, которые не идентифицируются и не признаются отдельно.
    /// </summary>
    [JsonProperty("goodwill")] public ulong Goodwill { get; set; }

    /// <summary>
    /// Сумма балансовой стоимости на отчетную дату всех инвестиций.
    /// </summary>
    [JsonProperty("investments")] public ulong Investments { get; set; }

    /// <summary>
    /// Общая сумма инвестиций, которые предполагается удерживать в течение длительного периода времени (дольше одного операционного цикла).
    /// </summary>
    [JsonProperty("longTermInvestments")] public ulong LongTermInvestments { get; set; }

    /// <summary>
    /// Сумма инвестиций, включая торговые ценные бумаги, ценные бумаги, имеющиеся в наличии для продажи, ценные бумаги, удерживаемые до погашения, и краткосрочные инвестиции, классифицируемые как прочие и краткосрочные.
    /// </summary>
    [JsonProperty("shortTermInvestments")] public ulong ShortTermInvestments { get; set; }

    /// <summary>
    /// Сумма оборотных активов, классифицированных как прочие.
    /// </summary>
    [JsonProperty("otherCurrentAssets")] public ulong OtherCurrentAssets { get; set; }

    /// <summary>
    /// Сумма внеоборотных активов, отнесенных к прочим.
    /// </summary>
    [JsonProperty("otherNonCurrrentAssets")]
    public long OtherNonCurrentAssets { get; set; }

    /// <summary>
    /// Сумма балансовой стоимости всех признанных обязательств на отчетную дату. Обязательства представляют собой вероятные будущие потери экономических выгод, возникающие в результате текущих обязательств предприятия по передаче активов или оказанию услуг другим предприятиям в будущем.
    /// </summary>
    [JsonProperty("totalLiabilities")] public ulong TotalLiabilities { get; set; }

    /// <summary>
    /// Общая сумма обязательств, возникших в рамках обычной деятельности, которые, как ожидается, будут погашены в течение следующих двенадцати месяцев или в течение одного бизнес-цикла, если он дольше.
    /// </summary>
    [JsonProperty("totalCurrentLiabilities")]
    public ulong TotalCurrentLiabilities { get; set; }

    /// <summary>
    /// Балансовая стоимость на отчетную дату принятых обязательств (и по которым обычно выставляются счета-фактуры) и подлежащих уплате поставщикам за полученные товары и услуги, которые используются в бизнесе предприятия. Используется для отражения текущей части обязательств (со сроком погашения в течение одного года или в течение обычного операционного цикла, если он дольше).
    /// </summary>
    [JsonProperty("currentAccountsPayable")]
    public ulong CurrentAccountsPayable { get; set; }

    /// <summary>
    /// Сумма доходов будущих периодов и обязательств по передаче продукции и услуг покупателю, за которые было получено или подлежит получению возмещение.
    /// </summary>
    [JsonProperty("deferredRevenue")] public ulong DeferredRevenue { get; set; }

    /// <summary>
    /// Сумма краткосрочной задолженности и текущий срок погашения долгосрочной задолженности и обязательств по капитальной аренде, подлежащих погашению в течение одного года или обычного операционного цикла, если он дольше.
    /// </summary>
    [JsonProperty("currentDebt")] public ulong CurrentDebt { get; set; }

    /// <summary>
    /// Отражает общую балансовую стоимость на отчетную дату долга с первоначальным сроком погашения менее одного года или обычного операционного цикла, если он дольше.
    /// </summary>
    [JsonProperty("shortTermDebt")] public ulong ShortTermDebt { get; set; }

    /// <summary>
    /// Сумма обязательства, подлежащего погашению по истечении одного года или сверх обычного операционного цикла, если он дольше.
    /// </summary>
    [JsonProperty("totalNonCurrentLiabilities")]
    public ulong TotalNonCurrentLiabilities { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("capitalLeaseObligations")]
    public ulong CapitalLeaseObligations { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("longTermDebt")] public ulong LongTermDebt { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("currentLongTermDebt")] public ulong CurrentLongTermDebt { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("longTermDebtNoncurrent")]
    public ulong LongTermDebtNoncurrent { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("shortLongTermDebtTotal")]
    public ulong ShortLongTermDebtTotal { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("otherCurrentLiabilities")]
    public ulong OtherCurrentLiabilities { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("otherNonCurrentLiabilities")]
    public ulong OtherNonCurrentLiabilities { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("totalShareholderEquity")]
    public ulong TotalShareholderEquity { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("treasuryStock")] public ulong TreasuryStock { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("retainedEarnings")] public ulong RetainedEarnings { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("commonStock")] public ulong CommonStock { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("commonStockSharesOutstanding")]
    public ulong CommonStockSharesOutstanding { get; set; }
}