namespace BankAccountBalanceMonitoringSystem03
{
    public class NegativeBalanceException : Exception
    {
        public NegativeBalanceException(string message) : base(message) { }
    }
}
