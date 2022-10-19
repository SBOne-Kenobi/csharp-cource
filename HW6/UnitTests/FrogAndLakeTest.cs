using FrogAndLake;

namespace UnitTests;

public class FrogAndLakeTest
{
    [Fact]
    public void TestRange()
    {
        var lake = new Lake
        {
            1, 2, 3, 4, 5, 6, 7, 8
        };
        var expected = new List<int>
        {
            1, 3, 5, 7, 8, 6, 4, 2
        };
        Assert.Equal(expected, lake);
    }
    
    [Fact]
    public void TestAny()
    {
        var lake = new Lake
        {
            13, 23, 1, -8, 4, 9
        };
        var expected = new List<int>
        {
            1, 9, 13, 23, 4, -8
        };
        Assert.Equal(expected, lake);
    }
}