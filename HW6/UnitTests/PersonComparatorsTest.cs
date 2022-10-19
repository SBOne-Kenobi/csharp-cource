using PersonComparators;

namespace UnitTests;

public class PersonComparatorsTest
{
    private static List<Person> _listOfPersons = new()
    {
        new Person("Alex", 21),
        new Person("", 0),
        new Person("Boris", 40),
        new Person("Armin", 21),
        new Person("Andre", 33),
        new Person("Grey", 23)
    };

    [Fact]
    public void TestCompareByName()
    {
        var sorted = _listOfPersons.ToList();
        sorted.Sort(new CompareByName());
        Assert.Equal("", sorted[0].Name);
        Assert.Equal("Alex", sorted[1].Name);
        Assert.Equal("Grey", sorted[2].Name);
        Assert.Equal("Boris", sorted[5].Name);
    }
    
    [Fact]
    public void TestCompareByAge()
    {
        var ages = _listOfPersons.Select(x => x.Age).ToList();
        var sorted = _listOfPersons.ToList();
        sorted.Sort(new CompareByAge());
        ages.Sort();
        Assert.Equal(ages, sorted.Select(x => x.Age));
    }
}