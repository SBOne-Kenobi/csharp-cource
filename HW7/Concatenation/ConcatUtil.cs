namespace Concatenation;

public interface IWithName
{
    string GetName();
}

public static class ConcatUtil
{
    public static string ConcatNames(this IEnumerable<IWithName> sample, string delimeter)
    {
        return sample
            .Select(item => item.GetName())
            .Aggregate((s, name) => s + delimeter + name);
    }
}