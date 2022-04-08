using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SaluteStocksAPI.Models.FundamentalData;

namespace SaluteStocksAPI.DataBase;

public abstract class EntityInfo
{
    [Key]
    [JsonProperty("symbol")]
    public string Symbol { get; set; }
    public bool? ExistInApi { get; set; }
    
    public DateTime? LastLocalRefresh { get; set; }
    public DateTime? LastApiRefresh { get; set; }
}

public abstract class CompanyEntityInfo : EntityInfo
{
    public CompanyOverview CompanyOverview { get; set; }
}