namespace ScooterRental.Exceptions
{
    public class LimitExceededException : Exception
    {
        public LimitExceededException() : base("Tried renting scooter the same day when limit exceeded.")
        {

        }
    }
}
