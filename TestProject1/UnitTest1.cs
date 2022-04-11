using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using SaluteStocksAPI.AlphaVantage;
using SaluteStocksAPI.DataBase;
using SaluteStocksAPI.Models.Extensions;
using SaluteStocksAPI.Models.FundamentalData;
using SaluteStocksAPI.Screener;
using SaluteStocksAPI.Service;

namespace TestProject1;

[TestFixture]
public class BaseTest
{
    protected StocksContext stocksContext = null;
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

        stocksContext = new StocksContext(options);
    }
}

[TestFixture]
public class AlphaVantageApiTests : BaseTest
{


    [Test]
    public async Task GetSearchResults()
    {
        var searchResults = await Client.GetSearchResult("sberbank");
        Assert.That(searchResults, Is.Not.Empty);
    }

    [Test]
    public async Task GetCompanyEarningsTest()
    {
        Earnings? companyEarnings = await Client.GetCompanyEarnings("IBM");
        Assert.That(companyEarnings.AnnualEarnings, Is.Not.Empty);
    }


    [Test]
    public async Task GetCompanyCashFlowTest()
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
        Assert.That(companyIncomeStatement.AnnualReports, Is.Not.Empty);
    }

    [Test]
    public async Task GetCompanyTimeSeriesIntradayTest()
    {
        var companyTimeSeriesIntraday = await Client.GetTimeSeriesIntraday("IBM");
        Assert.That(companyTimeSeriesIntraday, Is.Not.Empty);
    }

    [Test]
    public async Task GetCompanyTimeSeriesIntradayExtendedTest()
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

    [Test]
    public async Task GetCompanyQuoteEndpointTest()
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
        var timeSeriesCsv = await Client.GetTimeSeriesDailyCsv("IBM", adjusted: false);

        Assert.Greater(timeSeriesCsv.Count, 100);
        Assert.That(timeSeriesCsv, Is.All.Not.Null);
    }

    [Test]
    public async Task GetIpoCalendar()
    {
        var ipoCal = await Client.GetIpoCalendar();
        Assert.That(ipoCal, Is.Not.Empty);
    }

    [Test]
    public async Task GetEarningsCalendar()
    {
        var earningsCalendar = await Client.GetEarningsCalendar();
        Assert.That(earningsCalendar, Is.Not.Empty);
    }
}

[TestFixture]
public class CompanyOverviewTests : BaseTest
{
    [Test]
    public async Task WhereEPSTest()
    {
        List<string> symbolList;
        await using (stocksContext)
        {
            var screenerService = new ScreenerService(new DataBaseRepository(stocksContext));
            symbolList = await screenerService.GetStockSymbols(new ScreenerModel());
            Assert.That( symbolList, Is.Not.Empty);
            Assert.Greater(symbolList.Count, 500);
        }
    }
    [Test]
    [TestCase(1, -1,  true)]
    [TestCase(2, 0,  true)]
    [TestCase(2, 0,  false)]
    public async Task EPSGrowthSomeYearsTest(short some, double growth, bool ifBigger)
    {
        await using (stocksContext)
        {
            var colist = await stocksContext.CompanyOverviews
                .Include(x => x.Earnings)
                .Where(x => x.Symbol.Length == 4 )
                .ToListAsync();
            var goodies = colist.Count(x => x.EPSGrowthSomeYears(some).HasValue && (ifBigger) ? 
                x.EPSGrowthSomeYears(some) >= growth : x.EPSGrowthSomeYears(some) <= growth );
            Assert.Greater(goodies, 10);
        }
    }

    [Test]
    [TestCase(1, -1,  true)]
    [TestCase(2, 0,  true)]
    [TestCase(2, 0,  false)]
    public async Task RevenueGrowthSomeYearsTest(short some, double growth, bool ifBiggerThanGrowth)
    {
        await using (stocksContext)
        {
            var colist = await stocksContext.CompanyOverviews
                .Include(x => x.Earnings)
                .Where(x => x.Symbol.Length == 4 )
                .ToListAsync();
            var goodies = colist.Count(x => x.RevenueGrowthSomeYears(some).HasValue && (ifBiggerThanGrowth) ? 
                x.RevenueGrowthSomeYears(some) >= growth : x.RevenueGrowthSomeYears(some) <= growth );
            Assert.Greater(goodies, 10);
        }
    }
}

