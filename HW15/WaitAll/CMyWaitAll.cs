namespace WaitAll;

public class CMyWaitAll : IDisposable
{
    private readonly AutoResetEvent _event = new(false);
    private readonly object _locker = new();
    private readonly List<bool> _signaled;
    private int _remains;

    public CMyWaitAll(int atomsNumber)
    {
        _remains = atomsNumber + 1;
        _signaled = new List<bool>(_remains);
        for (var i = 0; i <= atomsNumber; i++)
        {
            _signaled.Add(false);
        }
    }

    public void SetAtomSignaled(int atomId)
    {
        lock (_locker)
        {
            if (_signaled[atomId]) return;
            
            _signaled[atomId] = true;
            _remains -= 1;
            if (_remains == 0)
            {
                _event.Set();
            }
        }
    }

    public bool Wait(TimeSpan timeout)
    {
        return _event.WaitOne(timeout);
    }

    public void Dispose()
    {
        _event.Dispose();
    }
}