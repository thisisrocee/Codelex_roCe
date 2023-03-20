using System;

namespace SumAverageRunningInt
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const int lowerBound = 1;
            const int upperBound = 100;

            Console.WriteLine(SumAverageRunningInt(lowerBound, upperBound));
        }

        private static string SumAverageRunningInt(int lowerBound, int upperBound)
        {
            var sum = 0;

            for (var number = lowerBound; number <= upperBound; number++)
            {
                sum += number;
            }

            var average = (double)sum / upperBound;
            var str = sum.ToString();
            var result = $"The sum of {lowerBound} to {upperBound} is {str}";
            var result1 = $"\nThe average is {average}";

            return result + result1;
        }
    }
}