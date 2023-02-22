using System;

namespace TenBillion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input an integer number less than ten billion: ");

            var input = Console.ReadLine();

            long n;

            while (true)
                if (long.TryParse(input, out n))
                {
                    if (n < 0)
                    {
                        Console.WriteLine("Number is negative!");
                        break;
                    }

                    var digitLength = input.Length;

                    if (digitLength >= 11)
                    {
                        Console.WriteLine("Number is greater or equals 10,000,000,000!");
                    }
                    else
                    {
                        var digits = 1;
                        if (digitLength == 2)
                            digits = 2;
                        else if (digitLength == 3)
                            digits = 3;
                        else if (digitLength == 4)
                            digits = 4;
                        else if (digitLength == 5)
                            digits = 5;
                        else if (digitLength == 6)
                            digits = 6;
                        else if (digitLength == 7)
                            digits = 7;
                        else if (digitLength == 8)
                            digits = 8;
                        else if (digitLength == 9)
                            digits = 9;
                        else if (digitLength == 10) digits = 10;

                        Console.WriteLine("Number of digits in the number: " + digits);
                    }
                }
                else
                {
                    Console.WriteLine("The number is not a long");
                }
        }
    }
}