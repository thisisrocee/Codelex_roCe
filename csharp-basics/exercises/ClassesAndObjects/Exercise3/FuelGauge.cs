using System;

namespace Exercise3
{
    public class FuelGauge
    {
        private int _fuelLeft;

        public int GetFuelAmount()
        {
            return _fuelLeft;
        }

        public int ToIncrementFuel(int liters)
        {
            if (liters > 70)
            {
                Console.WriteLine("Limit is 70 liters!");
                return _fuelLeft;
            }

            return _fuelLeft += liters;
        }

        public int ToDecrementFuel()
        {
            return _fuelLeft > 0 ? _fuelLeft-- : _fuelLeft;
        }
    }
}
