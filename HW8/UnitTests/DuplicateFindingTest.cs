using DuplicateFinding;

namespace UnitTests;

public class DuplicateFindingTest
{
    [Fact]
    public void Test()
    {
        Assert.Equal("", "".FindLargestDuplicate());
        Assert.Equal("", "abcd".FindLargestDuplicate());
        Assert.Equal("aba", "abacaba".FindLargestDuplicate());
        Assert.Equal("ask", "mask4cask".FindLargestDuplicate());
        Assert.Equal("xxxx", "xxxxx".FindLargestDuplicate());
    }
}