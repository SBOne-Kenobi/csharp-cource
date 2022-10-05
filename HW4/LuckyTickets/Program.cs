using LuckyTickets;

var counter = new LuckyTicketsCounter();

var resultList = new List<Tuple<int, long>>
{
    new (2, 10),
    new (4, 670),
    new (6, 55252),
    new (8, 4816030),
    new (10, 432457640),
    new (12, 39581170420),
    new (14, 3671331273480)
};

foreach (var (digitsNumber, expectedResult) in resultList)
{
    var actualResult = counter.LuckyTicket(digitsNumber);
    Console.WriteLine("LuckyTicket(" + digitsNumber + "):");
    Console.WriteLine("  Expected: " + expectedResult);
    Console.WriteLine("  Actual:   " + actualResult);
}
