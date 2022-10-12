namespace EventBus;

public class EventBus
{
    private readonly Dictionary<string, IPublisher> _publishers;

    public EventBus()
    {
        _publishers = new Dictionary<string, IPublisher>();
    }

    public void AddPublisher(string id, IPublisher publisher)
    {
        _publishers.Add(id, publisher);
    }

    public void RemovePublisher(string id)
    {
        _publishers[id].Clear();
        _publishers.Remove(id);
    }

    public void Subscribe(string id, ISubscriber subscriber)
    {
        _publishers[id].OnPost += subscriber.OnEvent;
    }

    public void Unsubscibe(string id, ISubscriber subscriber)
    {
        _publishers[id].OnPost -= subscriber.OnEvent;
    }

}