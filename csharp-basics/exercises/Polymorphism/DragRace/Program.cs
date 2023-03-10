using System;
using System.Collections.Generic;
using System.Linq;

namespace DragRace
{
    class Program
    {
        private static void Main(string[] args)
        {
            var cars = new List<ICar>
            {
                new Audi(),
                new Bmw(),
                new Lexus(),
                new Skyline(),
                new Supra(),
                new Tesla()
            };

            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                {
                    cars.ForEach(c => c.StartEngine());
                }
                else
                {
                    if (i == 2)
                    {
                        if (cars[i] is IBoostable boost)
                        {
                            boost.UseNitrousOxideEngine();
                        }
                        cars.ForEach(c => c.SpeedUp());
                    }
                    cars.ForEach(c => c.SpeedUp()); 
                }
            }

            var highestSpeed = cars.Max(c => int.Parse(c.ShowCurrentSpeed()));
            var car = cars.First(c => c.ShowCurrentSpeed() == highestSpeed.ToString());

            Console.WriteLine($"{car.GetType().Name} : {highestSpeed}");
        }
    }
}