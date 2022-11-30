namespace CarFactoryLib.components.factory;

public class CylinderBuilder
{
    private record Cylinder : ICylinder;

    public ICylinder Build()
    {
        return new Cylinder();
    }
}