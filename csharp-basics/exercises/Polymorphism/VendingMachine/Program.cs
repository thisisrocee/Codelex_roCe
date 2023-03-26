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

                    var validInput = false;
                    var count = 0;
                    while (!validInput)
                    {
                        Console.WriteLine("How many you need:");
                        count = int.Parse(Console.ReadLine());

                        if (count > machine.Products[productNumber - 1].Available)
                        {
                            Console.WriteLine($"Not enough number {productNumber} products in {manufacturer}");
                            continue;
                        }

                        if (count < 0)
                        {
                            Console.WriteLine($"Number is negative, Try Again!");
                            Console.WriteLine();
                            continue;
                        }

                        validInput = true;
                    }

                    var answer = "";
                    
                    while (answer != "n")
                    {
                        Console.WriteLine("Insert Euros!");
                        var euros = int.Parse(Console.ReadLine());
                        Console.WriteLine("Insert Cents!");
                        var cents = int.Parse(Console.ReadLine());

                        var insertedMoney = new Money { Euros = euros, Cents = cents };
                        machine.InsertCoin(insertedMoney);

                        Console.WriteLine("Want to insert more? y/n");
                        answer = Console.ReadLine();
                    }

                    machine.UpdateProduct(productNumber, $"{productNumber}", null, count);

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