namespace InvestmentRiskClassificationSystem07
{
    public class InvestmentUtility
    {
        private SortedDictionary<int, List<Investment>> investments = new SortedDictionary<int, List<Investment>>();

        public void AddInvestment(Investment investment)
        {
            foreach (var list in investments.Values)
            {
                foreach (var inv in list)
                {
                    if (inv.InvestmentId.Equals(investment.InvestmentId))
                        throw new DuplicateInvestmentException("Duplicate Investment");
                }
            }

            if (!investments.ContainsKey(investment.RiskRating))
                investments[investment.RiskRating] = new List<Investment>();

            investments[investment.RiskRating].Add(investment);
        }

        public void DisplayInvestments()
        {
            foreach (var entry in investments)
            {
                foreach (var inv in entry.Value)
                {
                    Console.WriteLine($"Details: {inv.InvestmentId} {inv.AssetName} {inv.RiskRating}");
                }
            }
        }

        public void UpdateRisk(string investmentId, int newRisk)
        {
            if (newRisk < 1 || newRisk > 5)
                throw new InvalidRiskRatingException("Invalid Risk Rating");

            foreach (var entry in investments)
            {
                foreach (var inv in entry.Value)
                {
                    if (inv.InvestmentId.Equals(investmentId))
                    {
                        entry.Value.Remove(inv);

                        inv.RiskRating = newRisk;

                        if (!investments.ContainsKey(newRisk))
                            investments[newRisk] = new List<Investment>();

                        investments[newRisk].Add(inv);
                        return;
                    }
                }
            }

            throw new DuplicateInvestmentException("Investment Not Found");
        }
    }
}
