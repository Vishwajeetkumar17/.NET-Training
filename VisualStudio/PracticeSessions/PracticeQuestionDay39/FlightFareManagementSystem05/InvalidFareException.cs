namespace FlightFareManagementSystem05
{
    public class InvalidFareException : Exception
    {
        public InvalidFareException(string message) : base(message) { }
    }
}
