namespace FlightFareManagementSystem05
{
    public class Ticket
    {
        public string TicketId { get; set; }
        public string PassengerName { get; set; }
        public int Fare { get; set; }

        public Ticket(string ticketId, string passengerName, int fare)
        {
            if (fare <= 0)
                throw new InvalidFareException("Invalid Fare");

            TicketId = ticketId;
            PassengerName = passengerName;
            Fare = fare;
        }
    }
}
