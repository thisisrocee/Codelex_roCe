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

            Account.Transfer(aAccount, bAccount, 50.0);
            Account.Transfer(bAccount, cAccount, 25.0);
        }
    }
}
