using System;

namespace Exercise3
{
    internal class Test
    {
        static void Main(string[] args)
        {
            var fuel = new FuelGauge();
            var car = new Odometer(0, fuel);
            var tripLength = 4000;

            Console.WriteLine("Fill the car up, how much liters you gon fill up?");
            var liters = int.Parse(Console.ReadLine());

            fuel.ToIncrementFuel(liters);

            Console.WriteLine();

            for (var i = 0; i < tripLength; i++)
            {
                if (fuel.GetFuelAmount() > 0)
                {
                    car.ToIncrementMileage();
                    Console.WriteLine(car.Report());
                }
                else
                {
                    Console.WriteLine("You're out of gas...");
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
