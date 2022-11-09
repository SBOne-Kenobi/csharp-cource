using TreeSerialization;

namespace UnitTests;

public class TreeSerializationTest
{
    [Fact]
    public void Test()
    {
        var tree = new Node
        {
            NodeId = 1,
            Left = new Node
            {
                NodeId = 2
            },
            Right = new Node
            {
                NodeId = 3,
                Left = new Node
                {
                    NodeId = 4
                },
                Right = new Node
                {
                    NodeId = 5
                }
            }
        };
        
        Assert.Equal(tree, Node.DeserializeNode(tree.Serialize()));
    }
}