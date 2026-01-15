
namespace EcommerceApplicationProblem5
{
    [Serializable]
    internal class InsufficientWalletBalanceException : Exception
    {
        public InsufficientWalletBalanceException() : base("Insufficient balance in your digital wallet")
        {
        }

        public InsufficientWalletBalanceException(string? message) : base(message)
        {
            
        }

        public InsufficientWalletBalanceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}