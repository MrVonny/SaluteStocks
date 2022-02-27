using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SaluteStocksAPI.DataBase;

public abstract class EntityInfo
{
    [Key]
    [JsonProperty("symbol")]
    public string Symbol { get; set; }
    
    public DateTime? LastLocalRefresh { get; set; }
    public DateTime? LastApiRefresh { get; set; }
}