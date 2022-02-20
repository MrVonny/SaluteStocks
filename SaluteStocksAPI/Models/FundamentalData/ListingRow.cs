using SaluteStocksAPI.AlphaVantage.Common;

namespace SaluteStocksAPI.Models.FundamentalData;

public class ListingRow
{
    public string Symbol { get; set; }
    public string Name { get; set; }
    public string Exchange { get; set; }
    public string AssetType { get; set; }
    public string IpoDate { get; set; }
    public string DelistingDate { get; set; }
    public ListingStatus Status { get; set; }
}