namespace EventBus;

public interface IPublisher
{
    public event Action OnPost;

    public void Post();

    public void Clear();

}