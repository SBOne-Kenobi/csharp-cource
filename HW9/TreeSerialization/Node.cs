using System.Text;

namespace TreeSerialization;

public class Node
{
    public int NodeId { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    private const char Separator = ',';

    public string Serialize()
    {
        var builder = new StringBuilder();

        builder.Append(NodeId);
        builder.Append(Separator);

        builder.Append(Left?.Serialize() ?? "@");
        builder.Append(Separator);

        builder.Append(Right?.Serialize() ?? "@");

        return builder.ToString();
    }

    protected bool Equals(Node other)
    {
        return NodeId == other.NodeId && Equals(Left, other.Left) && Equals(Right, other.Right);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Node)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(NodeId, Left, Right);
    }

    private static Node? DeserializeImpl(Queue<string> text)
    {
        var root = new Node();

        var token = text.Dequeue();

        if (token == "@")
        {
            return null;
        }

        root.NodeId = int.Parse(token);
        root.Left = DeserializeImpl(text);
        root.Right = DeserializeImpl(text);
        return root;
    }

    public static Node? DeserializeNode(string text)
    {
        var queue = new Queue<string>(text.Split(Separator));
        return DeserializeImpl(queue);
    }
}