var lowerBound = 1;
var upperBound = 10;

Console.WriteLine(Product1ToN(lowerBound, upperBound));
Console.ReadKey();

static int Product1ToN(int lower, int upper)
{
    var sum = lower;
<<<<<<< HEAD

    for (var number = lower; number <= upper; number++)
    {
        sum *= number;
    }

=======
    for (var number = lower; number <= upper; number++) 
    { 
    sum *= number;
    }
>>>>>>> 2b4551c0b0fdcc21e1ed954b9ebf842d84fb24b3
    return sum;
}