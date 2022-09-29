namespace Intersection;

public class ForwardLinkedList<T>
{
    public Node<T>? Head
    {
        get;
        private set;
    }

    public Node<T>? Tail
    {
        get
        {
            var result = Head;
            if (result == null)
            {
                return null;
            }

            while (result.next != null)
            {
                result = result.next;
            }

            return result;
        }
    }

    public void AddLast(ForwardLinkedList<T> list)
    {
        if (Head == null)
        {
            Head = list.Head;
        }
        else
        {
            Tail!.next = list.Head;
        }
    }

    public void AddLast(T value)
    {
        var newNode = new Node<T>(value);
        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            Tail!.next = newNode;
        }
    }

    public void AddLast(IEnumerable<T> enumerable)
    {
        var enumerator = enumerable.GetEnumerator();
        if (!enumerator.MoveNext())
        {
            return;
        }

        var begin = new Node<T>(enumerator.Current);
        var end = begin;
        while (enumerator.MoveNext())
        {
            var node = new Node<T>(enumerator.Current);
            end.next = node;
            end = node;
        }

        if (Head == null)
        {
            Head = begin;
        }
        else
        {
            Tail!.next = begin;
        }
    }

    public int Length
    {
        get
        {
            var result = 0;
            var current = Head;
            while (current != null)
            {
                ++result;
                current = current.next;
            }

            return result;
        }
    }
    
}

public class Node<T>
{
    public readonly T value;
    public Node<T>? next;

    public Node(T value, Node<T>? next = null)
    {
        this.value = value;
        this.next = next;
    }
}

