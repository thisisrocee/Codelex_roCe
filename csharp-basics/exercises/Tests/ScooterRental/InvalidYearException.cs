using System.Diagnostics;

namespace ScooterRental
{
    public class InvalidYearException : Exception
    {
        public InvalidYearException() :  base("Provided negative year.")
        {
            
        }
    }
}
