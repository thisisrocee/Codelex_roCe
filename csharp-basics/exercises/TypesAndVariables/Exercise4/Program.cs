using System;

namespace Exercise4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ievadi savu vārdu");
            String name = Console.ReadLine();
            Console.WriteLine("Ievadi savu dzimšanas gadu!");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"My name is {name} and I was born in {year}.");
        }
    }
}