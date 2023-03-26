using System;

namespace Hierarchy
{
    public class IncorrectFoodException : Exception
    {
        public IncorrectFoodException() : base("Provided food is not correct.")
        {
            
        }
    }
}