using NetTopologySuite.GeometriesGraph;

namespace SaluteStocksAPI.Models.Distribution;

public struct DistributionValue
{
    public int Position;
    public int Value;

    public DistributionValue(KeyValuePair<int, int> kv)
    {
        Position = kv.Key;
        Value = kv.Value;
    }

    public DistributionValue(int pos, int val)
    {
        Position = pos;
        Value = val;
    }
}