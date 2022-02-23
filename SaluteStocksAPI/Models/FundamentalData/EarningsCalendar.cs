using Newtonsoft.Json;
using SaluteStocksAPI.Models.FundamentalData.Common;

namespace SaluteStocksAPI.Models.FundamentalData;

public class EarningsCalendar : Report
{
    [JsonProperty("symbol")] public string Symbol { get; set; }
    
    [JsonProperty("name")] public string Name { get; set; }
    
    [JsonProperty("reportDate")] public DateTime? ReportDate { get; set; }
    
    [JsonProperty("estimate")] public double? Estimate { get; set; }


}