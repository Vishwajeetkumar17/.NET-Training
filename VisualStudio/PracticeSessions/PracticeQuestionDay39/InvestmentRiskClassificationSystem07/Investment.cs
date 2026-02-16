namespace InvestmentRiskClassificationSystem07
{
    public class Investment
    {
        public string InvestmentId { get; set; }
        public string AssetName { get; set; }
        public int RiskRating { get; set; }

        public Investment(string investmentId, string assetName, int riskRating)
        {
            if (riskRating < 1 || riskRating > 5)
                throw new InvalidRiskRatingException("Invalid Risk Rating");

            InvestmentId = investmentId;
            AssetName = assetName;
            RiskRating = riskRating;
        }
    }
}
