using System;

namespace VendingMachine
{
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException() : base("Provided negative product amount.")
        {
            
        }
    }
}