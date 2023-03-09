using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.ReadAllLines("../../lear.txt");

            int lines = file.Length, charsCount = 0;

            var query = file.Select(line =>
            {
                charsCount += line.Length;
                return line.Split(new[] { ' ', '\'' }, StringSplitOptions.RemoveEmptyEntries).Length;
            });

            var wordsCount = query.Sum();

            Console.WriteLine($"Lines = {lines}");
            Console.WriteLine($"Words = {wordsCount}");
            Console.WriteLine($"Chars = {charsCount}");
            Console.ReadKey();

        }
    }
}