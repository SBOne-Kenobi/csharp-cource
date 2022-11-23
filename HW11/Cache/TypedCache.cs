namespace Cache;

public class TypedCache<T>: IDisposable where T : IDisposable
{
    private class Data
    {
        private readonly T _value;

        public T Value
        {
            get
            {
                LastTimestamp = DateTime.Now;
                return _value;
            }
        }

        public DateTime LastTimestamp { get; private set; }

        public Data(T value)
        {
            _value = value;
            LastTimestamp = DateTime.Now;
        }
    }

    private readonly TimeSpan _interval;
    private readonly int _maxSize;
    private readonly Dictionary<int, Data> _data;
    private int _nextId;

    private readonly Thread _gcThread;
    private volatile bool _shouldStop;

    public TypedCache(TimeSpan interval, int maxSize)
    {
        _interval = interval;
        _maxSize = maxSize;
        _data = new Dictionary<int, Data>(maxSize);

        GC.RegisterForFullGCNotification(99, 99);
        _gcThread = new Thread(CleanOnGc);
        _gcThread.Start();
    }

    public void Dispose()
    {
        _shouldStop = true;
        foreach (var (_, value) in _data)
        {
            value.Value.Dispose();
        }
        _data.Clear();
        _gcThread.Join();
        GC.SuppressFinalize(this);
    }

    public int PutElement(T element)
    {
        if (_data.Count >= _maxSize)
        {
            CleanData();
        }

        _data[_nextId] = new Data(element);
        return _nextId++;
    }

    public T? GetElement(int id)
    {
        _data.TryGetValue(id, out var element);
        return element == null ? default : element.Value;
    }

    private void CleanData()
    {
        var idToRemove = new List<int>();
        var current = DateTime.Now;
        foreach (var (key, value) in _data)
        {
            if (current - value.LastTimestamp <= _interval) continue;
            idToRemove.Add(key);
            value.Value.Dispose();
        }

        foreach (var id in idToRemove)
        {
            _data.Remove(id);
        }
    }

    private void CleanOnGc()
    {
        while (!_shouldStop)
        {
            if (GC.WaitForFullGCApproach(100) == GCNotificationStatus.Succeeded)
            {
                CleanData();
            }
        }
    }
}