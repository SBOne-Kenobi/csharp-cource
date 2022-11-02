using System.Runtime.ExceptionServices;
using ExceptionControl;

namespace UnitTests;

public class ExceptionControlTest
{
    private static ExceptionController GenerateException()
    {
        try
        {
            throw new Exception("Some exception");
        }
        catch (Exception e)
        {
            return new ExceptionController(e);
        }
    }

    private static void ThrowException(ExceptionController controller)
    {
        controller.Throw();
    }

    [Fact]
    public void Test()
    {
        var controller = GenerateException();
        Assert.Throws<Exception>(() => ThrowException(controller));
    }
}