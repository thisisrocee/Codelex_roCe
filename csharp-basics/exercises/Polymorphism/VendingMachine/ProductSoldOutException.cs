using System;

namespace VendingMachine;

public class ProductSoldOutException : Exception
{
    public ProductSoldOutException() : base("Provided product has been sold out.")
    {

    }
}