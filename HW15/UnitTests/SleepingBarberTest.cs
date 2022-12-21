using SleepingBarber;

namespace UnitTests;

public class SleepingBarberTest
{
    [Fact]
    public void SimpleTest()
    {
        var barber = new Barber(5);

        var clientsDone = 0;
        var onDone = new Client.OnWorkDoneAction(() => { clientsDone += 1; });

        Assert.True(barber.AddClient(new Client(100, onDone)));
        Assert.True(barber.AddClient(new Client(80, onDone)));
        Assert.True(barber.AddClient(new Client(40, onDone)));
        Assert.True(barber.AddClient(new Client(10, onDone)));

        Thread.Sleep(500);
        
        Assert.Equal(4, clientsDone);
        barber.Dispose();
    }
    
    [Fact]
    public void OverflowTest()
    {
        var barber = new Barber(2);

        var clientsDone = 0;
        var onDone = new Client.OnWorkDoneAction(() => { clientsDone += 1; });

        Assert.True(barber.AddClient(new Client(100, onDone)));
        Assert.True(barber.AddClient(new Client(80, onDone)));
        Assert.True(barber.AddClient(new Client(40, onDone)));
        Assert.False(barber.AddClient(new Client(10, onDone)));

        Thread.Sleep(500);
        
        Assert.Equal(3, clientsDone);
        barber.Dispose();
    }

    [Fact]
    public void MixedTest()
    {
        var barber = new Barber(2);

        var clientsDone = 0;
        var onDone = new Client.OnWorkDoneAction(() => { clientsDone += 1; });

        Assert.True(barber.AddClient(new Client(100, onDone)));
        Assert.True(barber.AddClient(new Client(80, onDone)));
        Assert.True(barber.AddClient(new Client(40, onDone)));
        Assert.False(barber.AddClient(new Client(10, onDone)));
        Thread.Sleep(150);
        Assert.Equal(1, clientsDone);
        Assert.True(barber.AddClient(new Client(10, onDone)));
        Thread.Sleep(500);

        Assert.Equal(4, clientsDone);
        barber.Dispose();
    }
}