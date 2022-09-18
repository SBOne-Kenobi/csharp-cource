using Dice;

namespace UnitTest;

public class RollingTest
{

    private readonly RollingDices _rollingDices = new();
    
    [Theory]
    [InlineData(2, 6, 5)]
    [InlineData(2, 2, 1)]
    [InlineData(1, 3, 1)]
    [InlineData(2, 5, 4)]
    [InlineData(3, 4, 3)]
    [InlineData(4, 18, 80)]
    [InlineData(6, 20, 4221)]
    public void Test(int diceCount, int result, long expected)
    {
        var actual = _rollingDices.DiceRoll(diceCount, result);
        Assert.Equal(expected, actual);
    }
}