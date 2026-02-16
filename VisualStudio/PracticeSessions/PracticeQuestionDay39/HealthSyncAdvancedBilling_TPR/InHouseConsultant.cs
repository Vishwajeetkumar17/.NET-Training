namespace HealthSyncAdvancedBilling_TPR
{
    public class InHouseConsultant : Consultant
    {
        public double MonthlyStipend { get; set; }

        public InHouseConsultant(string id, double stipend) : base(id)
        {
            MonthlyStipend = stipend;
        }

        public override double CalculateGrossPayout()
        {
            double allowances = 2000;
            double bonus = 1000;
            return MonthlyStipend + allowances + bonus;
        }
    }
}

