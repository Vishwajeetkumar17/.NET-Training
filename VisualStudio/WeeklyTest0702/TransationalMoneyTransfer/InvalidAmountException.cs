
namespace TransactionalMoneyTransfer
{
    [Serializable]
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException(string? message) : base(message) { }
    }

    public class InvalidAccountException : Exception
    {
        public InvalidAccountException(string msg) : base(msg) { }
    }
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string msg) : base(msg) { }
    }
}