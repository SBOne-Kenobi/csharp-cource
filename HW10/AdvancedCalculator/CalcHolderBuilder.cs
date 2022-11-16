using System.Text;

namespace AdvancedCalculator;

public class CalcHolderBuilder : IProgramBuilder
{
    private readonly MakeCalcFunctionBuilder _makeCalcBuilder = new();
    private readonly AdvancedOperatorsBuilder _operatorsBuilder = new();
    
    public void SetQuery(string query)
    {
        _makeCalcBuilder.SetQuery(query);
    }
    
    public string Build()
    {
        var builder = new StringBuilder();

        builder.AppendLine("using System.Reflection;");
        builder.AppendLine();
        builder.AppendLine("public class CalcHolder");
        builder.AppendLine("{");

        builder.AppendLine(_operatorsBuilder.Build());
        builder.AppendLine();
        builder.AppendLine(_makeCalcBuilder.Build());
        
        builder.AppendLine("}");

        return builder.ToString();
    }
}