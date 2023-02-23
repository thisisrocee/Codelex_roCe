using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, n = 1;
            int x = n;
            
            Console.WriteLine("Input number of terms : ");
            n = Convert.ToInt32(Console.ReadLine());

            for (i = 0; i < n; i++)
            {
                x *= n;
            }
            Console.WriteLine(x);
            Console.ReadKey();
        }
    }
}
