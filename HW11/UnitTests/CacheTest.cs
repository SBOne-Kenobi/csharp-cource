using Cache;

namespace UnitTests;

public class CacheTest
{
    private class DisposableInt : IDisposable
    {
        public readonly int Value;
        public bool Disposed;

        public DisposableInt(int value)
        {
            Value = value;
        }

        public void Dispose()
        {
            Disposed = true;
        }
    }
    
    [Fact]
    public void CleanAfterAdd()
    {
        const int millis = 100;
        var cache = new TypedCache<DisposableInt>(TimeSpan.FromMilliseconds(millis), 1);
        var elem = new DisposableInt(1);
        cache.PutElement(elem);
        
        Assert.False(elem.Disposed);
        
        Thread.Sleep(millis);
        cache.PutElement(new DisposableInt(2));
        
        Assert.True(elem.Disposed);
        
        cache.Dispose();
    }

    [Fact]
    public void CleanAfterGc()
    {
        const int millis = 100;
        var cache = new TypedCache<DisposableInt>(TimeSpan.FromMilliseconds(millis), 1);
        var id = cache.PutElement(new DisposableInt(0));

        Assert.False(cache.GetElement(id)?.Disposed);

        Thread.Sleep(millis);

        {
            var list = new List<byte[]>();
            for (var i = 0; i < 1000000; i++)
            {
                list.Add(new byte[1000]);
            }

            list.Clear();
        }

        Assert.Null(cache.GetElement(id));
        
        cache.Dispose();
    }
}