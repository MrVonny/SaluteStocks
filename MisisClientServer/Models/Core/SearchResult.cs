using Newtonsoft.Json;

    
namespace MisisClientServer.Models.Core;

public class SearchResult
{
    [JsonProperty("symbol")]public string Symbol { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("type")] public string Type { get; set; }
    [JsonProperty("region")] public string Region { get; set; }
    [JsonProperty("marketOpen")] public TimeOnly? MarketOpen { get; set; }
    [JsonProperty("marketClose")] public TimeOnly? MarketClose { get; set; }
    [JsonProperty("timezone")] public string TimeZone { get; set; }
    [JsonProperty("currency")] public string Currency  { get; set; }
    [JsonProperty("matchScore")] public double? MatchScore  { get; set; } 
}