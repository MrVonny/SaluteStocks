using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using SaluteStocksAPI.AlphaVantage;
using SaluteStocksAPI.DataBase;
using SaluteStocksAPI.Models.FundamentalData;
using SaluteStocksAPI.Screener;
using SaluteStocksAPI.Service;

namespace TestProject1;

[TestFixture]
public class BaseTest
{
    protected StocksContext StocksContext = null;
    protected AlphaVantageClient Client = AlphaVantageClientFactory.Create();

    [SetUp]
    public virtual void SetUp()
    {
        var optionsBuilder = new DbContextOptionsBuilder<StocksContext>();
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        string connectionString = config.GetConnectionString("MSSQL");
        var options = optionsBuilder
            .UseSqlServer(connectionString)
            .Options;

        StocksContext = new StocksContext(options);
    }
}
[TestFixture]
public class Tests : BaseTest
{
    

    [Test]
    public async Task GetSearchResults()
    {
        var searchResults = await Client.GetSearchResult("sberbank");
        Assert.That(searchResults, Is.Not.Empty);
    } 
    [Test] public async Task GetCompanyEarningsTest()
    {
        Earnings? companyEarnings = await Client.GetCompanyEarnings("IBM");
        Assert.That(companyEarnings.AnnualEarnings, Is.Not.Empty);
    }
    
    
    [Test] public async Task GetCompanyCashFlowTest()
    {
        var companyCashFlow = await Client.GetCashFlow("IBM");
        Assert.That(companyCashFlow.AnnualReports, Is.Not.Empty);
    }
    
    [Test] 
    [TestCase("IBM")]
    [TestCase("AAC")]
    public async Task GetCompanyBalanceSheetTest(string symbol)
    {
        var companyBalanceSheet = await Client.GetBalanceSheet(symbol);
        Assert.That(companyBalanceSheet.AnnualReports, Is.Not.Empty);
    }
    
    [Test] 
    [TestCase("ACNB")]
    [TestCase("AAC")]
    public async Task GetCompanyOverview(string symbol)
    {
        var companyOverview = await Client.GetCompanyOverview(symbol);
        Assert.That(companyOverview, Has.Property("Symbol"));
    }

    [Test]
    public async Task GetCompanyIncomeStatement()
    {
        var companyIncomeStatement = await Client.GetIncomeStatement("IBM");
        Assert.That(companyIncomeStatement.AnnualReports, Is.Not.Empty );
    }

    [Test] public async Task GetCompanyTimeSeriesIntradayTest()
    {
        var companyTimeSeriesIntraday = await Client.GetTimeSeriesIntraday("IBM");
        Assert.That(companyTimeSeriesIntraday, Is.Not.Empty);
    }
    
    [Test] public async Task GetCompanyTimeSeriesIntradayExtendedTest()
    {
        var companyTimeSeriesIntradayExtended = await Client.GetTimeSeriesIntradayExtended("IBM");
        Assert.That(companyTimeSeriesIntradayExtended, Is.Not.Empty);
    }

    [Test]
    public async Task GetCompanyTimeSeriesWeeklyTest()
    {
        var companyTimeSeriesWeekly = await Client.GetTimeSeriesWeeklyCsv("IBM");
        Assert.That(companyTimeSeriesWeekly, Is.Not.Empty);
    }
    [Test]
    public async Task GetCompanyTimeSeriesMonthlyTest()
    {
        var companyTimeSeriesMonthly = await Client.GetTimeSeriesMonthlyCsv("IBM");
        Assert.That(companyTimeSeriesMonthly, Is.Not.Empty);
    }

    [Test] public async Task GetCompanyQuoteEndpointTest()
    {
        var companyQuoteEndpoint = await Client.GetQuoteEndpoint("IBM");
        Assert.That(companyQuoteEndpoint, Is.Not.Null);
    }
    [Test]
    public async Task GetListingTest()
    {
        var listing = await Client.GetListing();
        
        Assert.Greater(listing.Count, 300);
        Assert.That(listing, Is.All.Not.Null);
        Assert.That(listing.Select(x => x.Symbol), Is.All.Not.Null);
        
    }

    [Test]
    public async Task GetTimeSeriesDailyTest()
    {
        var timeSeriesCsv = await Client.GetTimeSeriesDailyCsv("IBM", adjusted:false );
        
        Assert.Greater(timeSeriesCsv.Count, 100);
        Assert.That(timeSeriesCsv, Is.All.Not.Null);
    }
    
    [Test] public async Task GetIpoCalendar()
    {
        var ipoCal = await Client.GetIpoCalendar();
        Assert.That(ipoCal, Is.Not.Empty);
    }
    
    [Test] public async Task GetEarningsCalendar()
    {
        var earningsCalendar = await Client.GetEarningsCalendar();
        Assert.That(earningsCalendar, Is.Not.Empty);
    }

    
    [Test]
    public async Task WhereEPSTest()
    {
        List<string> symbolList;
        await using (StocksContext)
        {
            var screenerService = new ScreenerService(StocksContext);
            symbolList = await screenerService.GetStockSymbols(new ScreenerModel());
            Assert.That( symbolList, Is.Not.Empty);
            Assert.Greater(symbolList.Count, 500);
        }
    }
}