using Water;

namespace UnitTest;

public class WaterCollectorTest
{
    [Fact]
    public void Test1()
    {
        var heights = new List<int>
        {
            0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1
        };
        var actual = WaterCollector.CalculateWaterVolume(heights);
        Assert.Equal(6, actual);
    }
    
    [Fact]
    public void Test2()
    {
        var heights = new List<int>
        {
            4, 2, 0, 3, 2, 5
        };
        var actual = WaterCollector.CalculateWaterVolume(heights);
        Assert.Equal(9, actual);
    }
}