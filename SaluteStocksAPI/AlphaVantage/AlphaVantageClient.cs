﻿using System.Net;
using Newtonsoft.Json;
using SaluteStocksAPI.AlphaVantage.Common;
using SaluteStocksAPI.Models.Core;
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
        }

        public static class CoreStock
        {
            public static string IntraDay => "TIME_SERIES_INTRADAY";
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

    #endregion

    #region Core

    public async Task<TimeSeries> GetTimeSeriesDaily(string symbol,
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
            DataType.Csv => await GetAndParseCsvAsync<TimeSeries>(uri),
            DataType.Json => await GetAndParseJsonAsync<TimeSeries>(uri),
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

    private async Task<T> GetAndParseCsvAsync<T>(Uri uri)
    {
        HttpClient client = new HttpClient();

        using HttpResponseMessage response = await client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            //ToDo: десериализовать CSV
            throw new NotImplementedException();
        }

        throw new(response.ReasonPhrase);
    }

    private Uri GenearteUri(string function, params KeyValuePair<string, string>[] query)
    {
        return new Uri(BaseUrl + $"tokne=query?apikey={_apikey}&function={function}&" +
                       string.Join("&", query.Select(pair => $"{pair.Key}={pair.Value}")));
    }
}