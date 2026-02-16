namespace TrafficViolationMonitoringSystem08
{
    public class Violation
    {
        public string VehicleNumber { get; set; }
        public string OwnerName { get; set; }
        public int FineAmount { get; set; }

        public Violation(string vehicleNumber, string ownerName, int fineAmount)
        {
            if (fineAmount <= 0)
                throw new InvalidFineAmountException("Invalid Fine Amount");

            VehicleNumber = vehicleNumber;
            OwnerName = ownerName;
            FineAmount = fineAmount;
        }
    }
}
