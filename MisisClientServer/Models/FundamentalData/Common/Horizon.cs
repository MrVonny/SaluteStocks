using System.ComponentModel;

namespace MisisClientServer.Models.FundamentalData.Common;

public enum Horizon
{
    [Description("3month")]ThreeMonths,
    [Description("6month")]SixMonths,
    [Description("12month")]TwelveMonths
}