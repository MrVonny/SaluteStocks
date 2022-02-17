using System;
using NUnit.Framework;
using SaluteStocksAPI.AlphaVantage;
using SaluteStocksAPI.AlphaVantage.Common;
namespace TestProject1;

[TestFixture] public class Tests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void Test1()
    {

        var ac = AlphaVantageClientFactory.Create();
        var seriesdaily = ac.GetTimeSeriesDaily("IBM", adjusted:false);
        
        Assert.AreEqual( "130.4400",seriesdaily.Result[0].High);
    }
}