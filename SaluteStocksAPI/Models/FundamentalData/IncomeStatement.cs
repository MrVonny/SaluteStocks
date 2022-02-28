using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SaluteStocksAPI.DataBase;

namespace SaluteStocksAPI.Models.FundamentalData;

public class IncomeStatement : CompanyEntityInfo
{
    [JsonProperty("annualReports")] public List<IncomeStatementAnnualReport> AnnualReports { get; set; }

    [JsonProperty("quarterlyReports")] public List<IncomeStatementQuarterlyReport> QuarterlyReports { get; set; }
}

public class IncomeStatementReport
{
    [JsonIgnore]
    [Key]
    public int Id { get; set; }
    
    [JsonIgnore]
    public IncomeStatement IncomeStatement { get; set; }
    
    public string Symbol { get; set; }
    
    [JsonProperty("fiscalDateEnding")] public string FiscalDateEnding { get; set; }

    [JsonProperty("reportedCurrency")] public string ReportedCurrency { get; set; }
    /// <summary>
    /// Совокупный доход за вычетом стоимости проданных товаров и услуг или операционных расходов, непосредственно связанных с деятельностью по получению дохода.
    /// </summary>
    [JsonProperty("grossProfit")] public double? GrossProfit { get; set; }

    /// <summary>
    ///Сумма выручки, признанной за проданные товары, оказанные услуги, страховые взносы или другую деятельность, которая представляет собой процесс получения дохода. Включает, помимо прочего, инвестиционный и процентный доход до вычета процентных расходов, когда они признаются в составе выручки, а также прибыль (убыток) от продаж и торговых операций.
    /// </summary>
    [JsonProperty("totalRevenue")] public double? TotalRevenue { get; set; }

    /// <summary>
    /// Совокупная стоимость произведенных и реализованных товаров и оказанных услуг за отчетный период.
    /// </summary>
    [JsonProperty("costOfRevenue")] public double? CostOfRevenue { get; set; }

    /// <summary>
    /// The aggregate costs related to goods produced and sold and services rendered by an entity during the reporting period. This excludes costs incurred during the reporting period related to financial services rendered and other revenue generating activities.
    /// </summary>
    [JsonProperty("costofGoodsAndServicesSold")]
    public double? CostofGoodsAndServicesSold { get; set; }

    /// <summary>
    /// Чистый результат за период вычета операционных расходов из операционных доходов.
    /// </summary>
    [JsonProperty("operatingIncome")] public double? OperatingIncome { get; set; }

    /// <summary>
    /// Совокупные общие расходы, связанные с продажей продуктов и услуг фирмы, а также все другие общие и административные расходы. Расходы на прямые продажи (например, кредит, гарантия и реклама) — это расходы, которые могут быть напрямую связаны с продажей конкретных продуктов. Косвенные расходы на продажу — это расходы, которые нельзя напрямую связать с продажей конкретных продуктов, например, расходы на телефонную связь, Интернет и почтовые расходы. Общие и административные расходы включают в себя заработную плату неторгового персонала, аренду, коммунальные услуги, связь и т.д.
    /// </summary>
    [JsonProperty("sellingGeneralAndAdministrative")]
    public double? SellingGeneralAndAdministrative { get; set; }

    /// <summary>
    /// Совокупные затраты, понесенные (1) в ходе запланированного поиска или критического исследования, направленного на открытие новых знаний в надежде, что такие знания будут полезны при разработке нового продукта или услуги, нового процесса или метода или при значительном улучшении к существующему продукту или процессу; или (2) для преобразования результатов исследований или других знаний в план или дизайн нового продукта или процесса или для значительного улучшения существующего продукта или процесса, предназначенного для продажи или использования организацией, в течение отчетного периода, отнесенного к исследованиям и проекты разработки, включая затраты на разработку компьютерного программного обеспечения до момента достижения технологической осуществимости, а также затраты, отнесенные при учете объединения бизнеса на незавершенные проекты, которые, как считается, не имеют альтернативного использования в будущем.
    /// </summary>
    [JsonProperty("researchAndDevelopment")]
    public double? ResearchAndDevelopment { get; set; }

    /// <summary>
    /// Как правило, текущие расходы, связанные с обычными операциями, за исключением той части этих расходов, которая может быть явно связана с производством и включена в себестоимость продаж или услуг. Включает коммерческие, общие и административные расходы.
    /// </summary>
    [JsonProperty("operatingExpenses")] public double? OperatingExpenses { get; set; }

