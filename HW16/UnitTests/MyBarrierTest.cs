using MyBarrierP;

namespace UnitTests;

public class MyBarrierTest
{
    [Fact]
    public void SimpleTest()
    {
        const int n = 10;
        var myBar = new CMyBarrier(n);

        var tasks = new List<Task>();
        
        var locker = new object();
        var cnt = 0;
        var maxCount = 0;
        
        for (var i = 0; i < n; i++)
        {
            tasks.Add(Task.Factory.StartNew(() =>
            {
                Thread.Sleep(200);
                Assert.True(myBar.SignalAndWait(TimeSpan.FromSeconds(1)));
                lock (locker)
                {
                    maxCount = Math.Max(maxCount, ++cnt);
                }
                Assert.True(myBar.SignalAndWait(TimeSpan.FromSeconds(1)));
                lock (locker)
                {
                    cnt--;
                }
            }));
        }
        
        Thread.Sleep(50);
        Assert.Equal(0, maxCount);
        
        foreach (var task in tasks)
        {
            task.Wait();
        }
        
        Assert.Equal(n, maxCount);
    }
}