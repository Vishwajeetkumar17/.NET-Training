namespace BankAccountManagement
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public string AccountType { get; set; }
        public double Balance { get; set; }
        public List<Transaction> TransactionHistory { get; set; } = new List<Transaction>();
    }

    public class Transaction
    {
        public string TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
    }

    public class BankManager
    {
        private readonly List<Account> accounts = new List<Account>();
        private int accountCounter = 1;
        private int transactionCounter = 1;

        public void CreateAccount(string holder, string type, double initialDeposit)
        {
            Account account = new Account
            {
                AccountNumber = "AC" + accountCounter++,
                AccountHolder = holder,
                AccountType = type,
                Balance = initialDeposit
            };
            if (initialDeposit > 0)
            {
                account.TransactionHistory.Add(new Transaction
                {
                    TransactionId = "T" + transactionCounter++,
                    TransactionDate = DateTime.Now,
                    Type = "Deposit",
                    Amount = initialDeposit,
                    Description = "Initial Deposit"
                });
            }
            accounts.Add(account);
            Console.WriteLine("Account Created: " + account.AccountNumber);
        }

        public bool Deposit(string accountNumber, double amount)
        {
            foreach (var acc in accounts)
            {
                if (acc.AccountNumber == accountNumber)
                {
                    acc.Balance += amount;

                    acc.TransactionHistory.Add(new Transaction
                    {
                        TransactionId = "T" + transactionCounter++,
                        TransactionDate = DateTime.Now,
                        Type = "Deposit",
                        Amount = amount,
                        Description = "Deposit"
                    });

                    return true;
                }
            }
            return false;
        }

        public bool Withdraw(string accountNumber, double amount)
        {
            foreach (var acc in accounts)
            {
                if (acc.AccountNumber == accountNumber && acc.Balance >= amount)
                {
                    acc.Balance -= amount;

                    acc.TransactionHistory.Add(new Transaction
                    {
                        TransactionId = "T" + transactionCounter++,
                        TransactionDate = DateTime.Now,
                        Type = "Withdrawal",
                        Amount = amount,
                        Description = "Withdrawal"
                    });

                    return true;
                }
            }
            return false;
        }

        public Dictionary<string, List<Account>> GroupAccountsByType()
        {
            Dictionary<string, List<Account>> grouped = new Dictionary<string, List<Account>>();

            foreach (var acc in accounts)
            {
                if (!grouped.ContainsKey(acc.AccountType))
                    grouped[acc.AccountType] = new List<Account>();

                grouped[acc.AccountType].Add(acc);
            }

            return grouped;
        }

        public List<Transaction> GetAccountStatement(string accountNumber, DateTime from, DateTime to)
        {
            List<Transaction> result = new List<Transaction>();

            foreach (var acc in accounts)
            {
                if (acc.AccountNumber == accountNumber)
                {
                    foreach (var t in acc.TransactionHistory)
                    {
                        if (t.TransactionDate >= from && t.TransactionDate <= to)
                            result.Add(t);
                    }
                }
            }
            return result;
        }

        public List<Account> GetAllAccounts()
        {
            return accounts;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            BankManager manager = new BankManager();

            while (true)
            {
                Console.WriteLine("1 Create Account");
                Console.WriteLine("2 Deposit");
                Console.WriteLine("3 Withdraw");
                Console.WriteLine("4 Group Accounts");
                Console.WriteLine("5 Account Statement");
                Console.WriteLine("6 Exit");
                Console.Write("Choice: ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Write("Holder: ");
                    string h = Console.ReadLine();

                    Console.Write("Type: ");
                    string t = Console.ReadLine();

                    Console.Write("Initial Deposit: ");
                    double d = double.Parse(Console.ReadLine());

                    manager.CreateAccount(h, t, d);
                }
                else if (choice == 2)
                {
                    Console.Write("Account Number: ");
                    string num = Console.ReadLine();

                    Console.Write("Amount: ");
                    double amt = double.Parse(Console.ReadLine());

                    Console.WriteLine(manager.Deposit(num, amt) ? "Success" : "Failed");
                }
                else if (choice == 3)
                {
                    Console.Write("Account Number: ");
                    string num = Console.ReadLine();

                    Console.Write("Amount: ");
                    double amt = double.Parse(Console.ReadLine());

                    Console.WriteLine(manager.Withdraw(num, amt) ? "Success" : "Failed");
                }
                else if (choice == 4)
                {
                    var grouped = manager.GroupAccountsByType();

                    foreach (var g in grouped)
                    {
                        Console.WriteLine(g.Key);
                        foreach (var a in g.Value)
                            Console.WriteLine(a.AccountNumber + " " + a.AccountHolder + " " + a.Balance);
                        Console.WriteLine();
                    }
                }
                else if (choice == 5)
                {
                    Console.Write("Account Number: ");
                    string num = Console.ReadLine();

                    Console.Write("From (yyyy-MM-dd): ");
                    DateTime f = DateTime.Parse(Console.ReadLine());

                    Console.Write("To (yyyy-MM-dd): ");
                    DateTime t = DateTime.Parse(Console.ReadLine());

                    var list = manager.GetAccountStatement(num, f, t);

                    foreach (var tr in list)
                        Console.WriteLine(tr.TransactionId + " " + tr.Type + " " + tr.Amount + " " + tr.TransactionDate);
                }
                else if (choice == 6)
                {
                    break;
                }

                Console.WriteLine();
            }
        }
    }
}
