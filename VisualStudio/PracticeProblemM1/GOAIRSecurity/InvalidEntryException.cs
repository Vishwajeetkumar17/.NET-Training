
namespace GOAIRSecurity
{
    [Serializable]
    internal class InvalidEntryException : Exception
    {
        public InvalidEntryException()
        {
        }

        public InvalidEntryException(string? message) : base(message)
        {
        }
    }
}