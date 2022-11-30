namespace CarFactoryLib.components;

public interface IChassis
{
    public int WheelsCount { get; }
    public IWheel this[int index] { get; }
}