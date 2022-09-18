namespace Dice;

public class RollingDices
{
    private const int MaxValue = 6;

    private readonly Dictionary<Tuple<int, int, int>, long> _dp = new();
    private readonly Dictionary<Tuple<int, int>, long> _c = new();

    private long GetC(int n, int k)
    {
        if (k < 0 || k > n)
        {
            return 0;
        }

        if (k == 0 || k == n)
        {
            return 1;
        }

        var key = new Tuple<int, int>(n, k);
        if (!_c.ContainsKey(key))
        {
            _c[key] = GetC(n - 1, k) + GetC(n - 1, k - 1);
        }

        return _c[key];
    }

    private long GetDp(int n, int m, int k)
    {
        if (n == 0 && m == 0)
        {
            return 1;
        }
        k = Math.Min(k, n);
        if (n <= 0 || m <= 0 || n < m || k <= 0)
        {
            return 0;
        }

        var key = new Tuple<int, int, int>(n, m, k);
        if (!_dp.ContainsKey(key))
        {
            var result = 0L;
            for (int i = 0; i <= m; i++)
            {
                result += GetC(m, i) * GetDp(n - i * k, m - i, k - 1);
            }

            _dp[key] = result;
        }

        return _dp[key];
    }

    public long DiceRoll(int diceCount, int expectedResult)
    {
        return GetDp(expectedResult, diceCount, MaxValue);
    }
    
}