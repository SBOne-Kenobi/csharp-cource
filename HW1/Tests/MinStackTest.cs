using stack;

namespace Tests;

public class MinStackTest
{

    [Fact]
    public void PushTest()
    {
        var stack = new MinStack<int>();
        const int expectedSize = 10000;
        for (var i = 0; i < expectedSize; i++)
        {
            Assert.Equal(i, stack.Count);
            stack.Push(Random.Shared.Next());
        }
        Assert.Equal(expectedSize, stack.Count);
    }

    [Fact]
    public void PeakTest()
    {
        var stack = new MinStack<int>();
        const int pushes = 10000;
        var data = new int[pushes];
        for (var i = 0; i < pushes; i++)
        {
            var elem = Random.Shared.Next();
            stack.Push(elem);
            data[i] = elem;
        }
        for (var i = 0; i < pushes; i++)
        {
            Assert.Equal(pushes - i, stack.Count);
            var elem = stack.Peek();
            stack.Pop();
            Assert.Equal(data[pushes - i - 1], elem);
        }
        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void MinValueTest()
    {
        var stack = new MinStack<int>();
        const int pushes = 10000;
        var data = new Stack<int>();
        for (var i = 0; i < pushes; i++)
        {
            var elem = Random.Shared.Next();
            stack.Push(elem);
            data.Push(elem);
            Assert.Equal(data.Min(), stack.MinValue());
        }
        for (var i = 0; i < pushes; i++)
        {
            Assert.Equal(pushes - i, stack.Count);
            Assert.Equal(data.Min(), stack.MinValue());
            var elem = stack.Peek();
            stack.Pop();
            var expected = data.Peek();
            data.Pop();
            Assert.Equal(expected, elem);
        }
        Assert.Equal(0, stack.Count);
    }
}