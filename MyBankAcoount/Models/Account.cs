using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankAcoount.Models
{
    public class Account
    {
        private double balance;

        public Account(double balance)
        {
            this.balance = balance;
        }

        public double Balance => this.balance;

        public void Withdraw(double value)
        {
            if (this.balance < value)
            {
                throw new ArgumentException("Not enough funds!"); 
            }

            this.balance -= value;
        }

        public void NewDeposit(double value)
        {
            this.balance += value;
        }

        public void Clear()
        {
            this.balance = 0;
        }
    }
}
