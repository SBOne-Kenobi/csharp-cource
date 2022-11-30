namespace CarFactoryLib.components.factory;

public class ChassisBuilder
{
    private int _wheelCount;

    public ChassisBuilder SetWheelCount(int count)
    {
        _wheelCount = count;
        return this;
    }

    private readonly WheelFactory _factory = new();

    public ChassisBuilder ConfigureWheels(Action<WheelFactory> config)
    {
        config.Invoke(_factory);
        return this;
    }

    private class Chassis : IChassis
    {
        public Chassis(int wheelsCount, WheelFactory factory)
        {
            WheelsCount = wheelsCount;
            _wheels = new List<IWheel>(wheelsCount);
            for (var i = 0; i < wheelsCount; i++)
            {
                _wheels.Add(factory.Build());
            }
        }

        private readonly List<IWheel> _wheels;

        public int WheelsCount { get; }

        public IWheel this[int index] => _wheels[index];
    }

    public IChassis Build()
    {
        return new Chassis(_wheelCount, _factory);
    }
}