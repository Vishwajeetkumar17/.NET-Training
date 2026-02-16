namespace BankAccountBalanceMonitoringSystem03
{
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string message) : base(message) { }
    }
}
