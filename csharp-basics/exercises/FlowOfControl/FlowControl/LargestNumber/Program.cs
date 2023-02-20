using System;

namespace LargestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the 1st number: ");
            var input1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Input the 2nd number: ");
            var input2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Input the 3rd number: ");
            var input3 = int.Parse(Console.ReadLine());

            Console.WriteLine(LargestNumber(input1, input2, input3));
        }

        static string LargestNumber(int input1, int input2, int input3)
        {
            var str = "";
            if (input1 > input2)
            {
                if (input1 > input3)
                    str = "The 1st Number is the greatest among three. \n\n";
                else
                    str = "The 3rd Number is the greatest among three. \n\n";
            }
            else if (input2 > input3)
                str = "The 2nd Number is the greatest among three \n\n";
            else
                str = "The 3rd Number is the greatest among three \n\n";

            return str;
        }
    }
}