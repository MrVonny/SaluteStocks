using System;
using NUnit.Framework;
using SaluteStocksAPI.Screener;
using System.Runtime;
using NUnit.Framework.Internal;

namespace TestProject1;

[TestFixture]
public class InternalClassesTests
{
    [SetUp]
    public void Setup()
    {
        
    }
    
    [Test]
    [TestCase(123, 543, 123)]
    [TestCase("01/20/2010", "05/01/2021", "05/01/2012")]
    [TestCase(123.213, 52354.123, 777 )]
    public void RangedValueTest<T>(T min, T max, T comp) where T : IComparable<T>
    {
        var dt = DateTime.Now;
        Assert.That(new RangedValue<T>(min, max).IsInRange(comp));
    }
}