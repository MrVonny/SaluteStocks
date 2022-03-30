namespace SaluteStocksAPI.Models.Distribution;

public struct DistributionValue
{
    public decimal Position;
    public int Value;

    public DistributionValue(KeyValuePair<decimal, int> kv)
    {
        Position = kv.Key;
        Value = kv.Value;
    }
}