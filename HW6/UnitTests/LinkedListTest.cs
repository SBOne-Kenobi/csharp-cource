namespace UnitTests;

public class LinkedListTest
{
    [Fact]
    public void Test()
    {
        var list = new MyLinkedList.LinkedList<int>();
        var trueList = new LinkedList<int>();
        Assert.Equal(trueList.Count, list.Count);
        for (var i = 0; i < 10; ++i)
        {
            list.Add(i);
            trueList.AddLast(i);
            Assert.Equal(trueList.Count, list.Count);
            Assert.Equal(trueList.Last!.Value, list.Last);
        }

        Assert.Equal(trueList.Remove(-1), list.Remove(-1));
        Assert.Equal(trueList.Count, list.Count);
        Assert.Equal(trueList.Remove(4), list.Remove(4));
        Assert.Equal(trueList.Count, list.Count);

        var trueEnumerator = trueList.GetEnumerator();
        var enumerator = list.GetEnumerator();

        while (trueEnumerator.MoveNext())
        {
            Assert.True(enumerator.MoveNext());
            Assert.Equal(trueEnumerator.Current, enumerator.Current);
        }
        Assert.False(enumerator.MoveNext());
    }
}