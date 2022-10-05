using Delegates;

Console.WriteLine(Integrator.Integrate(x => x, 0, 1)); // 0.5
Console.WriteLine(Integrator.Integrate(Math.Sin, 0, Math.PI)); // 2.0
Console.WriteLine(Integrator.Integrate(x => 3 * x * x, 0, 1)); // 1.0
Console.WriteLine(Integrator.Integrate(Math.Exp, 0, Math.Log(3))); // 2.0
