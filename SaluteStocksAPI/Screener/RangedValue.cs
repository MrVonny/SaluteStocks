namespace SaluteStocksAPI.Screener;

public struct RangedValue<T>
{
    public T Min;
    public T Max;

    public RangedValue(T min, T max)
    {
        if ((dynamic)max > (dynamic)min)
            throw new InvalidOperationException("the maximum value cannot be less than the minimum");
        Min = min;
        Max = max;
    }
}