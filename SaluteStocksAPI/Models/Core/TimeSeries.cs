using Newtonsoft.Json;
using SaluteStocksAPI.DataBase;

namespace SaluteStocksAPI.Models.Core;
#nullable enable
public class TimeSeries : EntityInfo
{
    public string Information { get; set; }
    public string Symbol { get; set; }
    public DateTime LastRefreshed { get; set; }
    public string TimeZone { get; set; }
    public TimePeriod TimePeriod { get; set; }
    
    public List<QuotesPeriodInfo> MonthlyTimeSeries { get; set; }
}
