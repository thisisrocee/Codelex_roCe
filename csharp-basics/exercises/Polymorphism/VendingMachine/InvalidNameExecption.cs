using System;

namespace VendingMachine
{
    public class InvalidNameExecption : Exception
    {
        public InvalidNameExecption() : base("Provided null or empty product name.")
        {
            
        }
    }
}