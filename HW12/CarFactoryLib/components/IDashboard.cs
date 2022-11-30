namespace CarFactoryLib.components;

public interface IDashboard
{
    public double Speed { get; }
    public double Temperature { get; }
}

public class Dashboard : IDashboard
{
    public double Speed => 90;
    public double Temperature => 24;
}
