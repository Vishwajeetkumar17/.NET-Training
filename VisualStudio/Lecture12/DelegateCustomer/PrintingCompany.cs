using System;
using System.Collections.Generic;
using System.Text;

namespace DeligateCustomer
{
    // Delegate to format a message before printing
    public delegate string PrintMessage(string message);

    /// <summary>
    /// Uses a delegate to print messages
    /// based on customer-selected formatting logic.
    /// </summary>
    public class PrintingCompany
    {
        #region Properties

        // Stores the customer-selected print logic
        public PrintMessage CustomerChoicePrintMessage { get; set; }

        #endregion

        #region Public Methods

        // Prints the message using the selected delegate logic
        public void Print(string message)
        {
            string MessageToPrint = CustomerChoicePrintMessage(message);
            Console.WriteLine(MessageToPrint);
        }

        #endregion
    }
}
