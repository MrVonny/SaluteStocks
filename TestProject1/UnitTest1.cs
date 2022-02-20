using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using SaluteStocksAPI.AlphaVantage;
using SaluteStocksAPI.AlphaVantage.Common;
using SaluteStocksAPI.Models.Core;

namespace TestProject1;

[TestFixture] public class Tests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public async Task Test1()
    {

        var ac = AlphaVantageClientFactory.Create(); 
        
        var timeSeries = await ac.GetTimeSeriesDaily("IBM", adjusted:false);
        
        Assert.AreEqual( "130.4400",timeSeries[0].High);
    }
}