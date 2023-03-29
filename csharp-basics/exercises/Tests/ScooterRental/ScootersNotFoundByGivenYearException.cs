namespace ScooterRental
{
    public class ScootersNotFoundByGivenYearException : Exception
    {
        public ScootersNotFoundByGivenYearException() : base("No scooters was found by given year.")
        {
            
        }
    }
}
