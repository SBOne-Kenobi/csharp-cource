namespace SleepingBarber;

public class Client
{
    public Client(int timeToWork, OnWorkDoneAction onWorkDone)
    {
        TimeToWork = timeToWork;
        OnWorkDone = onWorkDone;
    }

    public readonly int TimeToWork;
    
    public delegate void OnWorkDoneAction();

    public readonly OnWorkDoneAction OnWorkDone;
}