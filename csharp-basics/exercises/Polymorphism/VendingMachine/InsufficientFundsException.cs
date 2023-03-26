using System;

namespace VendingMachine;

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException() : base("Provided not enough money to purchase selected product")
    {
        
    }
}