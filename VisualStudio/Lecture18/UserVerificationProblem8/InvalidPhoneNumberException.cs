
namespace UserVerificationProblem8
{
    [Serializable]
    internal class InvalidPhoneNumberException : Exception
    {
        public InvalidPhoneNumberException() : base("Invalid Phone Number")
        {
        }

        public InvalidPhoneNumberException(string? message) : base(message)
        {
        }

        public InvalidPhoneNumberException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}