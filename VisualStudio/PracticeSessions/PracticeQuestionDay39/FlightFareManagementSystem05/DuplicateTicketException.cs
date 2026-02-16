namespace FlightFareManagementSystem05
{
    public class DuplicateTicketException : Exception
    {
        public DuplicateTicketException(string message) : base(message) { }
    }
}
