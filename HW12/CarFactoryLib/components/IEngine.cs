namespace CarFactoryLib.components;

public interface IEngine
{
    public int CylinderCount { get; }

    public ICylinder this[int index] { get; }
}