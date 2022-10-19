using System.Collections;

namespace SparseMatrix;

public record SparseRecord<T>(int X, int Y, int Z, T Value);

internal class RecordComparer<T> : IComparer<SparseRecord<T>>
{
    public int Compare(SparseRecord<T>? x, SparseRecord<T>? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;
        var xComparison = x.X.CompareTo(y.X);
        if (xComparison != 0) return xComparison;
        var yComparison = x.Y.CompareTo(y.Y);
        if (yComparison != 0) return yComparison;
        return x.Z.CompareTo(y.Z);
    }
}

public class SparseMatrix<T> : IEnumerable<SparseRecord<T>>
{
    private int _dims;

    private readonly Dictionary<Tuple<int, int, int>, T> _data = new();

    public T? this[int x, int y]
    {
        get
        {
            CheckDim(2);
            return Get(x, y, 0);
        }
        set
        {
            CheckDim(2);
            Set(x, y, 0, value);
        }
    }

    public T? this[int x, int y, int z]
    {
        get
        {
            CheckDim(3);
            return Get(x, y, z);
        }
        set
        {
            CheckDim(3);
            Set(x, y, z, value);
        }
    }
    
    private void CheckDim(int expected)
    {
        if (_dims == 0)
        {
            _dims = expected;
        }
        else if (_dims != expected)
        {
            throw new IndexOutOfRangeException();
        }
    }

    private void Set(int x, int y, int z, T? value)
    {
        var key = new Tuple<int, int, int>(x, y, z);
        
        if (value == null || value.Equals(default(T)))
        {
            _data.Remove(key);
            return;
        }

        _data[key] = value!;
    }

    private T? Get(int x, int y, int z)
    {
        var key = new Tuple<int, int, int>(x, y, z);
        return _data.ContainsKey(key) ? _data[key] : default;
    }

    public IEnumerator<SparseRecord<T>> GetEnumerator()
    {
        var recordList = _data.Select(keyValuePair => 
            new SparseRecord<T>(
                keyValuePair.Key.Item1, 
                keyValuePair.Key.Item2, 
                keyValuePair.Key.Item3, 
                keyValuePair.Value
            )).ToList();
        
        recordList.Sort(new RecordComparer<T>());

        return recordList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}