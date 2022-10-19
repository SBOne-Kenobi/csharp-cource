using System.Collections;

namespace FrogAndLake;

public class Lake : IEnumerable<int>
{
    private bool _isOrdered;
    private readonly List<int> _order;

    public Lake()
    {
        _order = new List<int>();
    }

    public void Add(int x)
    {
        _isOrdered = false;
        _order.Add(x);
    }
    
    public Lake(IEnumerable<int> order)
    {
        _order = order.ToList();
    }


    private static Comparison<int> Comparator()
    {
        return (x, y) =>
        {
            var x2 = x % 2;
            var y2 = y % 2;
            if (x2 != y2)
            {
                return y2.CompareTo(x2);
            }
            return x2 == 0 ? y.CompareTo(x) : x.CompareTo(y);
        };
    }

    private void ReorderIfNeeded()
    {
        if (_isOrdered) return;

        _order.Sort(Comparator());

        _isOrdered = true;
    }

    public IEnumerator<int> GetEnumerator()
    {
        ReorderIfNeeded();
        return _order.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}