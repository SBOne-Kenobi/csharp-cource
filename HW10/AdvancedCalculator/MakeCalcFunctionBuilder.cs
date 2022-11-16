namespace AdvancedCalculator;

public class MakeCalcFunctionBuilder : IProgramBuilder
{
    private string _query = "0.0";
    
    public void SetQuery(string query)
    {
        _query = query;
    }

    public string Build()
    {
        return $@"  public static double MakeCalc(double x)
    {{
        return {_query};
    }}";
    }
}