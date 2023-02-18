using System;

namespace Exercise8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ievadi minūtes");
            var minutes = int.Parse(Console.ReadLine());

            var minutesInYears = 365 * 24 * 60;
            var minutesInDay = 24 * 60;

            var years = minutes / minutesInYears;
            var minutesToDays = minutes % minutesInYears;
            var days = minutesToDays / minutesInDay;

            Console.WriteLine($"It's {years} years and {days} days");

            Console.ReadKey();
        }
    }
}