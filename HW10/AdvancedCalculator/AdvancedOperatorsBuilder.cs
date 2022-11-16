using System.Text;

namespace AdvancedCalculator;

public class AdvancedOperatorsBuilder : IProgramBuilder
{
    private static string BuildMethod(string methodName)
    {
        return $@"  public static double {methodName}(double x)
    {{
        var a = Assembly.Load(""AdvancedOperations"");
        var type = a.GetType(""AdvancedOperations.AdvancedOperations"")!;
        var m = type.GetMethod(""{methodName}"")!;
        var param = new object[1];
        param[0] = x;
        return (double) m.Invoke(null, param);
    }}";
    }
    
    public string Build()
    {
        var builder = new StringBuilder();
        builder.AppendLine(BuildMethod("MyAbs"));
        builder.AppendLine();
        builder.AppendLine(BuildMethod("MyLog"));
        builder.AppendLine();
        builder.AppendLine(BuildMethod("MyExp"));
        builder.AppendLine();
        return builder.ToString();
    }
}