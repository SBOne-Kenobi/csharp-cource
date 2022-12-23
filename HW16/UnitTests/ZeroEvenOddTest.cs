using System.Text;
using ZeroEvenOddP;

namespace UnitTests;

public class ZeroEvenOddTest
{
    private string Test(int n)
    {
        var output = new StringBuilder();
        var printAction = new Action<int>(num => output.Append(num));
        var zeo = new ZeroEvenOdd(n);

        var threadZero = new Thread(() =>
        {
            for (var i = 0; i < n; i++)
            {
                zeo.Zero(printAction);
            }
        });
        
        var threadEven = new Thread(() =>
        {
            for (var i = 0; i < n / 2; i++)
            {
                zeo.Even(printAction);
            }
        });
        
        var threadOdd = new Thread(() =>
        {
            for (var i = 0; i < (n + 1) / 2; i++)
            {
                zeo.Odd(printAction);
            }
        });
        
        threadZero.Start();
        threadEven.Start();
        threadOdd.Start();
        
        threadZero.Join();
        threadEven.Join();
        threadOdd.Join();

        return output.ToString();
    }
    
    [Fact]
    public void TestSmall()
    {
        Assert.Equal("0102", Test(2));
    }
    
    [Fact]
    public void TestBigger()
    {
        Assert.Equal("0102030405", Test(5));
    }
}