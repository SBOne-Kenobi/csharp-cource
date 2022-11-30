namespace CarFactoryLib.components;

public interface IStereoSystem
{
    public double Volume { get; set; }
}

public class StereoSystem : IStereoSystem
{
    public double Volume { get; set; }
}
