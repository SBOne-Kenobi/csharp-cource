using System.Runtime.Serialization.Formatters.Binary;
using GroupsSerialization;

namespace UnitTests;

public class GroupsSerializationTest
{
    [Fact]
    [Obsolete("Obsolete")]
    public void Test()
    {
        var group = new Group(Decimal.Zero, "Group");
        var studentA = new Student(Decimal.Zero, "A", "a", 0, group);
        var studentB = new Student(Decimal.One, "B", "b", 1, group);

        group.Students = new List<Student>()
        {
            studentA, studentB
        };
        
        var formatter = new BinaryFormatter();
        var stream = new MemoryStream();
        formatter.Serialize(stream, group);
        stream.Position = 0;

        var deserializedGroup = (Group) formatter.Deserialize(stream);
        Assert.Equal(group, deserializedGroup);
    }
}