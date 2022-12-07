using SudokuChecker;

var test1 = new List<List<int?>>
{
    new() { 5, 3, null, null, 7, null, null, null, null },
    new() { 6, null, null, 1, 9, 5, null, null, null },
    new() { null, 9, 8, null, null, null, null, 6, null },
    new() { 8, null, null, null, 6, null, null, null, 3 },
    new() { 4, null, null, 8, null, 3, null, null, 1 },
    new() { 7, null, null, null, 2, null, null, null, 6 },
    new() { null, 6, null, null, null, null, 2, 8, null },
    new() { null, null, null, 4, 1, 9, null, null, 5 },
    new() { null, null, null, null, 8, null, null, 7, 9 },
};

Console.WriteLine(Checker.Check(test1)); // true

var test2 = new List<List<int?>>
{
    new() { 8, 3, null, null, 7, null, null, null, null },
    new() { 6, null, null, 1, 9, 5, null, null, null },
    new() { null, 9, 8, null, null, null, null, 6, null },
    new() { 8, null, null, null, 6, null, null, null, 3 },
    new() { 4, null, null, 8, null, 3, null, null, 1 },
    new() { 7, null, null, null, 2, null, null, null, 6 },
    new() { null, 6, null, null, null, null, 2, 8, null },
    new() { null, null, null, 4, 1, 9, null, null, 5 },
    new() { null, null, null, null, 8, null, null, 7, 9 },
};

Console.WriteLine(Checker.Check(test2)); // false
