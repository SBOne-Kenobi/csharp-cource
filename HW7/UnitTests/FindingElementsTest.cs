using FindingElements;

namespace UnitTests;

public class FindingElementsTest
{
    class WithName : IWithName
    {
        private readonly string _name;

        public WithName(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }
    }
    
    [Fact]
    public void FindStrangeElementsTest()
    {
        var names = new List<string>
        {
            "John",
            "N",
            "Kate",
            "Li",
            "Alexandr"
        };
        var sample = names.Select(name => new WithName(name));
        var expected = new List<string>
        {
            "John",
            "Kate",
            "Alexandr"
        };
        var actual = sample
            .FindStrangeElements()
            .Select(item => item.GetName());
        Assert.Equal(expected, actual);
    }
}