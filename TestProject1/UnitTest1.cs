using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using SaluteStocksAPI.AlphaVantage;

namespace TestProject1;

[TestFixture] public class Tests
{
    protected AlphaVantageClient Client = AlphaVantageClientFactory.Create(); 
    
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public async Task Test1()
    {
        var timeSeries = await Client.GetTimeSeriesDaily("IBM", adjusted:false);
        
        Assert.AreEqual( "130.4400",timeSeries[0].High);
    }

    [Test]
    public async Task GetListingTest()
    {
        var listing = await Client.GetListing();
        
        Assert.Greater(listing.Count, 1000);
        Assert.That(listing, Is.All.Not.Null);
        Assert.That(listing.Select(x=>x.Symbol), Is.All.Not.Null);
    }
}