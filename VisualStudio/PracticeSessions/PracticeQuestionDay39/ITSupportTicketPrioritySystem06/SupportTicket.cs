namespace ITSupportTicketPrioritySystem06
{
    public class SupportTicket
    {
        public string TicketId { get; set; }
        public string IssueDescription { get; set; }
        public int SeverityLevel { get; set; }

        public SupportTicket(string ticketId, string issueDescription, int severityLevel)
        {
            if (severityLevel <= 0)
                throw new InvalidSeverityException("Invalid Severity");

            TicketId = ticketId;
            IssueDescription = issueDescription;
            SeverityLevel = severityLevel;
        }
    }
}
