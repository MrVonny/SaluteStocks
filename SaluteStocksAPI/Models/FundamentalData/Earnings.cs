using System.Collections.Generic;
using Newtonsoft.Json;
using SaluteStocksAPI.DataBase;

namespace SaluteStocksAPI.Models.FundamentalData;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class AnnualEarning : EntityInfo
{
    [JsonProperty("fiscalDateEnding")] public string FiscalDateEnding { get; set; }

    [JsonProperty("reportedEPS")] public string ReportedEPS { get; set; }
}

public class QuarterlyEarning
{
    [JsonProperty("fiscalDateEnding")] public string FiscalDateEnding { get; set; }

    [JsonProperty("reportedDate")] public string ReportedDate { get; set; }

    [JsonProperty("reportedEPS")] public string ReportedEPS { get; set; }

    [JsonProperty("estimatedEPS")] public string EstimatedEPS { get; set; }

    [JsonProperty("surprise")] public string Surprise { get; set; }

    [JsonProperty("surprisePercentage")] public string SurprisePercentage { get; set; }
}

public class Earnings
{
    [JsonProperty("symbol")] public string Symbol { get; set; }

    [JsonProperty("annualEarnings")] public List<AnnualEarning> AnnualEarnings { get; set; }

    [JsonProperty("quarterlyEarnings")] public List<QuarterlyEarning> QuarterlyEarnings { get; set; }
}