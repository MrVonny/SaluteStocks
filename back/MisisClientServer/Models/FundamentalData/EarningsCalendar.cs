using System.ComponentModel.DataAnnotations;
using MisisClientServer.DataBase;
using Newtonsoft.Json;

namespace MisisClientServer.Models.FundamentalData;

public class EarningsCalendar : CompanyEntityInfo
{
    [JsonIgnore]
    [Key]
    public int Id { get; set; }
    
    [JsonProperty("fiscalDateEnding")] public string FiscalDateEnding { get; set; }

    [JsonProperty("reportedCurrency")] public string ReportedCurrency { get; set; }

    [JsonProperty("name")] public string Name { get; set; }
    
    [JsonProperty("reportDate")] public DateTime? ReportDate { get; set; }
    
    [JsonProperty("estimate")] public double? Estimate { get; set; }


}