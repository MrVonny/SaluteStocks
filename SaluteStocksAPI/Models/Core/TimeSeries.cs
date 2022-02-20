using SaluteStocksAPI.DataBase;

namespace SaluteStocksAPI.Models.Core;

public class TimeSeries : EntityInfo
{
    public string Information { get; set; }
    public string Symbol { get; set; }
    public string LastRefreshed { get; set; }
    public string TimeZone { get; set; }
    public TimePeriod TimePeriod { get; set; }
    
    public List<QuotesPeriodInfo> MonthlyTimeSeries { get; set; }
}