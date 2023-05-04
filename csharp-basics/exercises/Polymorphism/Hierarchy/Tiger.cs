using System;

namespace Hierarchy
{
    public class Tiger : Felime
    {
        private string _livingRegion;

        public Tiger(string animalType, string animalName, double animalWeight,
            string livingRegion) : base(animalType, animalName, animalWeight, livingRegion)
        {
            _livingRegion = livingRegion;
        }

        public override void MakeSound()
        {
            Console.WriteLine("ROAAR!!!");
        }

        public override void Eat(Food food)
        {
            FoodEaten = food.Quantity;
        }

        public override bool CanEat(string foodType)
        {
            if (string.IsNullOrEmpty(foodType))
            {
                throw new InvalidFoodNameException();
            }
            
            if (foodType != "Meat")
            {
                throw new IncorrectFoodException();
            }
            
            return foodType == "Meat";
        }

        public override string ToString()
        {
            return $"{AnimalType}[{AnimalName}, {AnimalWeight}, {_livingRegion}, {FoodEaten}]";
        }
    }
}