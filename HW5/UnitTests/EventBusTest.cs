using EventBus;

namespace UnitTests;

class Subscriber : ISubscriber
{
    public Subscriber()
    {
        Calls = 0;
    }

    public int Calls
    {
        get;
        private set;
    }

    public void OnEvent()
    {
        ++Calls;
    }
}

class Publisher : IPublisher
{
    public event Action OnPost = delegate { };
    
    public void Post()
    {
        OnPost.Invoke();
    }

    public void Clear()
    {
        OnPost = delegate { };
    }
}

public class EventBusTest
{
    [Fact]
    public void Test()
    {
        var eventBus = new EventBus.EventBus();
        var subscriber1 = new Subscriber();
        var subscriber2 = new Subscriber();
        
        var publisher = new Publisher();
        var pubId = "pub";
        
        eventBus.AddPublisher(pubId, publisher);
        publisher.Post();
        
        eventBus.Subscribe(pubId, subscriber1);
        publisher.Post();
        publisher.Post();
        
        eventBus.Subscribe(pubId, subscriber2);
        publisher.Post();
        
        eventBus.Unsubscibe(pubId, subscriber2);
        publisher.Post();
        
        Assert.Equal(4, subscriber1.Calls);
        Assert.Equal(1, subscriber2.Calls);
    }
}