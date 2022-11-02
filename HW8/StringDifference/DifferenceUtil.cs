namespace StringDifference;

public class DifferenceUtil
{
    public static bool AreSimular(string a, string b)
    {
        if (a.Length == b.Length)
        {
            return a.Zip(b).Count(item => item.First != item.Second) <= 1;
        }

        string less;
        string bigger;

        if (a.Length > b.Length)
        {
            less = b;
            bigger = a;
        }
        else
        {
            less = a;
            bigger = b;
        }

        if (less.Length + 1 != bigger.Length)
        {
            return false;
        }

        var diff = 0;
        for (var i = 0; i < less.Length; ++i)
        {
            if (less[i] == bigger[i + diff]) continue;
            if (++diff > 1)
            {
                return false;
            }
        }

        return true;
    }
}