using System;

namespace Exercise7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ievadi vārdu vai teikumu!");
            String str = Console.ReadLine();

            char[] charArr = new char[str.Length];
            int sum = 0;

            for (int i = 0; i < str.Length; i++)
            {
                charArr[i] = str[i];
                sum += char.IsUpper(charArr[i]) ? 1 : 0;
            }

            Console.WriteLine("Šajā tekstā ir {0} Lielie burti", sum);
        }
    }
}