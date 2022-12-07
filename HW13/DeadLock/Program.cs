var mutex1 = new Mutex();
var mutex2 = new Mutex();

var thread1 = new Thread(() =>
{
    mutex1.WaitOne();
    Thread.Sleep(100);
    mutex2.WaitOne();
    mutex2.ReleaseMutex();
    mutex1.ReleaseMutex();
});

var thread2 = new Thread(() =>
{
    mutex2.WaitOne();
    mutex1.WaitOne();
    mutex1.ReleaseMutex();
    mutex2.ReleaseMutex();
});

thread1.Start();
thread2.Start();
thread1.Join();
thread2.Join();

Console.WriteLine("Unreachable");
