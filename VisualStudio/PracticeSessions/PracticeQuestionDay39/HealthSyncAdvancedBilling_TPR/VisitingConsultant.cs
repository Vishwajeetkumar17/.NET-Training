namespace HealthSyncAdvancedBilling_TPR
{
    public class VisitingConsultant : Consultant
    {
        public int ConsultationsCount { get; set; }
        public double RatePerVisit { get; set; }

        public VisitingConsultant(string id, int count, double rate) : base(id)
        {
            ConsultationsCount = count;
            RatePerVisit = rate;
        }

        public override double CalculateGrossPayout()
        {
            return ConsultationsCount * RatePerVisit;
        }

        public override double CalculateTDS(double gross)
        {
            return 0.10;
        }
    }
}

