namespace ScooterRental
{
    public class ScooterExistsException : Exception
    {
        public ScooterExistsException() : base("Provided scooter already exists.")
        {
            
        }
    }
}
