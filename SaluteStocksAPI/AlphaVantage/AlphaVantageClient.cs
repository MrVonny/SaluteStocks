using System.ComponentModel;
using Newtonsoft.Json;
// using Microsoft.VisualBasic.FileIO;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using Microsoft.OpenApi.Extensions;
using SaluteStocksAPI.AlphaVantage.Common;
using SaluteStocksAPI.Models.Core;
using SaluteStocksAPI.Models.Core.Common;
using SaluteStocksAPI.Models.FundamentalData;
using SaluteStocksAPI.Models.FundamentalData.Common;
using Serilog;

namespace SaluteStocksAPI.AlphaVantage;

public class AlphaVantageClient
{
    private static class FunctionNames
    {
        //ToDo: Добавить больше названий функций (https://www.alphavantage.co/documentation/#)
        public static class FundamentalData
        {
            public static string IncomeStatement => "INCOME_STATEMENT";
            public static string BalanceSheet => "BALANCE_SHEET";
            public static string CashFlow => "CASH_FLOW";
            public static string CompanyOverview => "OVERVIEW";
            public static string Earnings => "EARNINGS";
            public static string ListingDelistingStatus => "LISTING_STATUS";
            public static string EarningsCalendar => "EARNINGS_CALENDAR";
            public static string IPOCalendar => "IPO_CALENDAR";
            

        }

        public static class CoreStock
        {
            public static string IntraDay => "TIME_SERIES_INTRADAY";
            public static string IntraDayExtended => "TIME_SERIES_INTRADAY_EXTENDED";
            public static string Daily => "TIME_SERIES_DAILY";
            public static string DailyAdjusted => "TIME_SERIES_DAILY_ADJUSTED";
            public static string Weekly => "TIME_SERIES_WEEKLY";
            public static string WeeklyAdjusted => "TIME_SERIES_WEEKLY_ADJUSTED";
            public static string Monthly => "TIME_SERIES_MONTHLY";
            public static string MonthlyAdjusted => "TIME_SERIES_MONTHLY_ADJUSTED";
            public static string QuoteEndpoint => "GLOBAL_QUOTE";
            public static string SearchEndpoint => "SYMBOL_SEARCH";
        }
    }

    private readonly string _apikey;

    private static string BaseUrl => "https://www.alphavantage.co/";

    public AlphaVantageClient(string apikey)
    {
        _apikey = apikey;
    }

    #region FundamentalData

    public async Task<IncomeStatement> GetIncomeStatement(string symbol)
    {
        var uri = GenearteUri(FunctionNames.FundamentalData.IncomeStatement,
            new KeyValuePair<string, string>("symbol", symbol));

        return await GetAndParseJsonAsync<IncomeStatement>(uri);
    }

    public async Task<BalanceSheet> GetBalanceSheet(string symbol)
    {
        var uri = GenearteUri(FunctionNames.FundamentalData.BalanceSheet,
            new KeyValuePair<string, string>("symbol", symbol));

        return await GetAndParseJsonAsync<BalanceSheet>(uri);
    }

    public async Task<CashFlow> GetCashFlow(string symbol)
    {
        var uri = GenearteUri(FunctionNames.FundamentalData.CashFlow,
            new KeyValuePair<string, string>("symbol", symbol));

        return await GetAndParseJsonAsync<CashFlow>(uri);
    }

    public async Task<CompanyOverview> GetCompanyOverview(string symbol)
    {
        var uri = GenearteUri(FunctionNames.FundamentalData.CompanyOverview,
            new KeyValuePair<string, string>("symbol", symbol));

        return await GetAndParseJsonAsync<CompanyOverview>(uri);
    }

    
    public async Task<List<ListingRow>> GetListing(ListingStatus listingStatus = ListingStatus.Active, DateTime? time = null)
    {
        
        var values =new List<KeyValuePair<string, string>>();
        if(time != null)
            values.Add(new KeyValuePair<string, string>("date", time.Value.ToString("yyyy-MM-dd")));

        values.Add(new KeyValuePair<string, string>("state", listingStatus switch
        {
            ListingStatus.Active => "active",
            ListingStatus.Delisted => "delisted",
            _ => throw new ArgumentOutOfRangeException(nameof(listingStatus), listingStatus, null)
        }));
        
        var uri = GenearteUri(FunctionNames.FundamentalData.ListingDelistingStatus, values.ToArray());

        return await GetAndParseCsvAsync<ListingRow>(uri);
    }

