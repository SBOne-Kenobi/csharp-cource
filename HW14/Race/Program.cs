void MakeAbs(ref int x)
{
    if (x >= 0) return;
    // uncomment to get a race condition
    // Thread.Sleep(100);
    x = -x;
}

var x = -10;

var thread1 = new Thread(() =>
{
    MakeAbs(ref x);
});

var thread2 = new Thread(() =>
{
    Thread.Sleep(50);
    x = 20;
});

thread1.Start();
thread2.Start();
thread1.Join();
thread2.Join();

Console.WriteLine(x);
// x must be 20
// if was a race condition, x must be -20
