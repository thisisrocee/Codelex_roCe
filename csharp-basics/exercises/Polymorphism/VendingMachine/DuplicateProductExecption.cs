using System;

namespace VendingMachine
{
    public class DuplicateProductExecption : Exception
    {
        public DuplicateProductExecption() : base("Provided name that already exists.")
        {
            
        }
    }
}