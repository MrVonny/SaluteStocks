using Newtonsoft.Json;

namespace MisisClientServer.ViewModels;

public class CompanyIndexViewModel
{
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("ticker")]
    public string Ticker { get; set; }
    
    [JsonProperty("description")]
    public string Description { get; set; }
    
    [JsonProperty("sector")]
    public string Sector { get; set; }
    
    [JsonProperty("country")]
    public string Country { get; set; }
    
    [JsonProperty("price")]
    public string Price { get; set; }
    
    
}