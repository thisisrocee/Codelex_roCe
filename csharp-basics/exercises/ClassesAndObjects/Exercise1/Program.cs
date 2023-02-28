using System;

namespace Exercise1
{
    class Product
    {
        private string Name;
        private double Price;
        private int Amount;

        public Product(string name, double priceAtStart, int amountAtStart)
        {
            Name = name;
            Price = priceAtStart;
            Amount = amountAtStart;
        }

        public void PrintProduct()
        {
            Console.WriteLine($"{Name}, price {Price:F2}, amount {Amount}");
        }

        public void ChangePrice(double newPrice)
        {
            Price = newPrice;
        }

        public void ChangeAmount(int newAmount)
        {
            Amount = newAmount;
        }
    }

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