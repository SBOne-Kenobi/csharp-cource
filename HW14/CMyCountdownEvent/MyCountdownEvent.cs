namespace CMyCountdownEvent;

public class MyCountdownEvent : IDisposable
{
    private int _count;
    private readonly AutoResetEvent _event = new(false);

    public MyCountdownEvent(int initialCount)
    {
        _count = initialCount;
    }

    public void Signal()
    {
        Signal(1);
    }

    public void Signal(int signalCount)
    {
        lock (this)
        {
            if (_count < signalCount)
            {
                throw new Exception();
            }

            _count -= signalCount;
            if (_count == 0)
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