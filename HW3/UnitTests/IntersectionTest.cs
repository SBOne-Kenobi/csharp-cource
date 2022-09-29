using Intersection;

namespace UnitTests;

public class IntersectionTest
{
    [Fact]
    public void TestEmpty()
    {
        var a = new ForwardLinkedList<int>();
        var b = new ForwardLinkedList<int>();
        
        Assert.Null(FirstCommonNodeFinder.FindFirstCommonNode(a, b));
    }
    
    
    [Fact]
    public void TestOneEmpty()
    {
        var a = new ForwardLinkedList<int>();
        var b = new ForwardLinkedList<int>();
        b.AddLast(Enumerable.Range(1, 10));
        
        Assert.Null(FirstCommonNodeFinder.FindFirstCommonNode(a, b));
        Assert.Null(FirstCommonNodeFinder.FindFirstCommonNode(b, a));
    }

    [Fact]
    public void AllCommon()
    {
        var a = new ForwardLinkedList<int>();
        a.AddLast(Enumerable.Range(1, 10));
        var b = new ForwardLinkedList<int>();
        b.AddLast(a);
        
        Assert.Equal(b.Head, FirstCommonNodeFinder.FindFirstCommonNode(a, b));
    }
    
    [Fact]
    public void NoCommon()
    {
        var a = new ForwardLinkedList<int>();
        a.AddLast(Enumerable.Range(1, 10));
        var b = new ForwardLinkedList<int>();
        b.AddLast(Enumerable.Range(1, 15));
        
        Assert.Null(FirstCommonNodeFinder.FindFirstCommonNode(a, b));
    }
    
    [Fact]
    public void SomeCommon()
    {
        var common = new ForwardLinkedList<int>();
        common.AddLast(10);
        
        var a = new ForwardLinkedList<int>();
        a.AddLast(Enumerable.Range(1, 10));
        a.AddLast(common);
        var b = new ForwardLinkedList<int>();
        b.AddLast(Enumerable.Range(1, 15));
        b.AddLast(common);
        Assert.Equal(common.Head, FirstCommonNodeFinder.FindFirstCommonNode(a, b));
        Assert.Equal(common.Head, FirstCommonNodeFinder.FindFirstCommonNode(b, a));
    }
    
    
    [Fact]
    public void FirstCommon()
    {
        var common = new ForwardLinkedList<int>();
        common.AddLast(10);
        
        var a = new ForwardLinkedList<int>();
        a.AddLast(common);
        var b = new ForwardLinkedList<int>();
        b.AddLast(Enumerable.Range(1, 10));
        b.AddLast(common);
        Assert.Equal(common.Head, FirstCommonNodeFinder.FindFirstCommonNode(a, b));
        Assert.Equal(common.Head, FirstCommonNodeFinder.FindFirstCommonNode(b, a));
    }
}