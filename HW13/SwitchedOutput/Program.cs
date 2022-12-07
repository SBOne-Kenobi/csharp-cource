using SwitchedOutput;

var context = new SwitchContext();

var thread1 = new Thread(() =>
{
    for (var i = 0; i < 10; i++)
    {
        context.DoOnFirst(() => Console.WriteLine("Thread 1"));
    }
});

var thread2 = new Thread(() =>
{
    for (var i = 0; i < 10; i++)
    {
        context.DoOnSecond(() => Console.WriteLine("Thread 2"));
    }
});

thread1.Start();
thread2.Start();
thread1.Join();
thread2.Join();
