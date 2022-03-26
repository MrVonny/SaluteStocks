namespace SaluteStocksAPI.Models.FundamentalData;
using Newtonsoft.Json;
public class IpoCalendar
{
    [JsonProperty("symbol")] public string Symbol { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("ipoDate")] public DateTime? IpoDate { get; set; }
    [JsonProperty("priceRangeLow")] public decimal? PriceRangeLow { get; set; }
    [JsonProperty("priceRangeHigh")] public decimal? PriceRangeHigh { get; set; }
    [JsonProperty("currency")] public string Currency { get; set; }
    [JsonProperty("exchange")] public string Exchange { get; set; }
}