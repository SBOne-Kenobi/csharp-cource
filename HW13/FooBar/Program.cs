using SwitchedOutput;

var n = int.Parse(Console.ReadLine()!);
var fooBar = new FooBar.FooBar(n);
var context = new SwitchContext();

var fooAction = new Action(() => context.DoOnFirst(() => Console.Write("foo")));
var barAction = new Action(() => context.DoOnSecond(() => Console.Write("bar")));
    
var thread1 = new Thread(() =>
{
    fooBar.Foo(fooAction);
});

var thread2 = new Thread(() =>
{
    fooBar.Bar(barAction);
});

thread1.Start();
thread2.Start();
thread1.Join();
thread2.Join();
