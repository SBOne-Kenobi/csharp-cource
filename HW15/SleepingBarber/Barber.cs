namespace SleepingBarber;

public class Barber : IDisposable
{
    private readonly int _waiterSeats;

    private readonly Queue<Client> _queue = new();

    private readonly object _waiters = new();

    private readonly Task _barberTask;

    private bool _terminate;

    public Barber(int waiterSeats)
    {
        _waiterSeats = waiterSeats;
        _barberTask = Task.Factory.StartNew(() =>
        {
            while (!_terminate)
            {
                Client client;
                lock (_waiters)
                {
                    while (!_terminate && _queue.Count == 0)
                    {
                        Monitor.Wait(_waiters);
                    }
                    
                    if (_terminate) return;

                    client = _queue.Dequeue();
                }

                Thread.Sleep(client.TimeToWork);
                client.OnWorkDone();
            }
        });
    }

    public bool AddClient(Client client)
    {
        if (_terminate) return false;
        lock (_waiters)
        {
            if (_queue.Count >= _waiterSeats) return false;

            _queue.Enqueue(client);
            if (_queue.Count == 1)
            {
                Monitor.Pulse(_waiters);
            }

            return true;
        }
    }

    public void Dispose()
    {
        _terminate = true;
        lock (_waiters)
        {
            Monitor.PulseAll(_waiters);
        }
        _barberTask.Wait();
    }
}