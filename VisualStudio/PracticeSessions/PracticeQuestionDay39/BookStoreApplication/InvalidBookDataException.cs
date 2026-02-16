namespace BookStoreApplication
{
    [Serializable]
    internal class InvalidBookDataException : Exception
    {
        public InvalidBookDataException()
        {
        }

        public InvalidBookDataException(string? message) : base(message)
        {
        }

        public InvalidBookDataException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}