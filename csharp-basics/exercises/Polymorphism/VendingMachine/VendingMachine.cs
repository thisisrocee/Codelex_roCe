using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    public class VendingMachine : IVendingMachine
    {
        public string Manufacturer { get; }
        public bool HasProducts => _productsList.Any(p => p.Available > 0);
        public Money Amount { get; private set; }
        public Product[] Products { get; set; }
        private List<Product> _productsList;

        public VendingMachine(string manufacturer)
        {
            Manufacturer = manufacturer;
            _productsList = new List<Product>();
            Products = _productsList.ToArray();
            Amount = new Money { Euros = 0, Cents = 0 };
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
                    Console.WriteLine(
                        $"{count} ========== {product.Name} for {product.Price.Euros}.{product.Price.Cents}.");
                }

                count++;
            }
        }

        public Money InsertCoin(Money amount)
        {
            if (InvalidCoin(amount))
            {
                Console.WriteLine($"Invalid coin: {amount.Euros}.{amount.Cents}.");

                throw new InvalidCoinException();
            }

            Amount = new Money
            {
                Euros = Amount.Euros + amount.Euros,
                Cents = Amount.Cents + amount.Cents
            };

            return Amount;
        }

        private bool InvalidCoin(Money amount)
        {
            return amount.Cents != 10 && amount.Cents != 20 && amount.Cents != 50 && amount.Cents != 0
                   && amount.Euros != 0 && amount.Euros != 1 && amount.Euros != 2;
        }

        public Money ReturnMoney()
        {
            Amount = new Money();
            var amount = Amount;
            return amount;
        }

        public bool AddProduct(string name, Money price, int count)
        {
            if (count < 0)
            {
                throw new InvalidAmountException();
            }

            if (InvalidCoin(price))
            {
                throw new InvalidCoinException();
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidNameExecption();
            }

            if (Products.Any(p => p.Name == name))
            {
                Console.WriteLine($"Product {name} already exists.");

                throw new DuplicateProductExecption();
            }

            _productsList.Add(new Product
            {
                Name = name,
                Price = price,
                Available = count
            });

            Products = _productsList.ToArray();

            Console.WriteLine($"Product {name} added successfully.");
            return true;
        }

        public bool UpdateProduct(int productNumber, string name, Money? price, int amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountException();
            }
            
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidNameExecption();
            }
            
            if (productNumber <= 0 || productNumber > Products.Length)
            {
                Console.WriteLine($"Invalid product number: {productNumber}.");

                throw new InvalidProductNumberException();
            }

            var product = Products[productNumber - 1];

            if (!HasProducts)
            {
                Console.WriteLine($"Product {product.Name} is sold out.");

                throw new ProductSoldOutException();
            }

            var totalAmount = Amount.Euros * 100 + Amount.Cents;
            var totalPrice = (product.Price.Euros * 100 + product.Price.Cents) * amount;

            if (totalAmount < totalPrice)
            {
                Console.WriteLine("You do not have enough money to buy this product.");

                throw new InsufficientFundsException();
            }

            var change = totalAmount - totalPrice;

            Amount = new Money
            {
                Euros = change / 100,
                Cents = change % 100
            };

            Console.WriteLine($"Purchase of {amount} {(amount == 1 ? "product" : "products")} successful!");
            Console.WriteLine($"{amount} {product.Name} for {product.Price.Euros}.{product.Price.Cents}.");

            Products[productNumber - 1].Available -= amount;

            return true;
        }
    }
}