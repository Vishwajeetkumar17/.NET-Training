namespace ITSupportTicketPrioritySystem06
{
    public class SupportTicketUtility
    {
        private SortedDictionary<int, Queue<SupportTicket>> tickets = new SortedDictionary<int, Queue<SupportTicket>>();

        public void AddTicket(SupportTicket ticket)
        {
            if (!tickets.ContainsKey(ticket.SeverityLevel))
                tickets[ticket.SeverityLevel] = new Queue<SupportTicket>();

            tickets[ticket.SeverityLevel].Enqueue(ticket);
        }

        public void DisplayTickets()
        {
            foreach (var entry in tickets)
            {
                foreach (var t in entry.Value)
                {
                    Console.WriteLine($"Details: {t.TicketId} {t.IssueDescription} {t.SeverityLevel}");
                }
            }
        }

        public void EscalateTicket(string ticketId)
        {
            foreach (var entry in tickets)
            {
                int currentSeverity = entry.Key;
                foreach (var t in entry.Value)
                {
                    if (t.TicketId.Equals(ticketId))
                    {
                        entry.Value.Dequeue();

                        int newSeverity = currentSeverity - 1;
                        if (newSeverity <= 0)
                            throw new InvalidSeverityException("Invalid Severity");

                        t.SeverityLevel = newSeverity;

                        if (!tickets.ContainsKey(newSeverity))
                            tickets[newSeverity] = new Queue<SupportTicket>();

                        tickets[newSeverity].Enqueue(t);
                        return;
                    }
                }
            }

            throw new TicketNotFoundException("Ticket Not Found");
        }
    }
}
