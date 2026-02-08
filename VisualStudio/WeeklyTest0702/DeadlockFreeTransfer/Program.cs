using System;
using System.Collections.Generic;
using System.Threading;

namespace DeadlockFreeTransferInput
{
    public class Account
    {
        public int Id { get; }
        public decimal Balance { get; private set; }
        private readonly object _lock = new object();

        public Account(int id, decimal balance)
        {
            Id = id;
            Balance = balance;
        }

        public object GetLock() => _lock;

        public void Debit(decimal amount)
        {
            if (Balance < amount)
                throw new InvalidOperationException("Insufficient funds");

            Balance -= amount;
        }

        public void Credit(decimal amount)
        {
            Balance += amount;
        }

        public override string ToString()
        {
            return $"Account {Id} -> Balance: {Balance}";
        }
    }
    public class Bank
    {
        public void SafeTransfer(Account a, Account b, decimal amount)
        {
            if (a == b)
                throw new ArgumentException("Cannot transfer to same account");

            Account first = a.Id < b.Id ? a : b;
            Account second = a.Id < b.Id ? b : a;

            lock (first.GetLock())
            {
                Thread.Sleep(10);
                lock (second.GetLock())
                {
                    a.Debit(amount);
                    b.Credit(amount);
                }
            }
        }
    }
    class Program
    {
        static void Main()
        {
            var accounts = new Dictionary<int, Account>();

            Console.Write("Enter number of accounts: ");
            int n = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter ID for account {i + 1}: ");
                int id = int.Parse(Console.ReadLine()!);

                Console.Write($"Enter initial balance for account {id}: ");
                decimal balance = decimal.Parse(Console.ReadLine()!);

                accounts[id] = new Account(id, balance);
            }

            Console.Write("\nFrom Account ID: ");
            int fromId = int.Parse(Console.ReadLine()!);

            Console.Write("To Account ID: ");
            int toId = int.Parse(Console.ReadLine()!);

            Console.Write("Amount to transfer: ");
            decimal amount = decimal.Parse(Console.ReadLine()!);

            var bank = new Bank();

            try
            {
                bank.SafeTransfer(accounts[fromId], accounts[toId], amount);
                Console.WriteLine("\nTransfer successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Transfer failed: {ex.Message}");
            }

            Console.WriteLine("\nFinal Balances:");
            foreach (var acc in accounts.Values)
                Console.WriteLine(acc);
        }
    }
}
