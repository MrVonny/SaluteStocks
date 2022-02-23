using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using SaluteStocksAPI.AlphaVantage;
using SaluteStocksAPI.Models.FundamentalData;

namespace TestProject1;

[TestFixture] public class Tests
{
    protected AlphaVantageClient Client = AlphaVantageClientFactory.Create(); 
    
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public async Task GetListingTest()
    {
        var listing = await Client.GetListing();
        
        Assert.Greater(listing.Count, 1000);
        Assert.That(listing, Is.All.Not.Null);
        Assert.That(listing.Select(x=>x.Symbol), Is.All.Not.Null);
    }

    [Test]
    public async Task GetTimeSeriesDailyTest()
    {
        var timeSeriesCsv = await Client.GetTimeSeriesDailyCsv("IBM", adjusted:false );
        
        Assert.Greater(timeSeriesCsv.Count, 100);
        Assert.That(timeSeriesCsv, Is.All.Not.Null);

    }
    
    [Test] public async Task GetCompanyEarningsTest()
    {
        Earnings? companyEarnings = await Client.GetCompanyEarnings("IBM");
        Assert.That(companyEarnings.AnnualEarnings, Is.All.Not.AnyOf("asd", "qwe"));
    }
    
    
    [Test] public async Task GetCompanyCashFlowTest()
    {
        var companyCashFlow = await Client.GetCashFlow("IBM");
        Assert.That(companyCashFlow.AnnualReports, Is.All.Not.Null);
    }
    
    [Test] public async Task GetCompanyBalanceSheetTest()
    {
        var companyBalanceSheet = await Client.GetBalanceSheet("IBM");
        Assert.That(companyBalanceSheet.AnnualReports, Is.Not.Empty);
    }

    [Test]
    public async Task GetCompanyIncomeStatement()
    {
        var companyIncomeStatement = await Client.GetIncomeStatement("IBM");
        Assert.That(companyIncomeStatement.AnnualReports, Is.All.Not.Null );
    }

    [Test] public async Task GetCompanyTimeSeriesIntradayTest()
    {
        var companyTimeSeriesIntraday = await Client.GetTimeSeriesIntraday("IBM");
        Assert.That(companyTimeSeriesIntraday, Is.All.Not.Null);
    }
    
}