using Newtonsoft.Json;

namespace MisisClientServer.Models.Core;

public class GlobalQuote
{
    [JsonProperty("symbol")]public string Symbol { get; set; }
    [JsonProperty("open")]public double? Open { get; set; }
    [JsonProperty("high")]public double? High { get; set; }
    [JsonProperty("low")]public double? Low { get; set; }
    [JsonProperty("price")]public double? Price { get; set; }
    [JsonProperty("volume")]public double? Volume { get; set; }
    [JsonProperty("latestDay")]public DateTime? LatestDay { get; set; }
    [JsonProperty("previousClose")]public double? PreviousClose { get; set; }
    [JsonProperty("change")]public double? Change { get; set; }
    [JsonProperty("changePercent")]public string ChangePercent { get; set; }
}