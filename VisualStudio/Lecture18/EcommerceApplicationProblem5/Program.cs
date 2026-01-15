using System;

namespace EcommerceApplicationProblem5
{
    /// <summary>
    /// Represents an e-commerce shop user
    /// and payment-related details.
    /// </summary>
    public class EcommerceShop
    {
        #region Properties

        // Gets or sets the user name
        public string UserName { get; set; }

        // Gets or sets the wallet balance
        public double WalletBalance { get; set; }

        // Gets or sets the total purchase amount
        public double TotalPurchaseAmount { get; set; }

        #endregion
    }

    /// <summary>
    /// Handles e-commerce payment validation
    /// and transaction processing.
    /// </summary>
    public class Program
    {
        #region Payment Methods

        // Validates wallet balance and processes payment
        public EcommerceShop MakePayment(string name, double balance, double amount)
        {
            if (balance < amount)
            {
                throw new InsufficientWalletBalanceException();
            }

            return new EcommerceShop
            {
                UserName = name,
                WalletBalance = balance,
                TotalPurchaseAmount = amount
            };
        }

        #endregion

        #region Application Entry Point

        // Entry point of the application
        static void Main(string[] args)
        {
            Program program = new Program();

            try
            {
                EcommerceShop shop = program.MakePayment("Emily", 500, 700);
                Console.WriteLine("Payment successful");
            }
            catch (InsufficientWalletBalanceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}
