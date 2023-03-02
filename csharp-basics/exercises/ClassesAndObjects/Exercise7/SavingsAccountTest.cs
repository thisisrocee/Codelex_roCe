using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise7
{
    internal class SavingsAccountTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How much money is in the account?:");
            var balance = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the annual interest rate:");
            var annualRate = double.Parse(Console.ReadLine());

            Console.WriteLine("How long has the account been opened for? (in months)");
            var accountDuration = double.Parse(Console.ReadLine());

            var account = new SavingsAccount(balance);
            account.SetAnnualInterest(annualRate);

            double totalDeposit = 0;
            double totalWithdrawn = 0;
            double totalInterest = 0;

            for (int i = 1; i <= accountDuration; i++)
            {
                Console.Write($"Enter amount deposited for month: {i}:");
                var deposited = double.Parse(Console.ReadLine());
                account.Deposit(deposited);
                totalDeposit += deposited;

                Console.Write($"Enter amount withdrawn for: {i}:");
                var withdrawn = double.Parse(Console.ReadLine());
                account.Withdrawal(withdrawn);
                totalWithdrawn += withdrawn;

                account.MonthlyInterest();
            }
            totalInterest += (account.GetBalance() - balance) - totalDeposit + totalWithdrawn;

            Console.WriteLine($"Total deposited: ${totalDeposit:F2}");
            Console.WriteLine($"Total withdrawn: ${totalWithdrawn:F2}");
            Console.WriteLine($"Interest earned: ${totalInterest:F2}");
            Console.WriteLine($"Ending balance: ${account.GetBalance():F2}");
        }
    }
}
