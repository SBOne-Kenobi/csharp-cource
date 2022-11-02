using System.Runtime.ExceptionServices;

namespace ExceptionControl;

public class ExceptionController
{
    private readonly ExceptionDispatchInfo _info;
    
    public ExceptionController(Exception exception)
    {
        _info = ExceptionDispatchInfo.Capture(exception);
    }

    public void Throw()
    {
        _info.Throw();
    }
}