using System;
using System.Collections.Generic;

namespace FlightBookingSystem
{
    public class Flight
    {
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public double TicketPrice { get; set; }
    }

    public class Booking
    {
        public string BookingId { get; set; }
        public string FlightNumber { get; set; }
        public string PassengerName { get; set; }
        public int SeatsBooked { get; set; }
        public double TotalFare { get; set; }
        public string SeatClass { get; set; }
    }

    public class AirlineManager
    {
        private readonly List<Flight> flights = new List<Flight>();
        private readonly List<Booking> bookings = new List<Booking>();
        private int bookingCounter = 1;
        public void AddFlight(string number, string origin, string destination,
                              DateTime depart, DateTime arrive, int seats, double price)
        {
            flights.Add(new Flight
            {
                FlightNumber = number,
                Origin = origin,
                Destination = destination,
                DepartureTime = depart,
                ArrivalTime = arrive,
                TotalSeats = seats,
                AvailableSeats = seats,
                TicketPrice = price
            });
        }
        public bool BookFlight(string flightNumber, string passenger,
                               int seats, string seatClass)
        {
            foreach (var f in flights)
            {
                if (f.FlightNumber == flightNumber && f.AvailableSeats >= seats)
                {
                    double multiplier = seatClass == "Business" ? 1.5 : 1.0;
                    double fare = seats * f.TicketPrice * multiplier;

                    bookings.Add(new Booking
                    {
                        BookingId = "B" + bookingCounter++,
                        FlightNumber = flightNumber,
                        PassengerName = passenger,
                        SeatsBooked = seats,
                        TotalFare = fare,
                        SeatClass = seatClass
                    });

                    f.AvailableSeats -= seats;
                    return true;
                }
            }
            return false;
        }

        public Dictionary<string, List<Flight>> GroupFlightsByDestination()
        {
            Dictionary<string, List<Flight>> grouped  = new Dictionary<string, List<Flight>>();

            foreach (var f in flights)
            {
                if (!grouped.ContainsKey(f.Destination))
                    grouped[f.Destination] = new List<Flight>();

                grouped[f.Destination].Add(f);
            }
            return grouped;
        }

        public List<Flight> SearchFlights(string origin, string destination, DateTime date)
        {
            List<Flight> result = new List<Flight>();

            foreach (var f in flights)
            {
                if (f.Origin == origin &&
                    f.Destination == destination &&
                    f.DepartureTime.Date == date.Date)
                {
                    result.Add(f);
                }
            }
            return result;
        }

        public double CalculateTotalRevenue(string flightNumber)
        {
            double total = 0;
            foreach (var b in bookings)
            {
                if (b.FlightNumber == flightNumber)
                    total += b.TotalFare;
            }
            return total;
        }
        public List<Flight> GetAllFlights() => flights;
    }

    public class Program
    {
        static void Main(string[] args)
        {
            AirlineManager manager = new AirlineManager();

            while (true)
            {
                Console.WriteLine("1 Add Flight");
                Console.WriteLine("2 Book Flight");
                Console.WriteLine("3 Group Flights By Destination");
                Console.WriteLine("4 Search Flights");
                Console.WriteLine("5 Calculate Revenue");
                Console.WriteLine("6 Exit");
                Console.Write("Choice: ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Write("Number: ");
                    string n = Console.ReadLine();

                    Console.Write("Origin: ");
                    string o = Console.ReadLine();

                    Console.Write("Destination: ");
                    string d = Console.ReadLine();

                    Console.Write("Departure yyyy-MM-dd HH:mm: ");
                    DateTime dep = DateTime.Parse(Console.ReadLine());

                    Console.Write("Arrival yyyy-MM-dd HH:mm: ");
                    DateTime arr = DateTime.Parse(Console.ReadLine());

                    Console.Write("Seats: ");
                    int s = int.Parse(Console.ReadLine());

                    Console.Write("Price: ");
                    double p = double.Parse(Console.ReadLine());

                    manager.AddFlight(n, o, d, dep, arr, s, p);
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Flights:");
                    foreach (var f in manager.GetAllFlights())
                        Console.WriteLine(f.FlightNumber + " " + f.Origin + "->" + f.Destination + " Seats:" + f.AvailableSeats);

                    Console.Write("Flight Number: ");
                    string fn = Console.ReadLine();

                    Console.Write("Passenger: ");
                    string pn = Console.ReadLine();

                    Console.Write("Seats: ");
                    int s = int.Parse(Console.ReadLine());

                    Console.Write("Class Economy/Business: ");
                    string c = Console.ReadLine();

                    bool ok = manager.BookFlight(fn, pn, s, c);
                    Console.WriteLine(ok ? "Booked\n" : "Failed\n");
                }
                else if (choice == 3)
                {
                    var grouped = manager.GroupFlightsByDestination();

                    foreach (var g in grouped)
                    {
                        Console.WriteLine(g.Key);
                        foreach (var f in g.Value)
                            Console.WriteLine(f.FlightNumber + " " + f.Origin);
                        Console.WriteLine();
                    }
                }
                else if (choice == 4)
                {
                    Console.Write("Origin: ");
                    string o = Console.ReadLine();

                    Console.Write("Destination: ");
                    string d = Console.ReadLine();

                    Console.Write("Date yyyy-MM-dd: ");
                    DateTime dt = DateTime.Parse(Console.ReadLine());

                    var list = manager.SearchFlights(o, d, dt);

                    foreach (var f in list)
                        Console.WriteLine(f.FlightNumber + " " + f.DepartureTime);
                }
                else if (choice == 5)
                {
                    Console.Write("Flight Number: ");
                    string fn = Console.ReadLine();

                    Console.WriteLine(manager.CalculateTotalRevenue(fn));
                }
                else if (choice == 6)
                {
                    break;
                }

                Console.WriteLine();
            }
        }
    }
}
