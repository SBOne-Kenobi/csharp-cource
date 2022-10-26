using RenderForBlind;

namespace UnitTests;

public class RenderForBlindTest
{
    [Fact]
    public void TextRenderForBlindTest()
    {
        var text = "This dog eats too much vegetables after lunch";
        var dictionary = new Dictionary<string, string>
        {
            {"this", "эта"},
            {"dog", "собака"},
            {"eats", "ест"},
            {"too", "слишком"},
            {"much", "много"},
            {"vegetables", "овощей"},
            {"after", "после"},
            {"lunch", "обеда"}
        };
        var expected = "ЭТА СОБАКА ЕСТ\n" +
                     "СЛИШКОМ МНОГО ОВОЩЕЙ\n" +
                     "ПОСЛЕ ОБЕДА";
        var actual = text.TextRenderForBlind(dictionary, 3);
        Assert.Equal(expected, actual);
    }
}