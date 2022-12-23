namespace MyBarrierP;

public class CMyBarrier : IDisposable
{
    private readonly object _lockerIn = new();
    private readonly object _lockerOut = new();
    private readonly Semaphore _semaphore;
    private int _current;
    private bool _done;
    private readonly int _participantCount;

    public CMyBarrier(int participantCount)
    {
        _semaphore = new Semaphore(participantCount, participantCount);
        _participantCount = participantCount;
    }

    public bool SignalAndWait(TimeSpan timeout)
    {
        var hasSignal = _semaphore.WaitOne(timeout);
        if (!hasSignal)
        {
            return false;
        }

        lock (_lockerIn)
        {
            _current++;
            if (_current == _participantCount)
            {
                _done = true;
                Monitor.PulseAll(_lockerIn);
            }
            else
            {
                while (!_done)
                {
                    Monitor.Wait(_lockerIn);
                }
            }
        }

        lock (_lockerOut)
        {
            if (--_current == 0)
            {
                _done = false;
                Monitor.PulseAll(_lockerOut);
            }
            else
            {
                while (_done)
                {
                    Monitor.Wait(_lockerOut);
                }
            }
        }

        _semaphore.Release();
        return true;
    }

    public void Dispose()
    {
        _semaphore.Dispose();
    }
}