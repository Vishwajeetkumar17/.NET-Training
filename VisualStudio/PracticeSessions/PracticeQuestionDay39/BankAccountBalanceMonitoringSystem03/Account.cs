namespace BankAccountBalanceMonitoringSystem03
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string HolderName { get; set; }
        public decimal Balance { get; set; }

        public Account(string accountNumber, string holderName, decimal balance)
        {
            if (balance < 0)
                throw new NegativeBalanceException("Negative Balance Not Allowed");

            AccountNumber = accountNumber;
            HolderName = holderName;
            Balance = balance;
        }
    }
}
