using System;

namespace Exercise1
{
    class Product
    {
        private string _name;
        private double _price;
        private int _amount;

        public Product(string name, double priceAtStart, int amountAtStart)
        {
            _name = name;
            _price = priceAtStart;
            _amount = amountAtStart;
        }

        public void PrintProduct()
        {
            Console.WriteLine($"{_name}, price {_price:F2}, amount {_amount}");
        }

        public void ChangePrice(double newPrice)
        {
            _price = newPrice;
        }

        public void ChangeAmount(int newAmount)
        {
            _amount = newAmount;
        }
    }
}