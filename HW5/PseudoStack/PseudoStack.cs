namespace PseudoStack;

public class PseudoStack<T>
{
    private readonly List<Stack<T>> _stacks = new ();
    private readonly int _maxInStack;

    public PseudoStack() : this(10)
    {
    }

    public PseudoStack(int maxInStack)
    {
        _maxInStack = maxInStack;
    }

    public void Push(T value)
    {
        var targetStack = _stacks.LastOrDefault();
        var addNew = false;
        if (targetStack == null || targetStack.Count == _maxInStack)
        {
            targetStack = new Stack<T>(_maxInStack);
            addNew = true;
        }

        targetStack.Push(value);
        
        if (addNew)
        {
            _stacks.Add(targetStack);
        }
    }

    public T Pop()
    {
        var targetStack = _stacks.Last();
        var result = targetStack.Pop();
        if (targetStack.Count == 0)
        {
            _stacks.RemoveAt(_stacks.Count - 1);
        }
        return result;
    }
}