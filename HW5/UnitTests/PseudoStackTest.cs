namespace UnitTests;

public class PseudoStackTest
{
    [Fact]
    public void Test()
    {
        var trueStack = new Stack<int>();
        var pseudoStack = new PseudoStack.PseudoStack<int>(3);

        var toAdd = new List<int>(Enumerable.Range(1, 10));
        foreach (var i in toAdd)
        {
            trueStack.Push(i);
            pseudoStack.Push(i);
        }

        for (int i = 0; i < 8; i++)
        {
            Assert.Equal(trueStack.Pop(), pseudoStack.Pop());
        }
        
        foreach (var i in toAdd)
        {
            trueStack.Push(i);
            pseudoStack.Push(i);
        }

        for (int i = 0; i < trueStack.Count; i++)
        {
            Assert.Equal(trueStack.Pop(), pseudoStack.Pop());
        }
    }
}