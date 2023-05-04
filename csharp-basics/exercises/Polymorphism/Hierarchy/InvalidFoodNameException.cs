using System;

namespace Hierarchy
{
    public class InvalidFoodNameException : Exception
    {
        public InvalidFoodNameException() : base("Provided food name was empty or null.")
        {
            
        }
    }
}