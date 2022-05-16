using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SaluteStocksAPI.Screener;

public struct RangedValue<T> where T: IComparable<T>
{
    [JsonProperty("from")]
    public T Min;
    [JsonProperty("to")]
    public T Max;
    public RangedValue(T min, T max)
    {
        Max = max;
        Min = min;
    }
    public bool IsInRange(T val)
    {
        return val.CompareTo(Min) >= 0 && val.CompareTo(Max) <= 0;
    }
}

