namespace Delegates;

public delegate double Function(double x);

public class Integrator
{
    private const int SegmentCount = 1000000;
    
    public static double Integrate(Function f, double a, double b)
    {
        var result = 0.0;
        var stepSize = (b - a) / SegmentCount;
        var currentX = a;
        for (var i = 0; i < SegmentCount; i++)
        {
            var nextX = currentX + stepSize;
            var x = (nextX + currentX) / 2;
            result += f(x) * stepSize;
            currentX = nextX;
        }

        return result;
    }
}