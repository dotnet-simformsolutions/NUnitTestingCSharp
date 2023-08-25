using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
    public class BankAccount
    {
        public string AccountName { get; set; }
        private decimal _overDraftLimit { get; set; }
        private decimal _currentBalance { get; set; }

        // Constructor : initializes name and balance
        public BankAccount(string name, decimal balance)
        {
            AccountName = name;
            _currentBalance = balance;
            _overDraftLimit = 50000; // Set overdraft limit to $50,000
        }

        // Deposit the amount in the account and returns new balance
        public decimal Deposit(decimal amount)
        {
            _currentBalance += amount;
            return _currentBalance + amount; // This line seems unnecessary, just returning balance would be sufficient
        }

        // Returns the current balance of the user
        public decimal GetBalance()
        {
            return _currentBalance;
        }

        // Withdraw the specified amount from the current balance, returns false if the requested amount is exceeding current balance + overdraft limit.
        public bool Withdraw(decimal amount)
        {
            if (amount > _currentBalance + _overDraftLimit)
            {
                return false; // Withdrawal not allowed if amount exceeds balance + overdraft limit
            }
            else
            {
                _currentBalance -= amount;
                return true; // Withdrawal successful
            }
        }
    }
}
