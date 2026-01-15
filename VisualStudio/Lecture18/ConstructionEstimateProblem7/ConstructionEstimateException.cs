
namespace ConstructionEstimateProblem7
{
    [Serializable]
    internal class ConstructionEstimateException : Exception
    {
        public ConstructionEstimateException() : base("Sorry your Construction Estimate is not Approved")
        {
        }

        public ConstructionEstimateException(string? message) : base(message)
        {
        }

        public ConstructionEstimateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}