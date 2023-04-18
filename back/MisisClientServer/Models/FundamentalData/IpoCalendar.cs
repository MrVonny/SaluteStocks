namespace MisisClientServer.Models.FundamentalData;
using Newtonsoft.Json;
public class IpoCalendar
{
    [JsonProperty("symbol")] public string Symbol { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("ipoDate")] public DateTime? IpoDate { get; set; }
    [JsonProperty("priceRangeLow")] public double? PriceRangeLow { get; set; }
    [JsonProperty("priceRangeHigh")] public double? PriceRangeHigh { get; set; }
    [JsonProperty("currency")] public string Currency { get; set; }
    [JsonProperty("exchange")] public string Exchange { get; set; }
}