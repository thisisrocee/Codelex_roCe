using System;
using System.Collections.Generic;

namespace Hierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            var animalsList = new List<Animal>();

            var input = "";

            while (input != "End")
            {
                input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                var animalInfo = input.Split(' ');
                var animalType = animalInfo[0];
                var animalName = animalInfo[1];
                var animalWeight = double.Parse(animalInfo[2]);
                var animalLivingRegion = animalInfo[3];

                Animal animal = null;

                switch (animalType)
                {
                    case "Mouse":
                        animal = new Mouse(animalType, animalName, animalWeight, animalLivingRegion);
                        break;
                    case "Zebra":
                        animal = new Zebra(animalType, animalName, animalWeight, animalLivingRegion);
                        break;
                    case "Cat":
                        var breed = animalInfo[4];
                        animal = new Cat(animalType, animalName, animalWeight, animalLivingRegion, breed);
                        break;
                    case "Tiger":
                        animal = new Tiger(animalType, animalName, animalWeight, animalLivingRegion);
                        break;
                }

                animal.MakeSound();
                animalsList.Add(animal);

                var foodInfo = Console.ReadLine().Split();
                var foodType = foodInfo[0];
                var foodQuantity = int.Parse(foodInfo[1]);

                Food food = null;

                if (!animal.CanEat(foodType))
                {
                    Console.WriteLine($"{animal.GetType().Name}s are not eating that type of food!");
                }
                else
                {
                    switch (foodType)
                    {
                        case "Meat":
                            food = new Meat(foodQuantity);
                            break;
                        case "Vegetable":
                            food = new Vegetable(foodQuantity);
                            break;
                    }

                    animal.Eat(food);

                    Console.WriteLine(animal);
                }
            }
            
            Console.WriteLine(string.Join(", ", animalsList));
            Console.ReadLine();
        }
    }
}