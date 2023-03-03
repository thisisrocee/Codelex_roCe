using System;

namespace Account
{
    class Account
    {
        private string _name;
        private double _money;

        public Account(string v1, double v2)
        {
            _name = v1;
            _money = v2;
        }

        public void Withdrawal(double i)
        {
            _money -= i;
        }

        public void Deposit(double i)
        {
            _money += i;
        }

        public override string ToString()
        {
            return $"{_name}: {_money}";
        }

        public static void Transfer(Account from, Account to, double howMuch)
        {
            Console.WriteLine($"From account (before): {from._name}, {from._money}");
            Console.WriteLine($"To account (before): {to._name}, {to._money}");

            from._money -= howMuch;
            to._money += howMuch;

            Console.WriteLine();
            Console.WriteLine($"    From account (after): {from._name}, {from._money}");
            Console.WriteLine($"    To account (after): {to._name}, {to._money}");
            Console.WriteLine();
        }
    }
}
