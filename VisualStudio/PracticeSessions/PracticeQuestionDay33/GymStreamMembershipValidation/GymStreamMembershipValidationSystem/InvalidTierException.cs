
namespace GymStreamMembershipValidationSystem
{
    [Serializable]
    public class InvalidTierException : Exception
    {
        public InvalidTierException()
        {
        }

        public InvalidTierException(string? message) : base(message)
        {
        }

        public InvalidTierException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}