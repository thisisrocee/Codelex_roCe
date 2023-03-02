using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Bank
    {
        private string _name;
        private double _balance;

        public Bank(string name, double balance)
        {
            _name = name;
            _balance = balance;
        }

        public string ShowUserNameAndBalance()
        {
            return $"{_name}, {_balance.ToString("$#,##0.00;-$#,##0.00")}";
        }
    }
}
