using AdvancedCalculator;

var calculator = new Calculator();

Console.WriteLine(@"Commands: 
    exit - exit from the calculator
    = v - set value v to x

    In other cases the calculator tries to calculate.
");

while (true)
{
    Console.Write("> ");
    var query = Console.ReadLine();
    if (query is "exit" or null)
    {
        break;
    }

    try
    {
        var result = calculator.Handle(query);
        if (result == null)
        {
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine($"= {result}");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
