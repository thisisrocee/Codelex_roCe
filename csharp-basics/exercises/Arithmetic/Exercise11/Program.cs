Console.WriteLine(Moran(132));
Console.WriteLine(Moran(133));
Console.WriteLine(Moran(134));

static string Moran(int num)
{
    var sum = 0;
    var temp = num;

    while (temp > 0)
    {
        sum += temp % 10;
        temp /= 10;
    }

    if (num % sum == 0)
    {
        var result = num / sum;
        if (IsPrime(result))
        {
            return "M";
        }
        return "H";
    }
    return "Neither";
}

static bool IsPrime(int num)
{
    if (num < 2)
    {
        return false;
    }
    for (var i = 2; i <= Math.Sqrt(num); i++)
    {
        if (num % i == 0)
        {
            return false;
        }
    }
    return true;
}
