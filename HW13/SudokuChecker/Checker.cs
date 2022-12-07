namespace SudokuChecker;

public static class Checker
{
    public static bool Check(List<List<int?>> desk)
    {
        var threads = new List<Thread>(27);
        var result = true;
        for (var i = 0; i < 9; i++)
        {
            var x = i;
            var thread = new Thread(() => result = result && CheckRow(desk, x));
            thread.Start();
            threads.Add(thread);
            thread = new Thread(() => result = result && CheckCol(desk, x));
            thread.Start();
            threads.Add(thread);
            thread = new Thread(() => result = result && CheckCell(desk, x % 3, x / 3));
            thread.Start();
            threads.Add(thread);
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        return result;
    }

    private static bool CheckBound(int x)
    {
        return x is >= 1 and < 10;
    }

    private static bool UpdateWith(int x, ISet<int> set)
    {
        return CheckBound(x) && set.Add(x);
    }

    private static bool CheckRow(List<List<int?>> desk, int row)
    {
        var set = new HashSet<int>();
        for (var i = 0; i < 9; ++i)
        {
            var x = desk[row][i];
            if (x == null)
            {
                continue;
            }

            if (!UpdateWith(x.Value, set))
            {
                return false;
            }
        }

        return true;
    }

    private static bool CheckCol(List<List<int?>> desk, int col)
    {
        var set = new HashSet<int>();
        for (var i = 0; i < 9; ++i)
        {
            var x = desk[i][col];
            if (x == null)
            {
                continue;
            }

            if (!UpdateWith(x.Value, set))
            {
                return false;
            }
        }

        return true;
    }

    private static bool CheckCell(List<List<int?>> desk, int row, int col)
    {
        var set = new HashSet<int>();
        var offsetI = row * 3;
        var offsetJ = col * 3;
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                var x = desk[offsetI + i][offsetJ + j];
                if (x == null)
                {
                    continue;
                }

                if (!UpdateWith(x.Value, set))
                {
                    return false;
                }
            }
        }

        return true;
    }
}