namespace Hierarchy
{
    public abstract class Mammal : Animal
    {
        public string LivingRegion;

        protected Mammal(string animalType, string animalName, double animalWeight, string livingRegion)
            : base(animalType, animalName, animalWeight)
        {
            LivingRegion = livingRegion;
        }
    }
}
