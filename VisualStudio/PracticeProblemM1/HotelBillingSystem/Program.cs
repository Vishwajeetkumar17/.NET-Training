namespace HotelBillingSystem
{
    public interface IRoom
    {
        public double calculateTotalBill(int nightsStayed, int joinigYear);
        public int calculateMembershipYears(int joiningYears);
    }

    public class HotelRoom : IRoom
    {
        public string roomType { get; set; }
        public double ratePerNight { get; set; }
        public string guestName { get; set; }

        public HotelRoom(string roomType, string guestName, double ratePerNight)
        {
            this.roomType = roomType;
            this.ratePerNight = ratePerNight;
            this.guestName = guestName;
        }

        public double calculateTotalBill(int nightsStayed, int joiningYear)
        {
            double totalBill = nightsStayed * ratePerNight;
            int totalYear = calculateMembershipYears(joiningYear);
            if(totalYear > 3)
            {
                totalBill *= 0.9;
            }
            return totalBill;
        }

        public int calculateMembershipYears(int joiningYears)
        {
            int currentYear = 2025;
            return currentYear - joiningYears;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nEnter Deluxe Room Details:");
            Console.Write("Guest Name: ");
            string? deluxeGuest = Console.ReadLine();
            Console.Write("Rate per Night: ");
            double deluxeRate = double.Parse(Console.ReadLine());
            Console.Write("Nights Stayed: ");
            int deluxeNights = int.Parse(Console.ReadLine());
            Console.Write("Joining Year: ");
            int deluxeJoinYear = int.Parse(Console.ReadLine());

            HotelRoom deluxeRoom = new("Deluxe Room", deluxeGuest, deluxeRate);

            int deluxeMembership = deluxeRoom.calculateMembershipYears(deluxeJoinYear);
            double deluxeBill = deluxeRoom.calculateTotalBill(deluxeNights, deluxeJoinYear);

            Console.WriteLine("\nEnter Suite Room Details:");
            Console.Write("Guest Name: ");
            string? suiteGuest = Console.ReadLine();
            Console.Write("Rate per Night: ");
            double suiteRate = double.Parse(Console.ReadLine());
            Console.Write("Nights Stayed: ");
            int suiteNights = int.Parse(Console.ReadLine());
            Console.Write("Joining Year: ");
            int suiteJoinYear = int.Parse(Console.ReadLine());

            HotelRoom suiteRoom = new("Suite Room", suiteGuest, suiteRate);

            int suiteMembership = suiteRoom.calculateMembershipYears(suiteJoinYear);
            double suiteBill = suiteRoom.calculateTotalBill(suiteNights, suiteJoinYear);

            Console.WriteLine("\nRoom Summary:");
            Console.WriteLine($"Deluxe Room: {deluxeGuest}, {deluxeRate:F1} per night, Membership: {deluxeMembership} years");
            Console.WriteLine($"Suite Room: {suiteGuest}, {suiteRate:F1} per night, Membership: {suiteMembership} years");

            Console.WriteLine("\nTotal Bill:");
            Console.WriteLine($"For {deluxeGuest} (Deluxe): {Math.Floor(deluxeBill):F1}");
            Console.WriteLine($"For {suiteGuest} (Suite): {suiteBill:F1}");
        }
    }
}
