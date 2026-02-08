namespace ConcurrentTicketBooking
{
    public class Seat
    {
        public int SeatNo { get; set; }
        public bool IsBooked { get; set; }
        public string? BookedBy { get; set; }
    }
    public class TicketBookingService
    {
        private readonly List<Seat> _seats;
        private readonly object _lockObj = new object();

        public TicketBookingService(List<Seat> seats)
        {
            _seats = seats;
        }

        public bool BookSeat(int seatNo, string userId)
        {
            lock (_lockObj)
            {
                var seat = _seats.FirstOrDefault(s => s.SeatNo == seatNo);

                if (seat == null)
                    return false;

                if (seat.IsBooked)
                    return false;

                seat.IsBooked = true;
                seat.BookedBy = userId;

                return true;
            }
        }
    }

    internal class Program
    {
        static void Main()
        {
            var seats = new List<Seat>
            {
                new Seat { SeatNo = 1 }
            };

            var service = new TicketBookingService(seats);

            Parallel.Invoke(
                () => TryBook(service, 1, "UserA"),
                () => TryBook(service, 1, "UserB"),
                () => TryBook(service, 1, "UserC")
            );

            Console.WriteLine("\nFinal Seat Status:");
            Console.WriteLine($"Seat 1 Booked: {seats[0].IsBooked}");
            Console.WriteLine($"Booked By: {seats[0].BookedBy}");
        }

        static void TryBook(TicketBookingService service, int seatNo, string user)
        {
            bool result = service.BookSeat(seatNo, user);
            Console.WriteLine($"{user} booking result: {result}");
        }
    }
}
