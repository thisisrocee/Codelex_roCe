using System;

namespace Exercise7
{
    class SavingsAccount
    {
        private double _balance;
        private double _annualRate;

        public SavingsAccount(double startingBalance)
        {
            _balance = startingBalance;
        }

        public double GetBalance()
        {
            return _balance;
        }

        public void Withdrawal(double amount)
        {
            _balance -= amount;
        }

        public void Deposit(double amount)
        {
            _balance += amount;
        }

        public void SetAnnualInterest(double annualRate)
        {
            _annualRate = annualRate;
        }

        public void MonthlyInterest()
        {
            var monthlyRate = (_annualRate / 12) * _balance;
            _balance += monthlyRate;
        }
    }
}