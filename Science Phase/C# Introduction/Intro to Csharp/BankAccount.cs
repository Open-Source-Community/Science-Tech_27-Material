using System;
using System.Collections.Generic;
using System.Text;

namespace Introduction_to_Csharp
{
    public class BankAccount
    {
        public string Owner { get; set; }

        // private set = only this class can change the balance (encapsulation)
        public decimal Balance { get; private set; }

        public BankAccount(string owner, decimal balance)
        {
            Owner = owner;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                return false;
            }

            Balance -= amount;
            return true;
        }
    }
}
