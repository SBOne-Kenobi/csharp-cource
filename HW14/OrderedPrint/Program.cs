var foo = new Foo();
var done1 = new Data();
var done2 = new Data();
var done3 = new Data();

var thread1 = new Thread(() =>
{
    lock (done1)
    {
        foo.First();
        done1.Value = true;
        Monitor.PulseAll(done1);
    }
});

var thread2 = new Thread(() =>
{
    lock (done2)
    {
        done1.Wait();
        foo.Second();
        done2.Value = true;
        Monitor.PulseAll(done2);
    }
});

var thread3 = new Thread(() =>
{
    lock (done3)
    {
        done2.Wait();
        foo.Third();
    }
});

thread1.Start();
thread2.Start();
thread3.Start();
thread1.Join();
thread2.Join();
thread3.Join();

public class Foo
{
    public void First()
    {
        Console.Write("first");
    }

    public void Second()
    {
        Console.Write("second");
    }

    public void Third()
    {
        Console.Write("third");
    }
}

public class Data
{
    public bool Value;

    public void Wait()
    {
        lock (this)
        {
            while (!Value)
            {
                Monitor.Wait(this);
            }
        }
    }
}
