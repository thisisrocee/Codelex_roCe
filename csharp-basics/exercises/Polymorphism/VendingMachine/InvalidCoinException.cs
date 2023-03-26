using System;

namespace VendingMachine
{
    public class InvalidCoinException : Exception
    {
        public InvalidCoinException() : base("Invalid coin inserted.")
        {
            
        }
    }
}