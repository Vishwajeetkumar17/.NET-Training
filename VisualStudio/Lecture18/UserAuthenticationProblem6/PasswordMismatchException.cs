
namespace UserAuthenticationProblem6
{
    [Serializable]
    internal class PasswordMismatchException : Exception
    {
        public PasswordMismatchException() : base("Password entered does not match")
        {
        }

        public PasswordMismatchException(string? message) : base(message)
        {
        }

        public PasswordMismatchException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}