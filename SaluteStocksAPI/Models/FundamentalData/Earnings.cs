using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SaluteStocksAPI.DataBase;

namespace SaluteStocksAPI.Models.FundamentalData;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class AnnualEarning
{
    [JsonIgnore]
    [Key]
    public int Id { get; set; }
    public string Symbol { get; set; }
    public Earnings Earnings { get; set; }
    
    /// <summary>
    /// years: 2021, 2020, 2019 ... 1996
    /// </summary>
    [JsonProperty("fiscalDateEnding")] public DateTime? FiscalDateEnding { get; set; }
    
    /// <summary>
    /// При́быль на а́кцию (англ. Earnings per share, EPS)
    /// — финансовый показатель, равный отношению чистой
    /// прибыли компании, доступной для распределения, к
    /// среднегодовому числу обыкновенных акций. Прибыль
    /// на акцию является одним из основных показателей,
    /// использующихся для сравнения инвестиционной
    /// привлекательности и эффективности компаний,
    /// действующих на фондовом рынке.
    /// </summary>
    [JsonProperty("reportedEPS")] public double? ReportedEPS { get; set; }
}

public class QuarterlyEarning
{
    [JsonIgnore]
    [Key]
    public int Id { get; set; }
    
    public string Symbol { get; set; }
    public Earnings Earnings { get; set; }
    
    [JsonProperty("fiscalDateEnding")] public DateTime? FiscalDateEnding { get; set; }

    [JsonProperty("reportedDate")] public DateTime? ReportedDate { get; set; }

    [JsonProperty("reportedEPS")] public double? ReportedEPS { get; set; }

    [JsonProperty("estimatedEPS")] public double? EstimatedEPS { get; set; }

    [JsonProperty("surprise")] public double? Surprise { get; set; }

    [JsonProperty("surprisePercentage")] public double? SurprisePercentage { get; set; }
}

public class Earnings : CompanyEntityInfo
{
    [JsonProperty("annualEarnings")] public List<AnnualEarning> AnnualEarnings { get; set; }

    [JsonProperty("quarterlyEarnings")] public List<QuarterlyEarning> QuarterlyEarnings { get; set; }
}