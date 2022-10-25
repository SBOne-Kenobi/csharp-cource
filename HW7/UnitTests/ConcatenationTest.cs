using Concatenation;

namespace UnitTests;

public class ConcatenationTest
{
    class Person : IWithName
    {
        private readonly string _name;

        public Person(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }
    }

    [Fact]
    public void TestConcat()
    {
        var names = new List<string>
        {
            "John", 
            "Oleg",
            "Kitty",
            "Stranger"
        };
        var sample = names.Select(name => new Person(name));
        var expected = "John, Oleg, Kitty, Stranger";
        var actual = sample.ConcatNames(", ");
        Assert.Equal(expected, actual);
    }
}