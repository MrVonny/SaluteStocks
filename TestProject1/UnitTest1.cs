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

        var timeSeriesJson = await Client.GetTimeSeriesDailyJson("IBM", adjusted: false);
        
        Assert.Greater(timeSeriesJson.MonthlyTimeSeries.Count,  10);
        Assert.That(timeSeriesJson.MonthlyTimeSeries, Is.All.Not.Null);
        var checkDate = DateOnly.FromDateTime( DateTime.Today.AddDays(1));
        Assert.Equals(timeSeriesCsv.Select(x => x.TimeStamp = checkDate),
            timeSeriesJson.MonthlyTimeSeries.Select(x => x.TimeStamp == checkDate));

    }
    
    [Test] public async Task GetCompanyEarningsTest()
    {
        Earnings? companyEarnings = await Client.GetCompanyEarnings("IBM");
        Assert.That(companyEarnings.AnnualEarnings, Is.All.Not.Null);
    }
    
    
    [Test] public async Task GetCompanyCashFlowTest()
    {
        var companyCashFlow = await Client.GetCashFlow("IBM");
        Assert.That(companyCashFlow.AnnualReports, Is.All.Not.Null);
    }
    
    [Test] public async Task GetCompanyBalanceSheetTest()
    {
        var companyBalanceSheet = await Client.GetBalanceSheet("IBM");
        Assert.That(companyBalanceSheet.AnnualReports, Is.All.Not.Null);
    }

    [Test]
    public async Task GetCompanyIncomeStatement()
    {
        var companyIncomeStatement = await Client.GetIncomeStatement("IBM");
        Assert.That(companyIncomeStatement.AnnualReports, Is.All.Not.Null );
    }
    
}