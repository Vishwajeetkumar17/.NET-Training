namespace HealthSyncAdvancedBilling_TPR
{
    public abstract class Consultant
    {
        public string ConsultantId { get; set; }

        protected Consultant(string consultantId)
        {
            if (!ValidateConsultantId(consultantId))
                throw new Exception("Invalid doctor id");

            ConsultantId = consultantId;
        }

        public static bool ValidateConsultantId(string id)
        {
            if (id.Length != 6) return false;
            if (!id.StartsWith("DR")) return false;

            string numericPart = id.Substring(2);
            int number;
            return int.TryParse(numericPart, out number);

        }

        public abstract double CalculateGrossPayout();

        public virtual double CalculateTDS(double gross)
        {
            if (gross <= 5000)
                return 0.05;
            return 0.15;
        }

        public void DisplayPayout()
        {
            double gross = CalculateGrossPayout();
            double rate = CalculateTDS(gross);
            double net = gross - (gross * rate);

            Console.WriteLine($"Gross: {gross:F2} | TDS Applied: {rate * 100}% | Net Payout: {net:F2}");
        }
    }
}

