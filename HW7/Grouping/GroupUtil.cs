namespace Grouping;

public static class GroupUtil
{
    public static string GetInfoAboutSentence(this string sentence)
    {
        var words = sentence
            .Select(c => Char.IsPunctuation(c) ? ' ' : c)
            .Aggregate("", (acc, c) => acc + c)
            .Split()
            .Where(word => word.Length > 0);
        
        var groupsOfWords = words
            .GroupBy(word => word.Length)
            .OrderByDescending(group => group.Key);

        return groupsOfWords
            .Select((group, idx) => 
                $"Group {idx + 1}. Length {group.Key}. Count {group.Count()}" +
                group.Aggregate("\n", (acc, word) => acc + word + "\n")
            ).Aggregate((acc, groupInfo) => acc + "\n" + groupInfo);
    }
}