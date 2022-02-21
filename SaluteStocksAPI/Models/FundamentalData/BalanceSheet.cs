using System.Collections.Generic;
using Newtonsoft.Json;
using SaluteStocksAPI.DataBase;
using SaluteStocksAPI.Models.FundamentalData.Common;

namespace SaluteStocksAPI.Models.FundamentalData;
#nullable enable
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class BalanceSheet : EntityInfo
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
    [JsonProperty("totalAssets")] public long? TotalAssets { get; set; }
    
    /// <summary>
    /// балансовая стоимость, запланированная быть потраченной в течении года
    /// </summary>
    [JsonProperty("totalCurrentAssets")] public long? TotalCurrentAssets { get; set; }
    
    /// <summary>
    /// Количество наличной валюты, а также депозиты до востребования в банках или финансовых учреждениях. Включает другие виды счетов, которые имеют общие характеристики депозитов до востребования.
    /// </summary>
    [JsonProperty("cashAndCashEquivalentsAtCarryingValue")]
    public long? CashAndCashEquivalentsAtCarryingValue { get; set; }
    
    /// <summary>
    /// Денежные средства включают валюту в кассе, а также депозиты до востребования в банках или финансовых учреждениях. Он также включает другие виды счетов, которые имеют общие характеристики депозитов до востребования в том смысле, что клиент может вносить дополнительные средства в любое время и фактически может снимать средства в любое время без предварительного уведомления или штрафа.
    /// </summary>
    [JsonProperty("cashAndShortTermInvestments")] public long? CashAndShortTermInvestments { get; set; }
    
    /// <summary>
    /// Сумма запасов после оценки и LIFO, которая, как ожидается, будет продана или потреблена в течение одного года или операционного цикла, если он дольше.
    /// </summary>
    [JsonProperty("inventory")] public long? Inventory { get; set; }
    
    /// <summary>
    /// Общая сумма, причитающаяся предприятию в течение одного года с отчетной даты (или одного операционного цикла, если он дольше) из внешних источников, включая торговую дебиторскую задолженность, векселя и ссуды к получению, а также любые другие виды дебиторской задолженности, за вычетом резервов устанавливается с целью сокращения такой дебиторской задолженности до суммы, приблизительно равной ее чистой стоимости реализации.
    /// </summary>
    [JsonProperty("currentNetReceivables")] public long? CurrentNetReceivables { get; set; }

    /// <summary>
    /// Сумма балансовой стоимости на отчетную дату всех активов, которые, как ожидается, будут реализованы в виде денежных средств, проданы или потреблены через один год или по истечении обычного операционного цикла, если он дольше.
    /// </summary>
    [JsonProperty("totalNonCurrentAssets")]
    public long? TotalNonCurrentAssets { get; set; }

    /// <summary>
    /// Сумма после накопленного износа, истощения и амортизации материальных активов, используемых в ходе обычной деятельности для производства товаров и услуг и не предназначенных для перепродажи. Примеры включают, помимо прочего, землю, здания, машины и оборудование, офисное оборудование, а также мебель и приспособления.
    /// </summary>
    [JsonProperty("propertyPlantEquipment")]
    public long? PropertyPlantEquipment { get; set; }

    /// <summary>
    /// Сумма накопленного износа, истощения и амортизации физических активов, используемых в ходе обычной деятельности для производства товаров и услуг.
    /// </summary>
    [JsonProperty("accumulatedDepreciationAmortizationPPE")]
    public long? AccumulatedDepreciationAmortizationPPE { get; set; }
    
    /// <summary>
    /// Балансовая стоимость нематериальных активов с ограниченным сроком службы, нематериальных активов с неопределенным сроком службы и деловой репутации. Деловая репутация представляет собой актив, представляющий собой будущие экономические выгоды от других активов, приобретенных при объединении бизнеса, которые не идентифицируются и не признаются отдельно. Нематериальные активы – это активы, не включающие финансовые активы, не имеющие физического содержания.
    /// </summary>
    [JsonProperty("intangibleAssets")] public long? IntangibleAssets { get; set; }

    /// <summary>
    /// Сумма балансовой стоимости всех нематериальных активов, за исключением деловой репутации, на отчетную дату за вычетом накопленной амортизации и обесценения.
    /// </summary>
    [JsonProperty("intangibleAssetsExcludingGoodwill")]
    public long? IntangibleAssetsExcludingGoodwill { get; set; }

    /// <summary>
    /// Сумма после накопленного убытка от обесценения актива, представляющая будущие экономические выгоды от других активов, приобретенных при объединении бизнеса, которые не идентифицируются и не признаются отдельно.
    /// </summary>
    [JsonProperty("goodwill")] public long? Goodwill { get; set; }

    /// <summary>
    /// Сумма балансовой стоимости на отчетную дату всех инвестиций.
    /// </summary>
    [JsonProperty("investments")] public long? Investments { get; set; }

    /// <summary>
    /// Общая сумма инвестиций, которые предполагается удерживать в течение длительного периода времени (дольше одного операционного цикла).
    /// </summary>
    [JsonProperty("longTermInvestments")] public long? LongTermInvestments { get; set; }

    /// <summary>
    /// Сумма инвестиций, включая торговые ценные бумаги, ценные бумаги, имеющиеся в наличии для продажи, ценные бумаги, удерживаемые до погашения, и краткосрочные инвестиции, классифицируемые как прочие и краткосрочные.
    /// </summary>
    [JsonProperty("shortTermInvestments")] public long? ShortTermInvestments { get; set; }

    /// <summary>
    /// Сумма оборотных активов, классифицированных как прочие.
    /// </summary>
    [JsonProperty("otherCurrentAssets")] public long? OtherCurrentAssets { get; set; }

    /// <summary>
    /// Сумма внеоборотных активов, отнесенных к прочим.
    /// </summary>
    [JsonProperty("otherNonCurrrentAssets")]
    public long? OtherNonCurrentAssets { get; set; }

    /// <summary>
    /// Сумма балансовой стоимости всех признанных обязательств на отчетную дату. Обязательства представляют собой вероятные будущие потери экономических выгод, возникающие в результате текущих обязательств предприятия по передаче активов или оказанию услуг другим предприятиям в будущем.
    /// </summary>
    [JsonProperty("totalLiabilities")] public long? TotalLiabilities { get; set; }

    /// <summary>
    /// Общая сумма обязательств, возникших в рамках обычной деятельности, которые, как ожидается, будут погашены в течение следующих двенадцати месяцев или в течение одного бизнес-цикла, если он дольше.
    /// </summary>
    [JsonProperty("totalCurrentLiabilities")]
    public long? TotalCurrentLiabilities { get; set; }

    /// <summary>
    /// Балансовая стоимость на отчетную дату принятых обязательств (и по которым обычно выставляются счета-фактуры) и подлежащих уплате поставщикам за полученные товары и услуги, которые используются в бизнесе предприятия. Используется для отражения текущей части обязательств (со сроком погашения в течение одного года или в течение обычного операционного цикла, если он дольше).
    /// </summary>
    [JsonProperty("currentAccountsPayable")]
    public long? CurrentAccountsPayable { get; set; }

    /// <summary>
    /// Сумма доходов будущих периодов и обязательств по передаче продукции и услуг покупателю, за которые было получено или подлежит получению возмещение.
    /// </summary>
    [JsonProperty("deferredRevenue")] public long? DeferredRevenue { get; set; }

    /// <summary>
    /// Сумма краткосрочной задолженности и текущий срок погашения долгосрочной задолженности и обязательств по капитальной аренде, подлежащих погашению в течение одного года или обычного операционного цикла, если он дольше.
    /// </summary>
    [JsonProperty("currentDebt")] public long? CurrentDebt { get; set; }

    /// <summary>
    /// Отражает общую балансовую стоимость на отчетную дату долга с первоначальным сроком погашения менее одного года или обычного операционного цикла, если он дольше.
    /// </summary>
    [JsonProperty("shortTermDebt")] public long? ShortTermDebt { get; set; }

    /// <summary>
    /// Сумма обязательства, подлежащего погашению по истечении одного года или сверх обычного операционного цикла, если он дольше.
    /// </summary>
    [JsonProperty("totalNonCurrentLiabilities")]
    public long? TotalNonCurrentLiabilities { get; set; }

    /// <summary>
    /// Текущая стоимость дисконтированных обязательств арендатора по арендным платежам по финансовой аренде, классифицированных как долгосрочные.
    /// </summary>
    [JsonProperty("capitalLeaseObligations")]
    public long? CapitalLeaseObligations { get; set; }

    /// <summary>
    /// Сумма долгосрочного долга после неамортизированной (дисконтированной) премии и затрат на выпуск долговых обязательств. Включает, помимо прочего, векселя к оплате, облигации к оплате, долговые обязательства, ипотечные кредиты и коммерческие бумаги. Исключая обязательства по капитальной аренде.
    /// </summary>
    [JsonProperty("longTermDebt")] public long? LongTermDebt { get; set; }

    /// <summary>
    /// Сумма долгосрочной задолженности, классифицируемой как краткосрочная, после неамортизированной (дисконтированной) премии и затрат на выпуск долговых обязательств. Включает, помимо прочего, векселя к оплате, облигации к оплате, долговые обязательства, ипотечные кредиты и коммерческие бумаги. Исключая обязательства по капитальной аренде.
    /// </summary>
    [JsonProperty("currentLongTermDebt")] public long? CurrentLongTermDebt { get; set; }

    /// <summary>
    /// Сумма после неамортизированной (дисконтной) премии и затрат на выпуск долговых обязательств по долгосрочным долговым обязательствам, классифицируемым как долгосрочные, за исключением сумм, подлежащих погашению в течение одного года или обычного операционного цикла, если он дольше. Включает, помимо прочего, векселя к оплате, облигации к оплате, долговые обязательства, ипотечные кредиты и коммерческие бумаги. Исключая обязательства по капитальной аренде.
    /// </summary>
    [JsonProperty("longTermDebtNoncurrent")]
    public long? LongTermDebtNoncurrent { get; set; }

    /// <summary>
    /// не нашел на https://documentation.alphavantage.co/FundamentalDataDocs/gaap_documentation.html#BalanceSheet
    /// </summary>
    [JsonProperty("shortLongTermDebtTotal")]
    public long? ShortLongTermDebtTotal { get; set; }

    /// <summary>
    /// Сумма обязательств, классифицированных как прочие, со сроком погашения в течение одного года или обычного операционного цикла, если он дольше.
    /// </summary>
    [JsonProperty("otherCurrentLiabilities")]
    public long? OtherCurrentLiabilities { get; set; }

    /// <summary>
    /// Сумма обязательств, классифицированных как прочие, со сроком погашения по истечении одного года или обычного операционного цикла, если он дольше.
    /// </summary>
    [JsonProperty("otherNonCurrentLiabilities")]
    public long? OtherNonCurrentLiabilities { get; set; }

    /// <summary>
    /// Общая сумма всех статей акционерного капитала (дефицита) за вычетом дебиторской задолженности должностных лиц, директоров, владельцев и аффилированных лиц организации, приходящейся на материнскую компанию. Сумма акционерного капитала экономического субъекта, приходящаяся на материнскую компанию, не включает сумму акционерного капитала, которая может быть отнесена на ту долю участия в капитале дочерней компании, которая не относится к материнской компании (неконтрольная доля участия, доля меньшинства). Это исключает временный капитал и иногда называется постоянным капиталом.
    /// </summary>
    [JsonProperty("totalShareholderEquity")]
    public long? TotalShareholderEquity { get; set; }

    /// <summary>
    /// Сумма, выделенная на казначейские акции. Собственные акции – это обыкновенные и привилегированные акции организации, которые были выпущены, выкуплены организацией и хранятся в ее казначействе.
    /// </summary>
    [JsonProperty("treasuryStock")] public long? TreasuryStock { get; set; }

    /// <summary>
    /// Совокупная сумма нераспределенной прибыли или дефицита отчитывающейся организации.
    /// </summary>
    [JsonProperty("retainedEarnings")] public long? RetainedEarnings { get; set; }

    /// <summary>
    /// Совокупная номинальная или заявленная стоимость выпущенных непогашаемых обыкновенных акций (или обыкновенных акций, погашаемых исключительно по усмотрению эмитента). Эта статья включает собственные акции, выкупленные организацией. Примечание: элементы, касающиеся количества обыкновенных акций, не подлежащих выкупу, номинальной стоимости и других концепций раскрытия информации находятся в другом разделе акционерного капитала.
    /// </summary>
    [JsonProperty("commonStock")] public long? CommonStock { get; set; }

    /// <summary>
    /// Наилучшая оценка Обыкновенных акций, находящихся в обращении. Если компания не сообщает стоимость на конец периода, сумма по умолчанию равна отчетной стоимости средневзвешенных акций в обращении за квартал без разбавления (us-gaap::WeightedAverageNumberOfSharesOutstandingBasic).
    /// </summary>
    [JsonProperty("commonStockSharesOutstanding")]
    public long? CommonStockSharesOutstanding { get; set; }
}