namespace RenderForBlind;

public static class RenderUtil
{
    public static string TextRenderForBlind(this string text, Dictionary<string, string> dictionary, int maxInPage)
    {
        return text
            .Split()
            .Select(word => dictionary[word.ToLower()].ToUpper())
            .Chunk(maxInPage)
            .Select(page => string.Join(" ", page))
            .Aggregate((acc, page) => acc + "\n" + page);
    }
}