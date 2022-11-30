using CarFactoryLib.components;
using CarFactoryLib.components.factory;

namespace CarFactoryLib;

public class CarFactory
{
    private readonly CarBodyBuilder _carBodyBuilder = new();
    private readonly EngineBuilder _engineBuilder = new();
    private readonly ChassisBuilder _chassisBuilder = new();
    private readonly TransmissionBuilder _transmissionBuilder = new();
    private IDashboard? _dashboard;
    private IStereoSystem? _stereoSystem;

    public CarFactory ConfigureCarBody(Action<CarBodyBuilder> config)
    {
        config.Invoke(_carBodyBuilder);
        return this;
    }
    
    public CarFactory ConfigureEngine(Action<EngineBuilder> config)
    {
        config.Invoke(_engineBuilder);
        return this;
    }
    
    public CarFactory ConfigureChassis(Action<ChassisBuilder> config)
    {
        config.Invoke(_chassisBuilder);
        return this;
    }
    
    public CarFactory ConfigureTransmission(Action<TransmissionBuilder> config)
    {
        config.Invoke(_transmissionBuilder);
        return this;
    }

    public CarFactory SetDashboard(IDashboard dashboard)
    {
        _dashboard = dashboard;
        return this;
    }

    public CarFactory SetStereoSystem(IStereoSystem stereoSystem)
    {
        _stereoSystem = stereoSystem;
        return this;
    }

    public Car Build()
    {
        return new Car(
            _carBodyBuilder.Build(),
            _engineBuilder.Build(),
            _chassisBuilder.Build(),
            _transmissionBuilder.Build(),
            _dashboard!,
            _stereoSystem!
        );
    }

}