using SaluteStocksAPI.DataBase;
using SaluteStocksAPI.Models.Core.Common;

namespace SaluteStocksAPI.Models.Core;

public class TimeSeries : EntityInfo
{
    public string Information { get; set; }
    public DateTime LastRefreshed { get; set; }
    public string TimeZone { get; set; }
    public TimePeriod TimePeriod { get; set; }
    
    public List<QuotesPeriodInfo> MonthlyTimeSeries { get; set; }
}