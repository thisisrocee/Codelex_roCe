using System;

namespace Exercise6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ievadi vairākus ciparus");
            var nums = Convert.ToInt32(Console.ReadLine());
            var sum = 0;

            while (nums != 0)
            {
                sum += nums % 10;
                nums /= 10;
            }

            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}