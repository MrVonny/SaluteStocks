namespace MisisClientServer.AlphaVantage;

public static class AlphaVantageClientFactory
{
    public static AlphaVantageClient Create()
    {
        var array = WebApplication.CreateBuilder().Configuration.GetSection("AlphaVantageTokens").Get<string[]>();
        return new AlphaVantageClient(array);
    }
}