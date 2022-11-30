namespace CarFactoryLib.components.factory;

public class EngineBuilder
{
    private int _cylindersCount;

    public EngineBuilder SetCylindersCount(int count)
    {
        _cylindersCount = count;
        return this;
    }

    private readonly CylinderBuilder _builder = new();
    
    public EngineBuilder ConfigureCylinder(Action<CylinderBuilder> config)
    {
        config.Invoke(_builder);
        return this;
    }

    private class Engine : IEngine
    {
        public Engine(int cylinderCount, CylinderBuilder builder)
        {
            CylinderCount = cylinderCount;
            _cylinders = new List<ICylinder>(cylinderCount);
            for (int i = 0; i < cylinderCount; i++)
            {
                _cylinders.Add(builder.Build());
            }
        }

        private readonly List<ICylinder> _cylinders;

        public int CylinderCount { get; }

        public ICylinder this[int index] => _cylinders[index];
    }
    
    public IEngine Build()
    {
        return new Engine(_cylindersCount, _builder);
    }
}