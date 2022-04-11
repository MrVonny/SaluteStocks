using System.ComponentModel.DataAnnotations;
using SaluteStocksAPI.AlphaVantage.Common;
using SaluteStocksAPI.DataBase;

namespace SaluteStocksAPI.Models.FundamentalData;

// ReSharper disable once ClassNeverInstantiated.Global
public class ListingRow : EntityInfo
{
    public string Name { get; set; }
    public string Exchange { get; set; }
    public string AssetType { get; set; }
    public string IpoDate { get; set; }
    public string DelistingDate { get; set; }
    public ListingStatus Status { get; set; }
}