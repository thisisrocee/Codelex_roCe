using System;

namespace Hierarchy
{
    public class Zebra : Mammal
    {
        public Zebra(string animalType, string animalName, double animalWeight, 
            string livingRegion) : base(animalType, animalName, animalWeight, livingRegion) {}

        public override void MakeSound()
        {
            Console.WriteLine("Zebbbraaaa");
        }

        public override void Eat(Food food)
        {
            FoodEaten = food.Quantity;
        }

        public override string ToString()
        {
            return $"{AnimalType}[{AnimalName}, {AnimalWeight}, {LivingRegion}, {FoodEaten}]";
        }

        public override bool CanEat(string foodType)
        {
            return foodType == "Vegetable";
        }
    }
}
