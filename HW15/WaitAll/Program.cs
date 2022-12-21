using WaitAll;

void SimpleTest()
{
    var atoms = 10;
    var wait = new CMyWaitAll(atoms);

    var tasks = new List<Task>(atoms + 1);
    for (var i = 0; i <= atoms; i++)
    {
        var id = i;
        tasks.Add(Task.Factory.StartNew(() =>
        {
            Thread.Sleep((int) Random.Shared.NextInt64(500, 1000));
            Console.WriteLine($"Signal {id}");
            wait.SetAtomSignaled(id);
        }));
    }
    
    var result = wait.Wait(TimeSpan.FromSeconds(2));
    Console.WriteLine($"Result {result}");

    Task.WaitAll(tasks.ToArray());
}

void WaitFalseTest()
{
    var atoms = 10;
    var wait = new CMyWaitAll(atoms);

    var tasks = new List<Task>(atoms + 1);
    for (var i = 0; i <= atoms; i++)
    {
        var id = i;
        tasks.Add(Task.Factory.StartNew(() =>
        {
            Thread.Sleep((int) Random.Shared.NextInt64(100 + 10 * id, 100 + 50 * id));
            Console.WriteLine($"Signal {id}");
            wait.SetAtomSignaled(id);
        }));
    }
    
    var result = wait.Wait(TimeSpan.FromMilliseconds(300));
    Console.WriteLine($"Result {result}");
    result = wait.Wait(TimeSpan.FromSeconds(2));
    Console.WriteLine($"Result {result}");

    Task.WaitAll(tasks.ToArray());
}

void LargeTest()
{
    var atoms = 99;
    var signaled = 0;
    var locker = new object();
    
    var wait = new CMyWaitAll(atoms);

    var tasks = new List<Task>(atoms + 1);
    for (var i = 0; i <= atoms; i++)
    {
        var id = i;
        tasks.Add(Task.Factory.StartNew(() =>
        {
            Thread.Sleep((int) Random.Shared.NextInt64(400, 2000));
            lock (locker)
            {
                signaled += 1;
                if (signaled % 10 == 0)
                {
                    Console.WriteLine($"Signaled {signaled}/{atoms + 1}");
                }                
            }
            wait.SetAtomSignaled(id);
        }));
    }
    
    var result = wait.Wait(TimeSpan.FromSeconds(50));
    Console.WriteLine($"Result {result}");

    Task.WaitAll(tasks.ToArray());
}

void RunTest(string name, Action test)
{
    Console.WriteLine($"Start {name}");
    test();
    Console.WriteLine("Test end\n---------------------\n");
}

RunTest("Simple test", SimpleTest);
RunTest("Wait false test", WaitFalseTest);
RunTest("Large test", LargeTest);