    public async Task<Earnings> GetCompanyEarnings(string symbol)
    {
        var uri = GenearteUri(FunctionNames.FundamentalData.Earnings,
            new KeyValuePair<string, string>("symbol", symbol));
        return await GetAndParseJsonAsync<Earnings>(uri);
    }
    
    public async Task<List<EarningsCalendar>> GetEarningsCalendar(string symbol = "", Horizon horizon = Horizon.ThreeMonths)
    {
        var keyValuePairs = new List<KeyValuePair<string, string>>();
        if (symbol != "") keyValuePairs.Add(new KeyValuePair<string, string>("symbol", symbol));
        
        keyValuePairs.Add(new KeyValuePair<string, string>("horizon", 
            horizon.GetAttributeOfType<DescriptionAttribute>().Description));
        
        
        var uri = GenearteUri(FunctionNames.FundamentalData.EarningsCalendar,
            keyValuePairs.ToArray());
        return await GetAndParseCsvAsync<EarningsCalendar>(uri);
    }
    
    public async Task<List<IpoCalendar>> GetIpoCalendar()
    {
        var uri = GenearteUri(FunctionNames.FundamentalData.IPOCalendar);
        return await GetAndParseCsvAsync<IpoCalendar>(uri);
    }

    #endregion

    #region Core
    public async Task<List<QuotesPeriodInfo>> GetTimeSeriesIntraday(string symbol,
        OutputSize outputSize = OutputSize.Full, bool adjusted = true, TimePeriod interval = TimePeriod.Min5)
    {
        var keyValuePairs = new List<KeyValuePair<string, string>>();
        keyValuePairs.Add((new KeyValuePair<string, string>("symbol", symbol)));
        
        keyValuePairs.Add(new KeyValuePair<string, string>("interval", 
            interval.GetAttributeOfType<DescriptionAttribute>().Description));
        
        keyValuePairs.Add(new KeyValuePair<string, string>( "adjusted", adjusted ? "true":"false"));
        
        keyValuePairs.Add(new KeyValuePair<string, string>( "outputsize" , 
            outputSize == OutputSize.Compact ? "compact" : "full"));
        
        keyValuePairs.Add(new KeyValuePair<string, string>("datatype", "csv"));
        var uri = GenearteUri(FunctionNames.CoreStock.IntraDay, keyValuePairs.ToArray());
        return await GetAndParseCsvAsync<QuotesPeriodInfo>(uri);
    }
    
    public async Task<List<QuotesPeriodInfo>> GetTimeSeriesIntradayExtended(string symbol, Slice slice = Slice.Year1Month1,
        OutputSize outputSize = OutputSize.Full, bool adjusted = true, TimePeriod interval = TimePeriod.Min5)
    {
        
        var keyValuePairs = new List<KeyValuePair<string, string>>();
        
        keyValuePairs.Add((new KeyValuePair<string, string>("symbol", symbol)));
        
        keyValuePairs.Add(new KeyValuePair<string, string>("interval",
            interval.GetAttributeOfType<DescriptionAttribute>().Description));
        
        keyValuePairs.Add(new KeyValuePair<string, string>("slice",
            slice.ToString().ToLowerInvariant()));
        
        keyValuePairs.Add(new KeyValuePair<string, string>( "adjusted", adjusted ? "true":"false"));
        var uri = GenearteUri(FunctionNames.CoreStock.IntraDayExtended, keyValuePairs.ToArray());
        return await GetAndParseCsvAsync<QuotesPeriodInfo>(uri);
    }
    public async Task<List<QuotesPeriodInfo>> GetTimeSeriesDailyCsv(string symbol,
        OutputSize outputSize = OutputSize.Full,  bool adjusted = true)
    {
        var keyValuePairs = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("symbol", symbol),
            new KeyValuePair<string, string>("datatype", "csv"),
            new KeyValuePair<string, string>("outputsize", outputSize switch
            {
                OutputSize.Compact => "compact",
                OutputSize.Full => "full",
                _ => throw new ArgumentOutOfRangeException(nameof(outputSize), outputSize, null)
            })
        };