    /// <summary>
    /// Сумма после начисления (амортизации) дисконта (премии) и инвестиционных расходов, процентного дохода и дохода в виде дивидендов по недействующим ценным бумагам.
    /// </summary>
    [JsonProperty("investmentIncomeNet")] public double? InvestmentIncomeNet { get; set; }

    /// <summary>
    /// Чистая сумма операционных процентных доходов (расходов).
    /// </summary>
    [JsonProperty("netInterestIncome")] public double? NetInterestIncome { get; set; }

    /// <summary>
    /// Сумма процентного дохода.
    /// </summary>
    [JsonProperty("interestIncome")] public double? InterestIncome { get; set; }

    /// <summary>
    /// Сумма стоимости заемных средств, учитываемая как процентный расход.
    /// </summary>
    [JsonProperty("interestExpense")] public double? InterestExpense { get; set; }

    /// <summary>
    /// Общая сумма непроцентного дохода, который может быть получен из: (1) сборов и комиссий; (2) заработанные премии; (3) сборы за страховой полис; (4) продажа или распоряжение активами; и (5) другие источники, не указанные иначе.
    /// </summary>
    [JsonProperty("nonInterestIncome")] public double? NonInterestIncome { get; set; }

    /// <summary>
    /// Сумма доходов (расходов) по внереализационной деятельности, классифицированная как прочее.
    /// </summary>
    [JsonProperty("otherNonOperatingIncome")]
    public double? OtherNonOperatingIncome { get; set; }

    /// <summary>
    /// Сумма расходов, признанных в текущем периоде и отражающая распределение стоимости материальных активов в течение срока их полезного использования. Включает производственную и непроизводственную амортизацию.
    /// </summary>
    [JsonProperty("depreciation")] public double? Depreciation { get; set; }

    /// <summary>
    /// расходы текущего периода, отнесенные на счет доходов от долгосрочных материальных активов, не используемых в производстве и не предназначенных для перепродажи, для распределения или признания стоимости таких активов в течение срока их полезного использования; или отражать уменьшение балансовой стоимости нематериального актива в течение срока действия такого актива; или отразить потребление в течение периода актива, который не используется в производстве.
    /// </summary>
    [JsonProperty("depreciationAndAmortization")]
    public double? DepreciationAndAmortization { get; set; }

    /// <summary>
    /// Часть прибыли или убытка за период до налогообложения, относящаяся к материнской компании.
    /// </summary>
    [JsonProperty("incomeBeforeTax")] public double? IncomeBeforeTax { get; set; }

    /// <summary>
    /// Сумма текущего расхода (дохода) по налогу на прибыль и расхода (дохода) по отложенному налогу на прибыль, относящихся к продолжающейся деятельности.
    /// </summary>
    [JsonProperty("incomeTaxExpense")] public double? IncomeTaxExpense { get; set; }

    /// <summary>
    /// Процентные и долговые расходы, связанные с внереализационной финансовой деятельностью предприятия.
    /// </summary>
    [JsonProperty("interestAndDebtExpense")]
    public double? InterestAndDebtExpense { get; set; }

    /// <summary>
    /// Сумма после налогообложения дохода (убытка) от продолжающейся деятельности, относящаяся к материнской компании.
    /// </summary>
    [JsonProperty("netIncomeFromContinuingOperations")]
    public double? NetIncomeFromContinuingOperations { get; set; }

    /// <summary>
    /// Сумма после налогообложения увеличения (уменьшения) собственного капитала в результате операций и других событий и обстоятельств из чистой прибыли и прочего совокупного дохода, относящаяся к материнской компании. Исключая изменения в собственном капитале в результате инвестиций владельцев и выплат собственникам.
    /// </summary>
    [JsonProperty("comprehensiveIncomeNetOfTax")]
    public double? ComprehensiveIncomeNetOfTax { get; set; }

    /// <summary>
    /// Часть прибыли или убытка за период до налогообложения и процентных расходов, приходящаяся на материнскую компанию.
    /// </summary>
    [JsonProperty("ebit")] public double? Ebit { get; set; }

    /// <summary>
    /// Часть прибыли или убытка за период до налогообложения, процентных расходов и износа и амортизации, приходящаяся на материнскую компанию.
    /// </summary>
    [JsonProperty("ebitda")] public double? Ebitda { get; set; }

    /// <summary>
    /// Часть прибыли или убытка за период за вычетом налога на прибыль, приходящаяся на материнскую компанию.
    /// </summary>
    [JsonProperty("netIncome")] public double? NetIncome { get; set; }
}

public class IncomeStatementAnnualReport : IncomeStatementReport
{
    
}

public class IncomeStatementQuarterlyReport : IncomeStatementReport
{
    
}