using System;
using System.Security.Cryptography;

namespace Exercise7
{
    class Piglet
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Piglet!");
            Random rand = new Random();
            var randomNum = 0;
            var result = 0;

            while (randomNum != 1)
            {
                randomNum = rand.Next(1, 9);

                Console.WriteLine($"You rolled a {randomNum}!");

                if (randomNum == 1)
                {
                    result = 0;
                    Console.WriteLine($"You got {result} points.");
                    break;
                }

                result += randomNum;

                Console.WriteLine("Roll again?");
                var yesOrNo = Console.ReadLine();

                if (yesOrNo == "n")
                {
                    Console.WriteLine($"You got {result} points.");
                    break;
                }

                if (yesOrNo != "y") 
                {
                    Console.WriteLine("Invalid input, you broke the system!");
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}