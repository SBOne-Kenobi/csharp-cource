namespace password;

public class IndexGenerator
{
    private readonly Random _random;
    private HashSet<int> _indices;

    public IndexGenerator(int size, Random random)
    {
        _random = random;
        _indices = new HashSet<int>(Enumerable.Range(0, size));
    }

    public void Exclude(int index)
    {
        _indices.Remove(index);
    }

    public bool HasNext()
    {
        return _indices.Count > 0;
    }
    
    public int NextIndex()
    {
        if (_indices.Count == 0)
        {
            throw new InvalidOperationException("Empty!");
        }
        
        var index = _random.Next(0, _indices.Count);
        var current = 0;
        var result = _indices.First(idx => index == current++);
        _indices.Remove(result);
        return result;
    }
}