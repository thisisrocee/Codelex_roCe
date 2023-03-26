using System;

namespace VendingMachine
{
    public class InvalidProductNumberException : Exception
    {
        public InvalidProductNumberException() : base("Product number provided negative or invalid.")
        {
            
        }
    }
}