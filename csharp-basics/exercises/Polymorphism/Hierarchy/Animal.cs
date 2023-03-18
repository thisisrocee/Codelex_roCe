namespace Hierarchy
{
    public abstract class Animal
    {
        public string AnimalName;
        public string AnimalType;
        public double AnimalWeight;
        public int FoodEaten;

        protected Animal(string animalType, string animalName, double animalWeight)
        {
            AnimalType = animalType;
            AnimalName = animalName;
            AnimalWeight = animalWeight;
            FoodEaten = 0;
        }

        public abstract void MakeSound();
        public abstract bool CanEat(string foodType);

        public virtual void Eat(Food food)
        {
            FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{AnimalType} [{AnimalName}, {AnimalWeight}, {FoodEaten}]";
        }
    }
}
