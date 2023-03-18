using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class VendingMachine : IVendingMachine
    {
        public string Manufacturer { get; }
        public bool HasProducts => Array.Exists(Products, p => p.Available > 0);
        public Money Amount { get; private set; }
        public Product[] Products { get; set; }
        private List<Product> _productsList;

        public VendingMachine(string manufacturer)
        {
            Manufacturer = manufacturer;
            Products = Array.Empty<Product>();
            Amount = new Money { Euros = 0, Cents = 0 };
            _productsList = new List<Product>(Products);
        }

        public void DisplayProduct()
        {
            var count = 1;
            foreach (var product in _productsList)
            {
                if (product.Available < 1)
                {
                    Console.WriteLine($"{product.Name} has been sold out, wait for restock!");
                }
                else
                {
                    Console.WriteLine($"{count} ========== {product.Name} for {product.Price.Euros}.{product.Price.Cents}.");
                }
                count++;
            }
        }

        public Money InsertCoin(Money amount)
        {
            if (amount.Cents != 10 && amount.Cents != 20 && amount.Cents != 50 && amount.Cents != 0 
                && amount.Euros != 0 && amount.Euros != 1 && amount.Euros != 2)
            {
                Console.WriteLine($"Invalid coin: {amount.Euros}.{amount.Cents}.");
                return new Money();
            }

            Amount = new Money
            {
                Euros = Amount.Euros + amount.Euros,
                Cents = Amount.Cents + amount.Cents
            };

            return Amount;
        }

        public Money ReturnMoney()
        {
            var amount = Amount;
            Amount = new Money { Euros = 0, Cents = 0 };
            return amount;
        }

        public bool AddProduct(string name, Money price, int count)
        {
            if (Array.Exists(Products, p => p.Name == name))
            {
                Console.WriteLine($"Product {name} already exists.");
                return false;
            }

            _productsList.Add(new Product
            {
                Name = name,
                Price = price,
                Available = count
            });

            Console.WriteLine($"Product {name} added successfully.");
            return true;
        }

        public bool UpdateProduct(int productNumber, string name, Money? price, int amount)
        {
            if (productNumber <= 0 || productNumber > _productsList.Count)
            {
                Console.WriteLine($"Invalid product number: {productNumber}.");
                return false;
            }

            var product = _productsList[productNumber - 1];

            if (!HasProducts)
            {
                Console.WriteLine($"Product {product.Name} is sold out.");
                return false;
            }

            Console.WriteLine($"Purchase of product {name} successful!");
            Console.WriteLine($"{product.Name} for {product.Price.Euros}.{product.Price.Cents}.");

            var totalAmount  = Amount.Euros * 100 + Amount.Cents;
            var totalPrice = product.Price.Euros * 100 + product.Price.Cents;

            if (totalAmount >= totalPrice)
            {
                var change = totalAmount - totalPrice;

                Amount = new Money
                {
                    Euros = change / 100,
                    Cents = change % 100
                };
            }
            else
            {
                Console.WriteLine("You do not have enough money to buy this product.");
            }

            product.Available--;

            return true;
        }
    }
}