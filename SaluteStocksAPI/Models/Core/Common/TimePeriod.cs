namespace SaluteStocksAPI.Models.Core.Common;
using System.ComponentModel;

public enum TimePeriod
{
    [Description("daily")]Day,
    [Description("weekly")]Week,
    [Description("monthly")]Month,
    [Description("1min")]Min1,
    [Description("5min")]Min5,
    [Description("15min")]Min15,
    [Description("30min")]Min30,
    [Description("60min")]Min60
}