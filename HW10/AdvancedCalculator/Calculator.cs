using System.Reflection;

namespace AdvancedCalculator;

public class Calculator
{
    private readonly CalcHolderBuilder _codeBuilder = new();
    private readonly DllBuilder _dllBuilder = new();

    private double _x;

    private bool ChangeXIfNeeded(string query)
    {
        if (!query.StartsWith('=')) return false;
        var value = double.Parse(query[1..].Trim().Replace('.', ','));
        _x = value;
        return true;
    }

    private Assembly Compile(string query)
    {
        _codeBuilder.SetQuery(query);
        var code = _codeBuilder.Build();
        _dllBuilder.SetCode(code);
        return _dllBuilder.CreateDll();
    }

    private double Execute(Assembly assembly)
    {
        var type = assembly.GetType("CalcHolder")!;
        var meth = type.GetMethod("MakeCalc")!;
        return (double)meth.Invoke(null, new[] { (object)_x })!;
    }

    public double? Handle(string query)
    {
        if (ChangeXIfNeeded(query))
        {
            return null;
        }

        var assembly = Compile(query);
        return Execute(assembly);
    }
}