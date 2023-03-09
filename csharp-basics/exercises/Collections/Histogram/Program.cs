using System;
using System.IO;
using System.Linq;

namespace Histogram
{
    class Program
    {
        private const string Path = "../../midtermscores.txt";

        public static void Main(string[] args)
        {
            var readText = File.ReadAllText(Path);

            var grades = readText.Split(' ').Select(int.Parse);

            var counts = new int[11];

            foreach (var grade in grades)
            {
                var index = grade / 10;
                counts[index]++;
            }

            for (var i = 0; i < 10; i++)
            {
                var lower = i * 10;
                Console.WriteLine($"{lower:D2} - {lower+9:D2}: {new string('*', counts[i])}");
            }

            Console.WriteLine($"    100: {new string('*', counts[10])}");

            Console.ReadKey();
        }
    }
}