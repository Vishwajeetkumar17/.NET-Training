namespace AssignmentAbs
{

    /// <summary>
    /// Represents a monetary payment transaction. Provides a base class for implementing specific payment types and
    /// operations.
    /// </summary>
    /// <remarks>The Payment class encapsulates the common functionality for payment processing, such as
    /// storing the payment amount and generating a receipt. Derived classes should implement the Pay method to define
    /// the specific payment behavior. This class is intended to be inherited and is not intended to be instantiated
    /// directly.</remarks>
    public abstract class Payment
    {
        public double Amount { get; }
        protected Payment(double amount)
        {
            Amount = amount;
        }
        public double PrintReceipt()
        {
            return Amount;
        }
        public abstract void Pay();
    }

    /// <summary>
    /// Represents a payment made using the Unified Payments Interface (UPI) system.
    /// </summary>
    /// <remarks>Use this class to process payments via UPI by specifying a valid UPI ID. Inherits common
    /// payment functionality from the Payment base class.</remarks>
    public class UpiPayment : Payment
    {
        public string UpiId { get; }
        public UpiPayment(double amount, string upiId) : base(amount)
        {
            UpiId = upiId;
        }
        public override void Pay()
        {
            Console.WriteLine($"Paid {Amount} via UPI {UpiId}");
        }
    }

    /// <summary>
    /// Provides the entry point for the application.
    /// </summary>
    /// <remarks>This class contains the Main method, which initializes and processes a payment using the UPI
    /// payment system. The application demonstrates how to create a payment, execute it, and print a receipt to the
    /// console.</remarks>

    public class Program
    {
        static void Main()
        {
            Payment upiPayment = new UpiPayment(1500, "ittechgenie@upi");
            upiPayment.Pay();
            Console.WriteLine("Receipt Amount: " + upiPayment.PrintReceipt());
        }
    }

}
