using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount("Artyom", 385032m);
            Console.WriteLine($"Account {account.AccountID} was created for {account.Owner}");
            Console.ReadKey();

            BankAccount invalidBankAccount;

            try
            {
                invalidBankAccount = new BankAccount("Invalid Bank Account", -120000);
            }
            catch (ArgumentOutOfRangeException ex) 
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();

            try
            {
                account.MakeWithdrawal(1000000000, DateTime.Now, "oee");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();

            Console.WriteLine(account.GetAccountHistory());

            Console.ReadKey();
        }
    }
}
