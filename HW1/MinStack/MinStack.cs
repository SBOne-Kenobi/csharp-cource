namespace stack;

public class MinStack<T> where T : IComparable<T>
{
    private T[] _data;
    private T[] _minData;
    private int _size;
    private int _capacity;

    public MinStack()
    {
        _capacity = 8;
        _size = 0;
        _data = new T[_capacity];
        _minData = new T[_capacity];
    }

    public void Push(T item)
    {
        if (_size >= _capacity)
        {
            _capacity *= 2;
            _minData = Extend(_minData, _capacity);
            _data = Extend(_data, _capacity);
        }
        _data[_size] = item;
        
        var newMin = item;
        if (_size > 0 && item.CompareTo(_minData[_size - 1]) > 0)
        {
            newMin = _minData[_size - 1];
        }
        _minData[_size] = newMin;
        ++_size;
    }

    private static T[] Extend(T[] old, int newSize)
    {
        var newData = new T[newSize];
        old.CopyTo(newData, 0);
        return newData;
    }

    public T Peek()
    {
        CheckEmpty();
        return _data[_size - 1];
    }
    
    public void Pop()
    {
        CheckEmpty();
        --_size;
    }

    public T MinValue()
    {
        CheckEmpty();
        return _minData[_size - 1];
    }

    private void CheckEmpty()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Stack is empty!");
        }
    }
    
    public void Clear()
    {
        _size = 0;
    }

    public int Count => _size;
}