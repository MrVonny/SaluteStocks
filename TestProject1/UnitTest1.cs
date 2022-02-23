using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using SaluteStocksAPI.AlphaVantage;
using SaluteStocksAPI.AlphaVantage.Common;
using SaluteStocksAPI.Models.Core;
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
        Assert.That(companyEarnings.AnnualEarnings, Is.Not.Empty);
    }
    
    
    [Test] public async Task GetCompanyCashFlowTest()
    {
        var companyCashFlow = await Client.GetCashFlow("IBM");
        Assert.That(companyCashFlow.AnnualReports, Is.Not.Empty);
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

    [Test] public async Task GetIpoCalendar()
    {
        var ipoCal = Client.GetIpoCalendar();
        Assert.That(ipoCal.Result, Is.Not.Empty);
    }

    [Test] public async Task GetEarningsCalendar()
    {
        var earningsCalendar = Client.GetEarningsCalendar();
        Assert.That(earningsCalendar.Result, Is.Not.Empty);
    }
}