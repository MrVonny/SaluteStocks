namespace SaluteStocksAPI.Models.Distribution;

public struct DistributionValue
{
    public decimal Position;
    public decimal Value;

    public DistributionValue(KeyValuePair<decimal, decimal> kv)
    {
        Position = kv.Key;
        Value = kv.Value;
    }
}