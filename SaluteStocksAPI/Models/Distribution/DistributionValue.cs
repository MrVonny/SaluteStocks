using NetTopologySuite.GeometriesGraph;

namespace SaluteStocksAPI.Models.Distribution;

public struct DistributionValue
{
    public double Position;
    public int Value;

    public DistributionValue(KeyValuePair<double, int> kv)
    {
        Position = kv.Key;
        Value = kv.Value;
    }

    public DistributionValue(double pos, int val)
    {
        Position = pos;
        Value = val;
    }
}