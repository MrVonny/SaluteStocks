using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SaluteStocksAPI.Models.FundamentalData.Common;



public abstract class Report 
{
    [JsonIgnore]
    [Key]
    public int Id { get; set; }
    
    [JsonProperty("fiscalDateEnding")] public string FiscalDateEnding { get; set; }

    [JsonProperty("reportedCurrency")] public string ReportedCurrency { get; set; }
}