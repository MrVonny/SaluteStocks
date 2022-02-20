using Newtonsoft.Json;
// using Microsoft.VisualBasic.FileIO;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using SaluteStocksAPI.AlphaVantage.Common;
using SaluteStocksAPI.Models.Core.Common;
using SaluteStocksAPI.Models.FundamentalData;

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
            public static string Monthly => "TIME_SERIES_DAILY";
            public static string MonthlyAdjusted => "TIME_SERIES_DAILY";
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
    
    public async Task<List<ListingRow>> GetListing(ListingStatus listingStatus = ListingStatus.Active ,DateTime? time = null)
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
    
    #endregion

    #region Core

    public async Task<List<QuotesPeriodInfo>> GetTimeSeriesDaily(string symbol,
        OutputSize outputSize = OutputSize.Full, DataType dataType = DataType.Csv, bool adjusted = true)
    {
        var keyValuePairs = new List<KeyValuePair<string, string>>();

        keyValuePairs.Add(new KeyValuePair<string, string>("symbol", symbol));
        keyValuePairs.Add(new KeyValuePair<string, string>("datatype", dataType switch
        {
            DataType.Csv => "csv",
            DataType.Json => "json",
            _ => throw new ArgumentOutOfRangeException(nameof(dataType), dataType, null)
        }));
        keyValuePairs.Add(new KeyValuePair<string, string>("outputsize", outputSize switch
        {
            OutputSize.Compact => "compact",
            OutputSize.Full => "full",
            _ => throw new ArgumentOutOfRangeException(nameof(dataType), dataType, null)
        }));

        var uri = GenearteUri(adjusted ? FunctionNames.CoreStock.DailyAdjusted : FunctionNames.CoreStock.Daily, 
            keyValuePairs.ToArray());

        return dataType switch
        {
            DataType.Csv => await GetAndParseCsvAsync<QuotesPeriodInfo>(uri),
            // DataType.Json => await GetAndParseJsonAsync<QuotesPeriodInfo>(uri),
            _ => throw new ArgumentOutOfRangeException(nameof(dataType), dataType, null)
        };
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
        HttpClient client = new HttpClient();

        using HttpResponseMessage response = await client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }

        throw new(response.ReasonPhrase);
    }

    private async Task<List<T>> GetAndParseCsvAsync<T>(Uri uri)
    {
        HttpClient client = new HttpClient();

        using HttpResponseMessage response = await client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };
            return new CsvReader(new StringReader(result), config).GetRecords<T>().ToList();
        }

        throw new(response.ReasonPhrase);
    }

    private Uri GenearteUri(string function, params KeyValuePair<string, string>[] query)
    {
        return new Uri(BaseUrl + $"query?apikey={_apikey}&function={function}&" +
                       string.Join("&", query.Select(pair => $"{pair.Key}={pair.Value}")));
    }
}