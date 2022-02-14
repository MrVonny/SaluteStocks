namespace SaluteStocksAPI.AlphaVantage;

public class AlphaVantageClientFactory
{
    public static AlphaVantageClient Create()
    {
        var token = WebApplication.CreateBuilder().Configuration["AlphaVantageToken"];
        return new AlphaVantageClient(token);
    }
}