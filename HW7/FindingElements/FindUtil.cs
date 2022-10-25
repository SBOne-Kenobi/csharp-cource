namespace FindingElements;

public interface IWithName
{
    string GetName();
}

public static class FindUtil
{
    public static IEnumerable<T> FindStrangeElements<T>(this IEnumerable<T> names) where T : IWithName
    {
        return names
            .Where((item, idx) => item.GetName().Length > idx);
    }
}