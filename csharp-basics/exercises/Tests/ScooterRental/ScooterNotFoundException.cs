﻿namespace ScooterRental
{
    public class ScooterNotFoundException : Exception
    {
        public ScooterNotFoundException() : base("Provided scooter was not found.")
        {
            
        }
    }
}
