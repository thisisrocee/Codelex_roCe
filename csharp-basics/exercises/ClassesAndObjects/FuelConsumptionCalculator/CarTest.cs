using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelConsumptionCalculator
{
    class CarTest
    {
        private static void Main(string[] args)
        {
            int startKilometers;
            int liters;

            Console.WriteLine("Enter Car starting odometer!");
            var startOdoCar = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine("Enter Car1 starting odometer!");
            var startOdoCar1 = int.Parse(Console.ReadLine());

            Car car = new Car(startOdoCar);
            Car car1 = new Car(startOdoCar1);

            for (int i = 1; i <= 3; i++)
            {
                Console.Write($"Enter {i}. reading for car: ");
                startKilometers = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter liters reading: ");
                liters = Convert.ToInt32(Console.ReadLine());
                car.FillUp(startKilometers, liters);

                Console.Write($"Enter {i}. reading for car1: ");
                startKilometers = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter liters reading: ");
                liters = Convert.ToInt32(Console.ReadLine());
                car1.FillUp(startKilometers, liters);
            }

            Console.WriteLine("Car Kilometers per liter are " + car.CalculateConsumption() + " gasHog:" + car.GasHog());
            Console.WriteLine("Car1 Kilometers per liter are " + car1.CalculateConsumption()+ " economyCar:" + car.EconomyCar());
            Console.ReadKey();
        }
    }
}
