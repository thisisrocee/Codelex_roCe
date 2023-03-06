using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class TestResult
    {
        static void Main(string[] args)
        {
            var item1 = new Product("Logitech mouse", 70.00, 14);
            var item2 = new Product("iPhone 5s", 999.99, 3);
            var item3 = new Product("Epson EB-U05", 440.46, 1);

            item1.PrintProduct();
            item2.PrintProduct();
            item3.PrintProduct();

            Console.WriteLine("Changed values:");

            item3.ChangePrice(420.69);
            item1.ChangeAmount(300);

            item3.PrintProduct();
            item1.PrintProduct();
        }
    }
}
