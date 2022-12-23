namespace ZeroEvenOddP;

internal interface IState
{
    IState GetNext();
}

internal class ZeroState : IState
{
    private bool _nextIsEven;

    public IState GetNext()
    {
        IState result;
        if (_nextIsEven)
        {
            result = new EvenState(this);
        }
        else
        {
            result = new OddState(this);
        }

        _nextIsEven = !_nextIsEven;
        return result;
    }
}

internal class EvenState : IState
{
    private readonly ZeroState _prevState;

    public EvenState(ZeroState prevState)
    {
        _prevState = prevState;
    }

    public IState GetNext()
    {
        return _prevState;
    }
}

internal class OddState : IState
{
    private readonly ZeroState _prevState;

    public OddState(ZeroState prevState)
    {
        _prevState = prevState;
    }

    public IState GetNext()
    {
        return _prevState;
    }
}

public class ZeroEvenOdd
{
    private readonly int _n;
    private int _next;
    private readonly object _locker = new();
    private IState _state = new ZeroState();

    public ZeroEvenOdd(int n)
    {
        _n = n;
    }

    private void WaitForStateAndPrint<T>(Action print)
        where T : IState
    {
        lock (_locker)
        {
            while (_state is not T)
            {
                Monitor.Wait(_locker);
            }

            print();
            _state = _state.GetNext();
            Monitor.PulseAll(_locker);
        }
    }

    public void Zero(Action<int> printNumber)
    {
        WaitForStateAndPrint<ZeroState>(() => printNumber(0));
    }

    public void Even(Action<int> printNumber)
    {
        WaitForStateAndPrint<EvenState>(() => printNumber(2 * _next));
    }

    public void Odd(Action<int> printNumber)
    {
        WaitForStateAndPrint<OddState>(() => printNumber(2 * _next++ + 1));
    }
}