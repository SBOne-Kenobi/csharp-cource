namespace CarFactoryLib.components.factory;

public class WheelFactory
{
    private bool _isBigWheel;

    public WheelFactory SetSize(bool isBig)
    {
        _isBigWheel = isBig;
        return this;
    }

    private record BigWheel : IWheel;

    private record SmallWheel : IWheel;

    public IWheel Build()
    {
        if (_isBigWheel)
        {
            return new BigWheel();
        }

        return new SmallWheel();
    }
}
