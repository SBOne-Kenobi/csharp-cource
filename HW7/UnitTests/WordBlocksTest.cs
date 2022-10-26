using WordBlocks;

namespace UnitTests;

public class WordBlocksTest
{
    [Fact]
    public void BucketizeTest()
    {
        var text = "она  продает морские раковины у моря";
        var expected = new[]
        {
            "она  продает",
            "морские раковины",
            "у моря"
        };
        var actual = text.Bucketize(16);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void BucketizeFailedTest()
    {
        
        var text = "она  продает морские раковины у моря";
        var actual = text.Bucketize(4);
        Assert.Empty(actual);
    }
}