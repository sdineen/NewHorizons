using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    //https://dotnettutorials.net/lesson/multi-threading-deadlock-interview-questions-answers/
    //Debug > Windows > Threads
    public class Deadlock
    {

        public void Start()
        {
            Console.WriteLine("Main Started");
            Account accountA = new Account(101, 5000);
            Account accountB = new Account(102, 3000);

            AccountManager accountManagerA = new AccountManager(accountA, accountB, 1000);
            Thread t1 = new Thread(accountManagerA.Transfer);
            t1.Name = "t1";

            AccountManager accountManagerB = new AccountManager(accountB, accountA, 2000);
            Thread t2 = new Thread(accountManagerB.Transfer);
            t2.Name = "t2";

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine($"Main Completed, accountA {accountA.balance} accountB {accountB.balance}");

        }

        public class Account
        {
            public double balance;
            public int id;
            public Account(int id, double balance)
            {
                this.id = id;
                this.balance = balance;
            }
            public int ID
            {
                get
                {
                    return id;
                }
            }
            public void Withdraw(double amount)
            {
                balance -= amount;
            }
            public void Deposit(double amount)
            {
                balance += amount;
            }
        }
        public class AccountManager
        {
            Account fromAccount;
            Account toAccount;
            double amountToTransfer;
            public AccountManager(Account fromAccount, Account toAccount, double amountToTransfer)
            {
                this.fromAccount = fromAccount;
                this.toAccount = toAccount;
                this.amountToTransfer = amountToTransfer;
            }
            public void Transfer()
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} trying to acquire lock on {fromAccount.ID}");

                lock (fromAccount)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock on {fromAccount.ID}");                    
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    Console.WriteLine($"{Thread.CurrentThread.Name} trying to acquire lock on {toAccount.ID}");
                    lock (toAccount)
                    {
                        Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock on {toAccount.ID}");
                        fromAccount.Withdraw(amountToTransfer);
                        toAccount.Deposit(amountToTransfer);
                    }
                }
            }
        }
    }
}