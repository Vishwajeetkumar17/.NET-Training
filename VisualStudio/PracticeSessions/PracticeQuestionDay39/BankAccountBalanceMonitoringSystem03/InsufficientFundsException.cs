namespace BankAccountBalanceMonitoringSystem03
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }
}
