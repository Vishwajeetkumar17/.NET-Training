namespace MovieTheaterBookingSystem
{
    public class MovieScreening
    {
        public string MovieTitle { get; set; }
        public DateTime ShowTime { get; set; }
        public string ScreenNumber { get; set; }
        public int TotalSeats { get; set; }
        public int BookedSeats { get; set; }
        public double TicketPrice { get; set; }
    }
    public class TheaterManager
    {
        private readonly Dictionary<int, List<MovieScreening>> AllMovies = new Dictionary<int, List<MovieScreening>>();
        List<MovieScreening> MovieList = new List<MovieScreening>();
        public void AddScreening(string title, DateTime time, string screen, int seats, double price)
        {
            int key = AllMovies.Count + 1;

            MovieScreening movieScreening = new MovieScreening()
            {
                MovieTitle = title,
                ShowTime = time,
                ScreenNumber = screen,
                TotalSeats = seats,
                BookedSeats = 0,
                TicketPrice = price
            };
            MovieList.Add(movieScreening);
            AllMovies.Add(key, new List<MovieScreening> { movieScreening });
        }
        public bool BookTickets(string movieTitle, DateTime showTime, int tickets)
        {
            foreach (var movieScreening in AllMovies.Values)
            {
                foreach (var movie in movieScreening)
                {
                    if (movie.MovieTitle == movieTitle && movie.ShowTime == showTime && movie.TotalSeats >= movie.BookedSeats + tickets)
                    {
                        movie.BookedSeats += tickets;
                        return true;
                    }
                }
            }
            return false;
        }
        public Dictionary<string, List<MovieScreening>> GroupScreeningsByMovie()
        {
            Dictionary<string, List<MovieScreening>> groupScreening = new Dictionary<string, List<MovieScreening>>();
            foreach (var movieScreening in AllMovies.Values)
            {
                foreach (var movie in movieScreening)
                {
                    if (!groupScreening.ContainsKey(movie.MovieTitle))
                    {
                        groupScreening[movie.MovieTitle] = new List<MovieScreening>();
                    }
                    groupScreening[movie.MovieTitle].Add(movie);
                }
            }
            return groupScreening;
        }
        public double CalculateTotalRevenue()
        {
            double totalRevenue = 0;
            foreach (var movies in MovieList)
            {
                totalRevenue += movies.BookedSeats * movies.TicketPrice;
            }
            return totalRevenue;
        }
        public List<MovieScreening> GetAvailableScreenings(int minSeats)
        {
            List<MovieScreening> availableScreening = new List<MovieScreening>();
            foreach (var movie in MovieList)
            {
                int remaining = movie.TotalSeats - movie.BookedSeats;
                if (remaining > minSeats)
                {
                    availableScreening.Add(movie);
                }
            }
            return availableScreening;
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            TheaterManager manager = new TheaterManager();

            while (true)
            {
                Console.WriteLine("1. Add Screening");
                Console.WriteLine("2. Book Tickets");
                Console.WriteLine("3. Group Screenings by Movie");
                Console.WriteLine("4. Show Total Revenue");
                Console.WriteLine("5. Show Available Screenings");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Write("Enter Movie Title: ");
                    string title = Console.ReadLine();

                    Console.Write("Enter Show Time (yyyy-MM-dd HH:mm): ");
                    DateTime time = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter Screen Number: ");
                    string screen = Console.ReadLine();

                    Console.Write("Enter Total Seats: ");
                    int seats = int.Parse(Console.ReadLine());

                    Console.Write("Enter Ticket Price: ");
                    double price = double.Parse(Console.ReadLine());

                    manager.AddScreening(title, time, screen, seats, price);
                    Console.WriteLine("Screening added.\n");
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Movie Title: ");
                    string title = Console.ReadLine();

                    Console.Write("Enter Show Time (yyyy-MM-dd HH:mm): ");
                    DateTime time = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter Number of Tickets: ");
                    int tickets = int.Parse(Console.ReadLine());

                    bool success = manager.BookTickets(title, time, tickets);
                    Console.WriteLine(success ? "Tickets booked.\n" : "Booking failed.\n");
                }
                else if (choice == 3)
                {
                    var grouped = manager.GroupScreeningsByMovie();

                    foreach (var item in grouped)
                    {
                        Console.WriteLine($"Movie: {item.Key}");
                        foreach (var m in item.Value)
                        {
                            Console.WriteLine(
                                $"Time: {m.ShowTime}, Screen: {m.ScreenNumber}, Seats Left: {m.TotalSeats - m.BookedSeats}"
                            );
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 4)
                {
                    Console.WriteLine(
                        $"Total Revenue: {manager.CalculateTotalRevenue()}\n"
                    );
                }
                else if (choice == 5)
                {
                    Console.Write("Enter minimum available seats: ");
                    int minSeats = int.Parse(Console.ReadLine());

                    var available = manager.GetAvailableScreenings(minSeats);

                    if (available.Count == 0)
                    {
                        Console.WriteLine("No screenings available with the given seat requirement.\n");
                    }
                    else
                    {
                        Console.WriteLine("Available Screenings:");
                        foreach (var m in available)
                        {
                            Console.WriteLine(
                                $"{m.MovieTitle} | {m.ShowTime} | Seats Left: {m.TotalSeats - m.BookedSeats}"
                            );
                        }
                        Console.WriteLine();
                    }
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
