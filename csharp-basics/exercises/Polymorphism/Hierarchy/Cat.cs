using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Hierarchy
{
    public class Cat : Felime
    {
        private string _breed;

        public Cat(string animalType, string animalName, double animalWeight,
            string livingRegion, string breed) : base(animalType, animalName, animalWeight, livingRegion)
        {
            _breed = breed;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Meowwww");
        }

        public override void Eat(Food food)
        {
            FoodEaten = food.Quantity;
        }

        public override string ToString()
        {
            return $"{AnimalType}[{AnimalName}, {_breed}, {AnimalWeight}, {LivingRegion}, {FoodEaten}]";
        }

        public override bool CanEat(string foodType)
        {
            return foodType == "Meat" || foodType == "Vegetable";
        }
    }
}
