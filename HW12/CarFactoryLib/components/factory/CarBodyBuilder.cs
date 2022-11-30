namespace CarFactoryLib.components.factory;

public class CarBodyBuilder
{
    private int _nextNumber;

    private record CarBody(int Number) : ICarBody;

    public ICarBody Build()
    {
        return new CarBody(_nextNumber++);
    }
    
}