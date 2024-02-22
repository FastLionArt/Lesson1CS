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
        }
    }
}
