var lowerBound = 1;
var upperBound = 10;

Console.WriteLine(Product1ToN(lowerBound, upperBound));
Console.ReadKey();

static int Product1ToN(int lower, int upper)
{
    var sum = lower;

    for (var number = lower; number <= upper; number++)
    {
        sum *= number;
    }

    return sum;
}