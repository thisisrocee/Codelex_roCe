using System;

namespace GetTheCentury
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetTheCentury(1756));
            Console.WriteLine(GetTheCentury(1555));
            Console.WriteLine(GetTheCentury(1000));
            Console.WriteLine(GetTheCentury(1001));
            Console.WriteLine(GetTheCentury(2005));
            Console.ReadLine();
        }

        static string GetTheCentury(int year)
        {
            if (year <= 0)
                return "0 and negative is not allowed";
            else if (year % 100 == 0)
                return year / 100 + "th century";
            else
                return year / 100 + 1 + "th century";
        }
    }
}
