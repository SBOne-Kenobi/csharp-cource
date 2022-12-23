namespace H2OP;

public class H2O
{
    private readonly Semaphore _hydrogen = new(2, 2);
    private readonly Semaphore _oxygen = new(1, 1);
    private readonly Barrier _molecule = new(3);
    private readonly object _locker = new();

    public void Hydrogen(Action releaseHydrogen)
    {
        _hydrogen.WaitOne();
        _molecule.SignalAndWait();
        lock (_locker)
        {
            releaseHydrogen();
        }

        _molecule.SignalAndWait();
        _hydrogen.Release();
    }

    public void Oxygen(Action releaseOxygen)
    {
        _oxygen.WaitOne();
        _molecule.SignalAndWait();
        lock (_locker)
        {
            releaseOxygen();
        }

        _molecule.SignalAndWait();
        _oxygen.Release();
    }
}