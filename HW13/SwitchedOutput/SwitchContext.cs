namespace SwitchedOutput;

public class SwitchContext
{
    private readonly object _locker = new();
    private bool _isFirstNow = true;

    public void DoOnFirst(Action action)
    {
        lock (_locker)
        {
            while (!_isFirstNow)
            {
                Monitor.Wait(_locker);
            }
            action.Invoke();
            _isFirstNow = false;
            Monitor.PulseAll(_locker);
        }
    }

    public void DoOnSecond(Action action)
    {
        lock (_locker)
        {
            while (_isFirstNow)
            {
                Monitor.Wait(_locker);
            }
            action.Invoke();
            _isFirstNow = true;
            Monitor.PulseAll(_locker);
        }
    }
    
}