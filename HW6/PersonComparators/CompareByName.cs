namespace PersonComparators;

public class CompareByName : IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;

        var compByLength = x.Name.Length.CompareTo(y.Name.Length);
        if (compByLength != 0) return compByLength;
        return x.Name.Length == 0 ? 0 : x.Name.First().CompareTo(y.Name.First());
    }
}