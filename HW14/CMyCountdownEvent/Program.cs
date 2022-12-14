using CMyCountdownEvent;

var countdown = new MyCountdownEvent(6);

var thread = new Thread(() =>
{
    Console.WriteLine(countdown.Wait(TimeSpan.FromSeconds(1)));
    Console.WriteLine("Done!");
});
thread.Start();

var threads = new List<Thread>();
for (var i = 1; i <= 3; ++i)
{
    var cnt = i;
    threads.Add(new Thread(() =>
    {
        Console.WriteLine($"Thread signal {cnt}");
        countdown.Signal(cnt);
    }));
    threads.Last().Start();
}

thread.Join();

foreach (var t in threads)
{
    t.Join();
}
