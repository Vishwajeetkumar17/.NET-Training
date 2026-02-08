using System;
using System.Collections.Generic;

namespace TransactionalMoneyTransfer
{

    public class Account
    {
        public string Id { get; }
        public decimal Balance { get; set; }

        public Account(string id, decimal balance)
        {
            Id = id;
            Balance = balance;
        }
    }
    public class TransferResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
    }
    public class AuditLogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[AUDIT {DateTime.Now}] {message}");
        }
    }
    public class BankService
    {
        private readonly Dictionary<string, Account> _accounts;
        private readonly AuditLogger _logger = new AuditLogger();

        public BankService(Dictionary<string, Account> accounts)
        {
            _accounts = accounts;
        }
        public TransferResult Transfer(string fromAcc, string toAcc, decimal amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException("Amount must be positive");

            if (!_accounts.ContainsKey(fromAcc))
                throw new InvalidAccountException("Source account not found");

            if (!_accounts.ContainsKey(toAcc))
                throw new InvalidAccountException("Destination account not found");

            var from = _accounts[fromAcc];
            var to = _accounts[toAcc];

            if (from.Balance < amount)
                throw new InsufficientFundsException("Not enough balance");

            decimal originalFromBalance = from.Balance;
            decimal originalToBalance = to.Balance;

            try
            {
                from.Balance -= amount;
                SimulateCredit(to, amount);

                _logger.Log($"SUCCESS: {amount} transferred {fromAcc} -> {toAcc}");

                return new TransferResult
                {
                    Success = true,
                    Message = "Transfer completed"
                };
            }
            catch (Exception ex)
            {
                from.Balance = originalFromBalance;
                to.Balance = originalToBalance;

                _logger.Log($"FAILED: Transfer rolled back ({ex.Message})");

                return new TransferResult
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        private void SimulateCredit(Account to, decimal amount)
        {
            if (amount > 5000)
                throw new Exception("Credit system failure");

            to.Balance += amount;
        }
    }
    class Program
    {
        static void Main()
        {
            var accounts = new Dictionary<string, Account>
            {
                ["A"] = new Account("A", 10000),
                ["B"] = new Account("B", 2000)
            };

            var bank = new BankService(accounts);
            var result = bank.Transfer("A", "B", 3000);

            Console.WriteLine(result.Message);
            Console.WriteLine($"A Balance: {accounts["A"].Balance}");
            Console.WriteLine($"B Balance: {accounts["B"].Balance}");
        }
    }
}
