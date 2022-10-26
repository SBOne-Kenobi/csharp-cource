namespace WordBlocks;

public static class WordBlockUtil
{
    public static string[] Bucketize(this string text, int bucketSize)
    {
        var words = text.Split();
        if (words.Any(word => word.Length > bucketSize))
        {
            return Array.Empty<string>();
        }

        return words
            .Aggregate(new List<string>(), (acc, word) =>
            {
                if (acc.Count > 0 && acc[^1].Length + word.Length + 1 <= bucketSize)
                {
                    acc[^1] += " " + word;
                }
                else
                {
                    if (acc.Count > 0)
                    {
                        acc[^1] = acc[^1].Trim();
                    }
                    acc.Add(word);
                }
                return acc;
            }).ToArray();
    }
}