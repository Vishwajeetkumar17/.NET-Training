namespace OnlineSession5
{
    [Serializable]
    internal class InvalidCreditDataException : Exception
    {
        public InvalidCreditDataException()
        {
        }

        public InvalidCreditDataException(string? message) : base(message)
        {
        }

        public InvalidCreditDataException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}