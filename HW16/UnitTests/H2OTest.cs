using System.Text;
using H2OP;

namespace UnitTests;

public class H2OTest
{
    private void Check(string s)
    {
        foreach (var chars in s.Chunk(3))
        {
            var h = chars.Count(c => c == 'H');
            var o = chars.Count(c => c == 'O');
            Assert.Equal(2, h);
            Assert.Equal(1, o);
        }
    }

    private List<Task> RunH2O(string config, H2O h2O, Action<char> print)
    {
        var tasks = new List<Task>();

        foreach (var t in config)
        {
            var task = t == 'O'
                ? Task.Factory.StartNew(() => h2O.Oxygen(() => print('O')))
                : Task.Factory.StartNew(() => h2O.Hydrogen(() => print('H')));
            tasks.Add(task);
        }

        return tasks;
    }

    private void Test(string config)
    {
        var output = new StringBuilder();
        var h2O = new H2O();

        var tasks = RunH2O(config, h2O, c => output.Append(c));

        foreach (var task in tasks)
        {
            task.Wait();
        }

        var result = output.ToString();
        Assert.Equal(config.Length, result.Length);
        Check(result);
    }

    private void Repeat(int num, Action test)
    {
        for (var i = 0; i < num; i++)
        {
            test();
        }
    }

    [Fact]
    public void SimpleTest()
    {
        Test("HOH");
    }

    [Fact]
    public void GreaterTest()
    {
        Repeat(10, () => Test("OOHHHH"));
    }

    [Fact]
    public void IncompleteTest()
    {
        Repeat(10, () =>
        {
            var h2O = new H2O();
            var h = 0;
            var o = 0;

            var tasks = RunH2O("HHHHHHOO", h2O, c =>
            {
                if (c == 'H')
                {
                    h++;
                }
                else
                {
                    o++;
                }
            });

            Thread.Sleep(300);

            Assert.Equal(2, o);
            Assert.Equal(4, h);

            h2O.Oxygen(() => o++);
            foreach (var task in tasks)
            {
                task.Wait();
            }

            Assert.Equal(3, o);
            Assert.Equal(6, h);
        });
    }
}