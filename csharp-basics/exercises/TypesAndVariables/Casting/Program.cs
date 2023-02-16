using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casting
{
    class Program
    {
        static void Main(string[] args)
        {
            First();
            Second();
            Console.ReadKey();
        }

        static void First()
        {
            string a = "1";
            int b = 2;
            int c = 3;
            double d = 4;
            float e = 5;

            int f = int.Parse(a);

            //fixme - should be 15 :|
            double sum = f + b + c + d + e;
            Console.WriteLine(sum);
        }

        static void Second()
        {
            string a = "1";
            int b = 2;
            int c = 3;
            double d = 4.2;
            float e = 5.3f;

            int f = int.Parse(a);

            //fixme - should be 15.5 :| 
            double sum = f + b + c + d + e;
            Console.WriteLine(Math.Round(sum, 1));
        }
    }
}
