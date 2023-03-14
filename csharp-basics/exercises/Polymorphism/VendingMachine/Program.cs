using System;

namespace VendingMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Machine's manufacturer:");
            var manufacturer = Console.ReadLine();

            var machine = new VendingMachine(manufacturer);

            Console.WriteLine();
            machine.AddProduct("Soda", new Money { Euros = 1, Cents = 50 }, 5);
            machine.AddProduct("Chips", new Money { Euros = 2, Cents = 0 }, 3);
            machine.AddProduct("Candy", new Money { Euros = 0, Cents = 50 }, 10);
            machine.AddProduct("Soda", new Money { Euros = 1, Cents = 50 }, 1);
            machine.AddProduct("Prime", new Money { Euros = 2, Cents = 0 }, 3);
            machine.AddProduct("Nuts", new Money { Euros = 0, Cents = 90 }, 10);
            Console.WriteLine();

            var quit = false;

            while (!quit)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("Press 1 to buy a product");
                Console.WriteLine("Press Q to quit");
                var userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Console.WriteLine("Choose the product you want to buy:");
                    machine.DisplayProduct();
                    var productNumber = int.Parse(Console.ReadLine());

                    Console.WriteLine("Insert Euros!");
                    var euros = int.Parse(Console.ReadLine());
                    Console.WriteLine("Insert Cents!");
                    var cents = int.Parse(Console.ReadLine());

                    var insertedMoney = new Money { Euros = euros, Cents = cents };
                    var insertedAmount = machine.InsertCoin(insertedMoney);

                    if (insertedAmount.Euros == 0 && insertedAmount.Cents == 0)
                    {
                        Console.WriteLine("Invalid coin inserted. Press Any key to try again.");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }

                    machine.UpdateProduct(productNumber, $"{productNumber}", insertedMoney, 1);

                    Console.WriteLine($"Your returned balance: {machine.Amount.Euros}.{machine.Amount.Cents}");

                    machine.ReturnMoney();
                }
                else if (userInput.ToUpper() == "Q")
                {
                    Console.WriteLine($"Thank you for choosing {machine.Manufacturer}");
                    quit = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again!");
                }

                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
