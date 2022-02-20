using Newtonsoft.Json;

namespace SaluteStocksAPI.Models.FundamentalData.Common;



public abstract class Report 
{
    [JsonProperty("fiscalDateEnding")] public string FiscalDateEnding { get; set; }

    [JsonProperty("reportedCurrency")] public string ReportedCurrency { get; set; }
}