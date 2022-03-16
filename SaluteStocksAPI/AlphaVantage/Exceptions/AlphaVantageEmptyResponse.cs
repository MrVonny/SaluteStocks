namespace SaluteStocksAPI.AlphaVantage.Exceptions;

public class AlphaVantageEmptyResponse : Exception
{
    public AlphaVantageEmptyResponse(string message) : base(message){ }
    
}