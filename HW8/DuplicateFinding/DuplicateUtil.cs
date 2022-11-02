namespace DuplicateFinding;

public static class DuplicateUtil
{
    public static string FindLargestDuplicate(this string s)
    {
        var result = "";
        for (var i = 0; i < s.Length; ++i)
        {
            for (var j = i + 1; j < s.Length; ++j)
            {
                var length = 0;
                while (j + length < s.Length && s[i + length] == s[j + length])
                {
                    length++;
                }

                if (length > result.Length)
                {
                    result = s.Substring(i, length);
                }
            }
        }

        return result;
    }
}