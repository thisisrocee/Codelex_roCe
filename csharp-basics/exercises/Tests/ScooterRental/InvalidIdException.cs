﻿namespace ScooterRental
{
    public class InvalidIdException : Exception
    {
        public InvalidIdException() : base("Provided id is not valid.")
        {
            
        }
    }
}