        var uri = GenearteUri(adjusted ? FunctionNames.CoreStock.DailyAdjusted : FunctionNames.CoreStock.Daily, 
            keyValuePairs.ToArray());

        return await GetAndParseCsvAsync<QuotesPeriodInfo>(uri);
    }
    public async Task<List<QuotesPeriodInfo>> GetTimeSeriesWeeklyCsv(string symbol, bool adjusted = true)
    {
        var keyValuePairs = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("symbol", symbol),
            new KeyValuePair<string, string>("datatype", "csv")
        };

        var uri = GenearteUri(adjusted ? FunctionNames.CoreStock.WeeklyAdjusted : FunctionNames.CoreStock.Weekly, 
            keyValuePairs.ToArray());

        return await GetAndParseCsvAsync<QuotesPeriodInfo>(uri);
    }

    public async Task<List<QuotesPeriodInfo>> GetTimeSeriesMonthlyCsv(string symbol, bool adjusted = true)
    {
        var keyValuePairs = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("symbol", symbol),
            new KeyValuePair<string, string>("datatype", "csv")
        };

        var uri = GenearteUri(adjusted ? FunctionNames.CoreStock.MonthlyAdjusted : FunctionNames.CoreStock.Monthly, 
            keyValuePairs.ToArray());

        return await GetAndParseCsvAsync<QuotesPeriodInfo>(uri);
    }
    
    public async Task<GlobalQuote> GetQuoteEndpoint(string symbol) // list of 1 element
    {
        var keyValuePairs = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("symbol", symbol),
            new KeyValuePair<string, string>("datatype", "csv")
        };

        var uri = GenearteUri(FunctionNames.CoreStock.QuoteEndpoint, 
            keyValuePairs.ToArray());

        return (await GetAndParseCsvAsync<GlobalQuote>(uri)).First();
    }

    public async Task<List<SearchResult>> GetSearchResult(string keywords)
    {
        var keyValueParts = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("keywords", keywords),
            new KeyValuePair<string, string>("datatype", "csv")
        };
        var uri = GenearteUri(FunctionNames.CoreStock.SearchEndpoint,
            keyValueParts.ToArray());
        return await GetAndParseCsvAsync<SearchResult>(uri);
    }

    #endregion

    #region Forex

    #endregion

    #region Crypto Currencies

    #endregion

    #region Economic Indicators

    #endregion

    #region Technical Indicators

    #endregion

    private async Task<T> GetAndParseJsonAsync<T>(Uri uri)
    {
        Log.Information("Starting to get and parse JSON from {Uri}.", uri);
        HttpClient client = new HttpClient();

        using HttpResponseMessage response = await client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            Log.Information("Response has success status code");
            var result = await response.Content.ReadAsStringAsync();
            
            result = result.Replace("\"None\"", "null");
            Log.Information("Trying to deserialize response.");
            return JsonConvert.DeserializeObject<T>(result);
        }
        Log.Error("Response is not successful. Status code is {StatusCode}. Response: {Response}", response.StatusCode, response);

        throw new(response.ReasonPhrase);
    }

    private async Task<List<T>> GetAndParseCsvAsync<T>(Uri uri)
    {
        Log.Information("Starting to get and parse CSV from {Uri}.", uri);
        HttpClient client = new HttpClient();

        using HttpResponseMessage response = await client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            Log.Information("Response has success status code");
            var result = await response.Content.ReadAsStringAsync();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                HeaderValidated = null,
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };
            Log.Information("Trying to deserialize response.");
            return new CsvReader(new StringReader(result), config).GetRecords<T>().ToList();
        }
        Log.Error("Response is not successful. Status code is {StatusCode}. Response: {Response}", response.StatusCode, response);
        throw new(response.ReasonPhrase);
    }

    private Uri GenearteUri(string function, params KeyValuePair<string, string>[] query)
    {
        return new Uri(BaseUrl + $"query?apikey={_apikey}&function={function}&" +
                       string.Join("&", query.Select(pair => $"{pair.Key}={pair.Value}")));
    }
}