namespace AdvancedOperations;

public static class AdvancedOperations
{
    public static double MyExp(double x)
    {
        var result = Math.Exp(x);
        Logger.Log($"MyExp({x}) = {result}");
        return result;
    }

    public static double MyLog(double x)
    {
        var result = Math.Log(x);
        Logger.Log($"MyLog({x}) = {result}");
        return result;
    }

    public static double MyAbs(double x)
    {
        var result = Math.Abs(x);
        Logger.Log($"MyAbs({x}) = {result}");
        return result;
    }
}