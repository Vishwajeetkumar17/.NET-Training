
namespace CustomExceptionLoginAttempts
{
    [Serializable]
    internal class LoginAttempt : Exception
    {
        public LoginAttempt()
        {
        }

        public LoginAttempt(string? message) : base(message)
        {
        }

        public LoginAttempt(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}