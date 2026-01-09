namespace DeligateCustomer
{
    /// <summary>
    /// Acts as the entry point for executing
    /// delegate-based message printing.
    /// </summary>
    public class Program
    {
        #region Application Entry Point

        // Entry point of the application
        static void Main(string[] args)
        {
            PrintingCompany printingCompany = new PrintingCompany();
            printingCompany.CustomerChoicePrintMessage = new PrintMessage(Method1);
            printingCompany.Print("Vishwajeet");
        }

        #endregion

        #region Delegate Methods

        // Returns a greeting message
        public static string Method1(string message)
        {
            return "Hello " + message;
        }

        // Returns a New Year greeting message
        public static string HappyNewYear(string message)
        {
            return "Happy New Year " + message;
        }

        #endregion
    }
}
