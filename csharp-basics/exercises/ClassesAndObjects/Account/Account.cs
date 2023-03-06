using System;

namespace Account
{
    class Account
    {
        private string _name;
        public double Money;

        public Account(string v1, double v2)
        {
            _name = v1;
            Money = v2;
        }

        public string Name
        {
            get => _name;
        }

        public void Withdrawal(double i)
        {
            Money -= i;
        }

        public void Deposit(double i)
        {
            Money += i;
        }

        public override string ToString()
        {
            return $"{_name}: {Money}";
        }
    }
}
