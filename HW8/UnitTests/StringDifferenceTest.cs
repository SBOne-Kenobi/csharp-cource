using StringDifference;

namespace UnitTests;

public class StringDifferenceTest
{

    [Fact]
    public void TestEq()
    {
        var a = "This is a string";
        Assert.True(DifferenceUtil.AreSimular(a, a));
    }
    
    
    [Fact]
    public void TestChange()
    {
        var a = "This is a string";
        var b = "This is b string";
        Assert.True(DifferenceUtil.AreSimular(a, b));
    }
    
    
    [Fact]
    public void TestReduce()
    {
        var a = "This is a string";
        var b = "This is  string";
        Assert.True(DifferenceUtil.AreSimular(a, b));
        Assert.True(DifferenceUtil.AreSimular(b, a));
    }
    
    [Fact]
    public void TestNotSimular()
    {
        var a = "This is a string";
        var b = "this is b string";
        Assert.False(DifferenceUtil.AreSimular(a, b));
    }
    
}