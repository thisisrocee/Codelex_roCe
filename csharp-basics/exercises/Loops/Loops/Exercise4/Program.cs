using System;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            Console.Write("For: ");

            for (var i = 0; i < vowels.Length; i++)
            {
                Console.Write(vowels[i]);
            }

            Console.WriteLine(string.Empty);
            Console.Write("Foreach: ");

            foreach (var letter in vowels)
            {
                Console.Write(letter);
            }
            Console.ReadKey();
        }
    }
}
