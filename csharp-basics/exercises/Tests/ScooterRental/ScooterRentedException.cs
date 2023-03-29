namespace ScooterRental
{
    public class ScooterRentedException : Exception
    {
        public ScooterRentedException() : base("Provided scooter is rented.")
        {
            
        }
    }
}