[TestFixture]
public class CommonCompanyOverviewExtensionsTests : BaseTest
{
    [Test]
    [TestCase(true, "USD")]
    [TestCase(false, "EUR")] // not present on the database yet 
    [TestCase( true, "usd")] // not key sensitive
    [TestCase( false, "abc")]
    public async Task WhereCurrencyTest( bool ifSucceeds, params string[] currencies)
    {
        await using (stocksContext)
        {
            var fileteredQuery = stocksContext.CompanyOverviews.WhereCurrency(currencies);
            if (ifSucceeds)
            {
                Assert.That(await fileteredQuery.AnyAsync());
            }
            else
            {
                Assert.That(!await fileteredQuery.AnyAsync());
            }
        }
    }
    
    [Test]
    [TestCase(true, "USA")]
    [TestCase(true, "China")]
    [TestCase(false, "Russia")] // not present on the database yet
    [TestCase(false, "abc")]
    public async Task WhereCountryTest(bool ifSucceeds, params string[] countries)
    {
        await using (stocksContext)
        {
            var fileteredQuery = stocksContext.CompanyOverviews.WhereCountry(countries);
            if (ifSucceeds)
            {
                Assert.That(await fileteredQuery.AnyAsync());
            }
            else
            {
                Assert.That(!await fileteredQuery.AnyAsync());
            }
        }
    }

    [TestCase(true, "FINANCE")]
    [TestCase(true, "REAL ESTATE & CONSTRUCTION", "ENERGY & TRANSPORTATION")]
    [TestCase( false, "REAL ESTATE & CONSTRUCTIONs")] // typo
    [TestCase( false, "abc")]
    public async Task WhereSectorTest(bool ifSucceeds, params string[] sectors)
    {
        await using ( stocksContext )
        {
            var filteredQuery = stocksContext.CompanyOverviews.WhereSector(sectors);
            if (ifSucceeds)
            {
                Assert.That(await filteredQuery.AnyAsync());
            }
            else
            {
                Assert.That(!await filteredQuery.AnyAsync());
            }
        }
    }
}

[TestFixture]
public class FinancialCompanyOverviewExtensionsTests : BaseTest
{
    [Test]
    [TestCase(true, 5000, 10690253062000)] // should include all companies
    // [TestCase(false, 0, 299409)] // 
    public async Task WhereMarketCapTest( bool ifSucceeds, double min, double max)
    {
        await using (stocksContext)
        {
            var fileteredQuery = stocksContext.CompanyOverviews.WhereMarketCap(new RangedValue<double>(min, max));
            if (ifSucceeds)
            {
                Assert.That(await fileteredQuery.AnyAsync());
            }
            else
            {
                Assert.That(!await fileteredQuery.AnyAsync());
            }
        }
    }

    [Test]
    public async Task WhereDebtEquityTest()
    {
        var rv = new RangedValue<double>(0, 5);
        var fileteredQuery = stocksContext.CompanyOverviews.WhereDebtEquity(rv);
        Assert.Greater(await fileteredQuery.CountAsync(), 5);
    }

    [Test]
    public async Task LINQTranslationTest()
    {
        Expression<Func<double,bool>> criteria1 = p => p > 10;
        Expression<Func<CompanyOverview, double>> criteria2 = p => p.Beta.Value;
        Expression<Func<CompanyOverview, bool>> asd = overview => !overview.Beta.HasValue;
        Expression<Func<CompanyOverview, bool>> finalc = (co => criteria1.Invoke(criteria2.Invoke(co)) || asd.Invoke(co));
        await using (stocksContext)
        {
            var res = stocksContext.CompanyOverviews.Where(finalc.Expand());
            var expanded = finalc.Expand();
            Assert.AreEqual(await res.CountAsync(), 657);
        }
    }
}
