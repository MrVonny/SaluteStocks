using System.ComponentModel.DataAnnotations;
using SaluteStocksAPI.AlphaVantage.Common;
using SaluteStocksAPI.DataBase;

namespace SaluteStocksAPI.Models.FundamentalData;

public class ListingRow : EntityInfo
{
    [Key]
    public string Symbol { get; set; }
    public string Name { get; set; }
    public string Exchange { get; set; }
    public string AssetType { get; set; }
    public string IpoDate { get; set; }
    public string DelistingDate { get; set; }
    public ListingStatus Status { get; set; }
}