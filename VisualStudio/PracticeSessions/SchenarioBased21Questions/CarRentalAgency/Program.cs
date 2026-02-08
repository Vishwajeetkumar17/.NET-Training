namespace CarRentalAgency
{
    public class RentalCar
    {
        public string LicensePlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string CarType { get; set; }
        public bool IsAvailable { get; set; }
        public double DailyRate { get; set; }
    }
    public class Rental
    {
        public int RentalId { get; set; }
        public string LicensePlate { get; set; }
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalCost { get; set; }
    }
    public class RentalManager
    {
        private readonly List<RentalCar> CarRent = new List<RentalCar>();
        private readonly List<Rental> Rent = new List<Rental>();
        private int rentalId = 1;
        public void AddCar(string license, string make, string model, string type, double rate)
        {
            RentalCar rentalCar = new RentalCar()
            {
                LicensePlate = license,
                Make = make,
                Model = model,
                CarType = type,
                IsAvailable = true,
                DailyRate = rate
            };
            CarRent.Add(rentalCar);
        }
        public bool RentCar(string license, string customer, DateTime start, int days)
        {
            foreach (var car in CarRent)
            {
                if (car.LicensePlate == license && car.IsAvailable)
                {
                    Rental rental = new Rental()
                    {
                        RentalId = rentalId++,
                        LicensePlate = license,
                        CustomerName = customer,
                        StartDate = start,
                        EndDate = start.AddDays(days),
                        TotalCost = car.DailyRate * days
                    };
                    car.IsAvailable = false;
                    Rent.Add(rental);
                    return true;
                }
            }
            return false;
        }
        public Dictionary<string, List<RentalCar>> GroupCarsByType()
        {
            Dictionary<string, List<RentalCar>> groupCars = new Dictionary<string, List<RentalCar>>();
            foreach(var car in CarRent)
            {
                if (car.IsAvailable)
                {
                    if (!groupCars.ContainsKey(car.CarType))
                    {
                        groupCars[car.CarType] = new List<RentalCar>();
                    }
                    groupCars[car.CarType].Add(car);
                }
            }
            return groupCars;
        }
        public List<Rental> GetActiveRentals()
        {
            List<Rental> activeRental = new List<Rental>();
            DateTime today = DateTime.Now;

            foreach (var rental in Rent)
            {
                if (today >= rental.StartDate && today <= rental.EndDate)
                {
                    activeRental.Add(rental);
                }
            }
            return activeRental;
        }
        public double CalculateTotalRentalRevenue()
        {
            double totalRevenue = 0;
            foreach (var car in Rent)
            {
                totalRevenue += car.TotalCost;
            }
            return totalRevenue;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            RentalManager manager = new RentalManager();

            while (true)
            {
                Console.WriteLine("1. Add Car");
                Console.WriteLine("2. Rent Car");
                Console.WriteLine("3. Group Available Cars by Type");
                Console.WriteLine("4. View Active Rentals");
                Console.WriteLine("5. Calculate Total Revenue");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Write("License Plate: ");
                    string license = Console.ReadLine();

                    Console.Write("Make: ");
                    string make = Console.ReadLine();

                    Console.Write("Model: ");
                    string model = Console.ReadLine();

                    Console.Write("Car Type (Sedan/SUV/Van): ");
                    string type = Console.ReadLine();

                    Console.Write("Daily Rate: ");
                    double rate = double.Parse(Console.ReadLine());

                    manager.AddCar(license, make, model, type, rate);
                    Console.WriteLine("Car added.\n");
                }
                else if (choice == 2)
                {
                    Console.Write("License Plate: ");
                    string license = Console.ReadLine();

                    Console.Write("Customer Name: ");
                    string customer = Console.ReadLine();

                    Console.Write("Start Date (yyyy-MM-dd): ");
                    DateTime start = DateTime.Parse(Console.ReadLine());

                    Console.Write("Number of Days: ");
                    int days = int.Parse(Console.ReadLine());

                    bool success = manager.RentCar(license, customer, start, days);
                    Console.WriteLine(success ? "Car rented.\n" : "Car not available.\n");
                }
                else if (choice == 3)
                {
                    var grouped = manager.GroupCarsByType();

                    foreach (var group in grouped)
                    {
                        Console.WriteLine($"Type: {group.Key}");
                        foreach (RentalCar car in group.Value)
                        {
                            Console.WriteLine(
                                $"{car.LicensePlate} | {car.Make} {car.Model} | ₹{car.DailyRate}"
                            );
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 4)
                {
                    var active = manager.GetActiveRentals();

                    if (active.Count == 0)
                    {
                        Console.WriteLine("No active rentals.\n");
                    }
                    else
                    {
                        foreach (Rental r in active)
                        {
                            Console.WriteLine(
                                $"RentalID: {r.RentalId}, Car: {r.LicensePlate}, Customer: {r.CustomerName}"
                            );
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 5)
                {
                    Console.WriteLine(
                        $"Total Revenue: ₹{manager.CalculateTotalRentalRevenue()}\n"
                    );
                }
                else if (choice == 6)
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice.\n");
                }
            }   
        }
    }
}
