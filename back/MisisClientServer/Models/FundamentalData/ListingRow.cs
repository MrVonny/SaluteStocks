using System.ComponentModel.DataAnnotations;
using MisisClientServer.AlphaVantage.Common;
using MisisClientServer.DataBase;

namespace MisisClientServer.Models.FundamentalData;

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