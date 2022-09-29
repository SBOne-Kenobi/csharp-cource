namespace Intersection;


public static class FirstCommonNodeFinder
{
    public static Node<T>? FindFirstCommonNode<T>(ForwardLinkedList<T> a, ForwardLinkedList<T> b)
    {
        var lengthA = a.Length;
        var lengthB = b.Length;
        
        var nodeA = a.Head;
        var nodeB = b.Head;

        while (lengthA > lengthB)
        {
            --lengthA;
            nodeA = nodeA.next;
        }

        while (lengthB > lengthA)
        {
            --lengthB;
            nodeB = nodeB.next;
        }

        while (nodeA != nodeB)
        {
            nodeA = nodeA.next;
            nodeB = nodeB.next;
        }

        return nodeA;
    } 
}