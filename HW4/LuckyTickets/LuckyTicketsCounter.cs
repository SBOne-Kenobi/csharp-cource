namespace LuckyTickets;

public class LuckyTicketsCounter
{
    private readonly Dictionary<Tuple<int, int>, long> _numberOfTicketsWithLengthAndSum = new();

    private long GetNumberOfTickets(int length, int sum)
    {
        var maxSum = 9 * length;
        if (sum > maxSum || sum < 0)
        {
            return 0;
        }

        switch (length)
        {
            case < 0:
                return 0;
            case <= 1:
                return 1;
        }

        var key = new Tuple<int, int>(length, sum);
        if (!_numberOfTicketsWithLengthAndSum.ContainsKey(key))
        {
            var result = 0L;
            for (var digit = 0; digit <= 9; digit++)
            {
                result += GetNumberOfTickets(length - 1, sum - digit);
            }
            _numberOfTicketsWithLengthAndSum[key] = result;
        }

        return _numberOfTicketsWithLengthAndSum[key];
    }

    public long LuckyTicket(int digitsNumber)
    {
        if (digitsNumber % 2 != 0)
        {
            return 0;
        }

        var halfLength = digitsNumber / 2;
        var maxSum = 9 * halfLength;
        var result = 0L;
        for (var targetSum = 0; targetSum <= maxSum; targetSum++)
        {
            var number = GetNumberOfTickets(halfLength, targetSum);
            result += number * number;
        }

        return result;
    }
}