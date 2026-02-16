namespace FlightFareManagementSystem05
{
    public class TicketUtility
    {
        private SortedDictionary<int, List<Ticket>> tickets = new SortedDictionary<int, List<Ticket>>();

        public void AddTicket(Ticket ticket)
        {
            foreach (var list in tickets.Values)
            {
                foreach (var t in list)
                {
                    if (t.TicketId.Equals(ticket.TicketId))
                        throw new DuplicateTicketException("Duplicate Ticket");
                }
            }

            if (!tickets.ContainsKey(ticket.Fare))
                tickets[ticket.Fare] = new List<Ticket>();

            tickets[ticket.Fare].Add(ticket);
        }

        public void DisplayTickets()
        {
            foreach (var entry in tickets)
            {
                foreach (var t in entry.Value)
                {
                    Console.WriteLine($"Details: {t.TicketId} {t.PassengerName} {t.Fare}");
                }
            }
        }

        public void UpdateFare(string ticketId, int newFare)
        {
            if (newFare <= 0)
                throw new InvalidFareException("Invalid Fare");

            foreach (var entry in tickets)
            {
                foreach (var t in entry.Value)
                {
                    if (t.TicketId.Equals(ticketId))
                    {
                        entry.Value.Remove(t);

                        t.Fare = newFare;

                        if (!tickets.ContainsKey(newFare))
                            tickets[newFare] = new List<Ticket>();

                        tickets[newFare].Add(t);
                        return;
                    }
                }
            }

            throw new TicketNotFoundException("Ticket Not Found");
        }
    }
}
