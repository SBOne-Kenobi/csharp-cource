namespace PersonComparators;

public class CompareByAge : IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;
        return x.Age.CompareTo(y.Age);
    }
}