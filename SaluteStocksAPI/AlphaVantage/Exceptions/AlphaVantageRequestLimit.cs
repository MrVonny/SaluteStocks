namespace SaluteStocksAPI.AlphaVantage.Exceptions;

public class AlphaVantageRequestLimit : Exception
{
    public AlphaVantageRequestLimit(string message) : base(message){ }
    
}