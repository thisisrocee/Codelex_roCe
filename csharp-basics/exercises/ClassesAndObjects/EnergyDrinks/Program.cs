using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyDrinks
{
    class Program
    {
        private const int NumberedSurveyed = 12467;
        private const double PurchasedEnergyDrinks = 0.14;
        private const double PreferCitrusDrinks = 0.64;

        private static void Main(string[] args)
        {
            var program = new Program();

            Console.WriteLine("Total number of people surveyed " + NumberedSurveyed);
            Console.WriteLine("Approximately " + program.CalculateEnergyDrinkers(NumberedSurveyed) + " bought at least one energy drink");
            Console.WriteLine(program.CalculatePreferCitrus(NumberedSurveyed) + " of those " + "prefer citrus flavored energy drinks.");
        }

        double CalculateEnergyDrinkers(int numberSurveyed)
        {
            return numberSurveyed * PurchasedEnergyDrinks;
        }

        double CalculatePreferCitrus(int numberSurveyed)
        {
            return CalculateEnergyDrinkers(numberSurveyed) * PreferCitrusDrinks;
        }
    }
}
