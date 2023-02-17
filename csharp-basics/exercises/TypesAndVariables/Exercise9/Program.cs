using System;

namespace Exercise9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input distance in meters:");
            int distance = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Input hour:");
            int hours = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Input minutes:");
            int minutes = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Input seconds:");
            int seconds = Convert.ToInt32(Console.ReadLine());


            int timeInSeconds = hours * 3600 + minutes * 60 + seconds;

            float metersPerSecond = (float)distance / timeInSeconds;

            float kmPerHour = (float)distance / 1000 / ((float)timeInSeconds / 3600);

            float milesPerHour = (float)distance / 1609 / ((float)timeInSeconds / 3600);


            Console.WriteLine($"Your speed in meters/second is {metersPerSecond}");
            Console.WriteLine($"Your speed in km/h is {kmPerHour}");
            Console.WriteLine($"Your speed in miles/h is {milesPerHour}");
            Console.ReadKey();
        }
    }
}