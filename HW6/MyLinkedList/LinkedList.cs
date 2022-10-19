using System.Collections;

namespace MyLinkedList;

class LinkedListNode<T>
{
    public readonly T Value;
    public LinkedListNode<T>? Next;
    public LinkedListNode<T>? Prev;

    public LinkedListNode(T value)
    {
        Value = value;
    }
}

public class LinkedList<T> : IEnumerable<T>
{
    public int Count
    {
        get
        {
            var result = 0;
            var current = _head;
            while (current != null)
            {
                ++result;
                current = current.Next;
            }

            return result;
        }
    }

    public T First => _head!.Value;
    public T Last => _tail!.Value;

    private LinkedListNode<T>? _head;
    private LinkedListNode<T>? _tail;

    public void Add(T value)
    {
        var node = new LinkedListNode<T>(value);
        if (_tail == null)
        {
            _head = _tail = node;
            return;
        }

        _tail.Next = node;
        node.Prev = _tail;
        _tail = node;
    }

    private void Remove(LinkedListNode<T> node)
    {
        if (node.Prev == null)
        {
            // node == head
            if (node.Next == null)
            {
                _head = _tail = null;
            }
            else
            {
                _head = node.Next;
                node.Next.Prev = null;
            }
        }
        else if (node.Next == null)
        {
            // node == tail
            _tail = node.Prev;
            node.Prev.Next = null;
        }
        else
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
        }

        node.Next = node.Prev = null;
    }

    private LinkedListNode<T> GetByIndex(int index)
    {
        var curIndex = 0;
        var current = _head;
        while (curIndex < index && current != null)
        {
            ++curIndex;
            current = current.Next;
        }

        if (current == null)
        {
            throw new IndexOutOfRangeException();
        }

        return current;
    }

    public T Get(int index)
    {
        var current = GetByIndex(index);
        return current.Value;
    }

    public bool Remove(T value)
    {
        var current = _head;
        while (current != null && !current.Value.Equals(value))
        {
            current = current.Next;
        }

        if (current == null) return false;

        Remove(current);
        return true;
    }

    private class Enumerator : IEnumerator<T>
    {
        private readonly LinkedListNode<T>? _head;
        private LinkedListNode<T>? _current;
        private bool _reachEnd;

        public Enumerator(LinkedListNode<T>? head)
        {
            _head = head;
            _current = null;
            _reachEnd = false;
        }

        public bool MoveNext()
        {
            if (_reachEnd)
            {
                return false;
            }

            _current = _current == null ? _head : _current.Next;

            if (_current != null) return true;
            
            _reachEnd = true;
            return false;
        }

        public void Reset()
        {
            _current = null;
            _reachEnd = false;
        }

        public T Current => _current!.Value;

        object IEnumerator.Current => Current!;

        public void Dispose() { }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(_head);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}