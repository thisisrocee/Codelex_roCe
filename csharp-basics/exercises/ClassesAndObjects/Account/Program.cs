using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
    class Program
    {
        private static void Main(string[] args)
        {
            Account account = new Account("unknown account", 100.00);

            account.Deposit(20.0);
            Console.WriteLine(account.ToString());

            Account mattAccount = new Account("Matt's account", 1000.00);
            Account myAccount = new Account("My account", 0);

            mattAccount.Withdrawal(100.0);
            myAccount.Deposit(100.0);

            Console.WriteLine(mattAccount.ToString());
            Console.WriteLine(myAccount.ToString());

            Console.WriteLine();

            Account aAccount = new Account("A account", 100.00);
            Account bAccount = new Account("B account", 0.0);
            Account cAccount = new Account("C account", 0.0);

            Transfer(aAccount, bAccount, 50.0);
            Transfer(bAccount, cAccount, 25.0);
        }

        public static void Transfer(Account from, Account to, double howMuch)
        {
            Console.WriteLine($"From account (before): {from.Name}, {from.Money}");
            Console.WriteLine($"To account (before): {to.Name}, {to.Name}");

            from.Money -= howMuch;
            to.Money += howMuch;

            Console.WriteLine();
            Console.WriteLine($"    From account (after): {from.Name}, {from.Money}");
            Console.WriteLine($"    To account (after): {to.Name}, {to.Money}");
            Console.WriteLine();
        }
    }
}
