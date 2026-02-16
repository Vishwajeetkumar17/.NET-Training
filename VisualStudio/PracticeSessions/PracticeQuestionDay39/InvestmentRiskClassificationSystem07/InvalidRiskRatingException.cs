namespace InvestmentRiskClassificationSystem07
{
    public class InvalidRiskRatingException : Exception
    {
        public InvalidRiskRatingException(string message) : base(message) { }
    }
}
