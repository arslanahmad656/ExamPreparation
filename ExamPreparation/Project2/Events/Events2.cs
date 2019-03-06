using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Events
{
    static class Events2
    {
        public static void Run()
        {
            Demo();
        }

        static void Demo()
        {
            var account1 = new Account.Account("Arslan Ahmad", 60000M);
            account1.OnBalanceChanged += BalanceChangedEventHandler;
            account1.Credit(1000);
            account1.Debit(500);

            var account2 = new Account.Account("Asim Kabir", 75000M);
            account2.OnBalanceChanged += BalanceChangedEventHandler;
            account2.Credit(500);
            account2.Debit(1000);
        }

        static void BalanceChangedEventHandler(object sender, Account.AccountEventArgs args)
        {
            Console.WriteLine($"Transaction occurred. Details:");
            Console.WriteLine($"{sender}");
            Console.WriteLine($"{args}");
        }
    }
}
