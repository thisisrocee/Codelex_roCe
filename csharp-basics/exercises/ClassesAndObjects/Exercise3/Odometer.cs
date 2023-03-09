using System;

namespace Exercise3
{
    public class Odometer
    {
        private int _mileage;
        private FuelGauge _fuelGauge;

        public Odometer(int mileage, FuelGauge fuel)
        {
            _mileage = mileage;
            _fuelGauge = fuel;
        }

        public int GetCurrentMileage()
        {
            return _mileage;
        }

        public int ToIncrementMileage()
        {
            if (GetCurrentMileage() % 10 == 0)
            {
                _fuelGauge.ToDecrementFuel();
            }

            if (GetCurrentMileage() > 999999)
            {
                Console.WriteLine("You've reached maximum capacity of your odometer, don't worry, it's been set to 0! ;)");
                return _mileage = 0;
            }

            return _mileage++;
        }

        public string Report()
        {
            return $"Car's current mileage is {_mileage} and has {_fuelGauge.GetFuelAmount()} liters left";
        }
    }
}
