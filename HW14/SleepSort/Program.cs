using System.Text;

var random = new Random(42);
const int strings = 10;
var threads = new List<Thread>(strings);
var sync = new CountdownEvent(strings);
for (var i = 0; i < strings; ++i)
{
    var length = random.Next(1, 100);
    var s = new StringBuilder(length);
    for (var j = 0; j < length; ++j)
    {
        s.Append((char) random.Next('a', 'z'));
    }
    threads.Add(new Thread(() =>
    {
        sync.Signal();
        sync.Wait();
        Thread.Sleep(2 * s.Length);
        Console.WriteLine($"String length: {s.Length}\n{s}");
    }));
    threads.Last().Start();
}

foreach (var thread in threads)
{
    thread.Join();
}

