const int potMax = 100;
const int beesCount = 10;

var canEat = new object();
var canCollect = new object();
var pot = 0;

var bearTask = Task.Factory.StartNew(() =>
{
    while (true)
    {
        lock (canEat)
        {
            while (pot < potMax)
            {
                Monitor.Wait(canEat);
            }

            lock (canCollect)
            {
                pot = 0;
                Console.WriteLine("Eat");
                Thread.Sleep(1000);
                Monitor.PulseAll(canCollect);
            }
        }
    }
});

var bees = new List<Task>(beesCount);
for (var i = 0; i < beesCount; i++)
{
    var beeNumber = i;
    bees.Add(Task.Factory.StartNew(() =>
    {
        while (true)
        {
            Thread.Sleep((int)Random.Shared.NextInt64(500, 1000));

            lock (canEat)
            {
                lock (canCollect)
                {
                    while (pot >= potMax)
                    {
                        Monitor.Wait(canCollect);
                    }

                    pot += 1;
                    Console.WriteLine($"Bee {beeNumber} puts in the pot {pot}/{potMax}");
                    if (pot >= potMax)
                    {
                        Monitor.Pulse(canEat);
                    }
                }
            }
        }
    }));
}

bearTask.Wait();
foreach (var task in bees)
{
    task.Wait();
}