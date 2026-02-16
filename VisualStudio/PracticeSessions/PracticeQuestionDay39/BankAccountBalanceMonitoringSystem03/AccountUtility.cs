namespace BankAccountBalanceMonitoringSystem03
{
    public class AccountUtility
    {
        private SortedDictionary<decimal, List<Account>> accounts = new SortedDictionary<decimal, List<Account>>();

        public void AddAccount(Account account)
        {
            if (!accounts.ContainsKey(account.Balance))
                accounts[account.Balance] = new List<Account>();

            accounts[account.Balance].Add(account);
        }

        public void DisplayAccounts()
        {
            foreach (var entry in accounts)
            {
                foreach (var acc in entry.Value)
                {
                    Console.WriteLine($"Details: {acc.AccountNumber} {acc.HolderName} {acc.Balance}");
                }
            }
        }

        public void Deposit(string accountNumber, decimal amount)
        {
            if (amount <= 0)
                throw new NegativeBalanceException("Invalid Deposit Amount");

            foreach (var entry in accounts)
            {
                foreach (var acc in entry.Value)
                {
                    if (acc.AccountNumber.Equals(accountNumber))
                    {
                        entry.Value.Remove(acc);

                        acc.Balance += amount;

                        if (!accounts.ContainsKey(acc.Balance))
                            accounts[acc.Balance] = new List<Account>();

                        accounts[acc.Balance].Add(acc);
                        return;
                    }
                }
            }

            throw new AccountNotFoundException("Account Not Found");
        }

        public void Withdraw(string accountNumber, decimal amount)
        {
            if (amount <= 0)
                throw new NegativeBalanceException("Invalid Withdraw Amount");

            foreach (var entry in accounts)
            {
                foreach (var acc in entry.Value)
                {
                    if (acc.AccountNumber.Equals(accountNumber))
                    {
                        if (acc.Balance < amount)
                            throw new InsufficientFundsException("Insufficient Funds");

                        entry.Value.Remove(acc);

                        acc.Balance -= amount;

                        if (!accounts.ContainsKey(acc.Balance))
                            accounts[acc.Balance] = new List<Account>();

                        accounts[acc.Balance].Add(acc);
                        return;
                    }
                }
            }

            throw new AccountNotFoundException("Account Not Found");
        }
    }
}
