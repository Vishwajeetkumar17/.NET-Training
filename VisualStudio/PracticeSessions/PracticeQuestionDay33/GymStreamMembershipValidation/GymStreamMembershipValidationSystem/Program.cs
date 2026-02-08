namespace GymStreamMembershipValidationSystem
{
    public class Membership
    {
        public string Tier { get; set; }
        public int DurationInMonths { get; set; }
        public double BasePricePerMonth { get; set; }

        public bool ValidateEnrollment()
        {
            if (Tier != "Basic" && Tier != "Premium" && Tier != "Elite") {
                throw new InvalidTierException("Tier not recognized. Please choose an available membership plan.");
            }
            if(DurationInMonths <= 0)
            {
                throw new Exception("Duration must be at least one month.");
            }
            return true;
        }
        public double CalculateTotalBill()
        {
            double total = DurationInMonths * BasePricePerMonth;
            if(Tier == "Basic")
            {
                total *= 0.98;
            }
            else if(Tier == "Premium")
            {
                total *= 0.93;
            }
            else if(Tier == "Elite")
            {
                total *= 0.88;
            }
            return total;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Membership member = new Membership();

            try
            {
                Console.WriteLine("--- GymStream Enrollment Portal ---");

                Console.WriteLine("Enter membership tier (Basic/Premium/Elite):");
                member.Tier = Console.ReadLine();

                Console.WriteLine("Enter duration in months:");
                member.DurationInMonths = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter base price per month:");
                member.BasePricePerMonth = Convert.ToDouble(Console.ReadLine());

                // Perform Validation
                if (member.ValidateEnrollment())
                {
                    Console.WriteLine("\nEnrollment Successful!");
                    double finalBill = member.CalculateTotalBill();
                    Console.WriteLine($"Total amount after discount: {finalBill:F2}");
                }
            }
            // Catch Block 1: Custom Exception for Tiers
            catch (InvalidTierException ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            // Catch Block 2: General Exception for Duration or numeric errors
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            Console.WriteLine("\nPress any key to close...");
            Console.ReadKey();
        }

    }
}
