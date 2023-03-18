using System;
using System.Collections.Generic;
using System.Linq;

namespace UniqueValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var values = new List<string> { "Hi", "Meow", "Hello", "Meow", "Hi!", "Meow", "Hi", "Bye" };

            var uniqueValues = values.Where(s => values.Count(x => s == x) == 1).ToList();

            Console.WriteLine(string.Join(",", uniqueValues));
            Console.ReadKey();
        }
    }
}