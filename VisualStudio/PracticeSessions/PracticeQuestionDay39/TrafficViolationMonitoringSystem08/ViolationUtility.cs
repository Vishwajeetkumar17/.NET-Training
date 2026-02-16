namespace TrafficViolationMonitoringSystem08
{
    public class ViolationUtility
    {
        private SortedDictionary<int, List<Violation>> violations = new SortedDictionary<int, List<Violation>>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        public void AddViolation(Violation violation)
        {
            foreach (var list in violations.Values)
            {
                foreach (var v in list)
                {
                    if (v.VehicleNumber.Equals(violation.VehicleNumber))
                        throw new DuplicateViolationException("Duplicate Violation");
                }
            }

            if (!violations.ContainsKey(violation.FineAmount))
                violations[violation.FineAmount] = new List<Violation>();

            violations[violation.FineAmount].Add(violation);
        }

        public void DisplayViolations()
        {
            foreach (var entry in violations)
            {
                foreach (var v in entry.Value)
                {
                    Console.WriteLine($"Details: {v.VehicleNumber} {v.OwnerName} {v.FineAmount}");
                }
            }
        }

        public void PayFine(string vehicleNumber, int amount)
        {
            if (amount <= 0)
                throw new InvalidFineAmountException("Invalid Fine Amount");

            foreach (var entry in violations)
            {
                foreach (var v in entry.Value)
                {
                    if (v.VehicleNumber.Equals(vehicleNumber))
                    {
                        entry.Value.Remove(v);

                        int newFine = v.FineAmount - amount;
                        if (newFine < 0)
                            throw new InvalidFineAmountException("Invalid Fine Amount");

                        v.FineAmount = newFine;

                        if (!violations.ContainsKey(newFine))
                            violations[newFine] = new List<Violation>();

                        violations[newFine].Add(v);
                        return;
                    }
                }
            }

            throw new DuplicateViolationException("Violation Not Found");
        }
    }
}
