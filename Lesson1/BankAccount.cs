using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    //class
    internal class BankAccount
    {
        private static int _accountNumberSeed = 1000000000;
        //class objects
        public string Owner { get; private set; }
        public decimal Balance { get
            {
                decimal balance = 0m;
                foreach (var item in _allTransactions)
                    balance += item.Amount;
                return balance;
            }
        }
        public DateTime date { get; }
        public string AccountID { get; }
        private List<Transaction> _allTransactions = new List<Transaction>();



        public BankAccount(string name, decimal initialBalance)
        {
            Owner = name;
           /* Balance = initialBalance;*/
            AccountID = (_accountNumberSeed++).ToString();
            if (initialBalance<0)
                throw new ArgumentOutOfRangeException(nameof(initialBalance), "Amount of deposit must be positive");
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount),"Amount of deposit must be positive");
            var deposit = new Transaction(amount, date, note);
            _allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            if (Balance < amount)
                throw new InvalidOperationException("Not enough money. Try to withdraw less amount");
            _allTransactions.Add(new Transaction(-amount, date, note));
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();
            decimal balance = 0m;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Note}");
            }
            return report.ToString();
            
        }
    }
}
