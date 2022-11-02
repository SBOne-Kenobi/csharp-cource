using StringSerialization;

namespace UnitTests;

public class StringSerializationTest
{
    void CheckString(string s)
    {
        Assert.Equal(s, s.SerializeString().DeserializeString());
    }
    
    [Fact]
    public void TestRussian()
    {
        const string s = "Это улица";
        CheckString(s);
    }
    
    [Fact]
    public void TestGermany()
    {
        const string s = "das ist die Straße";
        CheckString(s);
    }
    
    [Fact]
    public void TestChinese()
    {
        const string s = "这是街";
        CheckString(s);
    }
}