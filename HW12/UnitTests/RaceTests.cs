using Race;

namespace UnitTests;

public class RaceTests
{
    [Fact]
    public void Test1()
    {
        var finder = new PathFinder(3);
        var path = finder.FindPath();
        var lines = new List<string>
        {
            "AA",
            "Position: 0 -> 1 -> 3",
            "Speed: 1 -> 2 -> 4",
            ""
        };
        Assert.Equal(lines, path.ToString().Split(Environment.NewLine));
    }
    
    [Fact]
    public void Test2()
    {
        var finder = new PathFinder(6);
        var path = finder.FindPath();
        var lines = new List<string>
        {
            "AAARA",
            "Position: 0 -> 1 -> 3 -> 7 -> 7 -> 6",
            "Speed: 1 -> 2 -> 4 -> 8 -> -1 -> 2",
            ""
        };
        Assert.Equal(lines, path.ToString().Split(Environment.NewLine));
    }
}