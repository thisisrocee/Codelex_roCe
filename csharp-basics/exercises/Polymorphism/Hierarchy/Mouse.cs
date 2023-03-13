using System;

namespace Hierarchy
{
    public class Mouse : Mammal
    {
        public Mouse(string animalType, string animalName, double animalWeight,
            string livingRegion) : base(animalType, animalName, animalWeight, livingRegion) {}

        public override void MakeSound()
        {
            Console.WriteLine("Piiiii");
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