using MisisClientServer.DataBase;
using MisisClientServer.Models.Core.Common;

namespace MisisClientServer.Models.Core;

public class TimeSeries : EntityInfo
{
    public string Information { get; set; }
    public DateTime LastRefreshed { get; set; }
    public string TimeZone { get; set; }
    public TimePeriod TimePeriod { get; set; }
    
    public List<QuotesPeriodInfo> MonthlyTimeSeries { get; set; }
}