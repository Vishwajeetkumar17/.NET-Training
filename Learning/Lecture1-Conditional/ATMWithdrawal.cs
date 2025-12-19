using System;

namespace Lecture1
{
    public class ATMWithdrawal
    {
        public static void Withdraw()
        {
            Console.Write("Is the card inserted? (yes/no): ");
            string? cardInserted = Console.ReadLine();

            if (cardInserted?.ToLower() == "yes")
            {
                Console.Write("Enter your PIN: ");
                string? pinInput = Console.ReadLine();
                const string validPin = "1234";

                if (pinInput == validPin)
                {
                    Console.Write("Enter withdrawal amount: ");
                    string? amountInput = Console.ReadLine();

                    if (decimal.TryParse(amountInput, out decimal amount) && amount > 0)
                    {
                        decimal accountBalance = 1000.00m;

                        if (amount <= accountBalance)
                        {
                            accountBalance -= amount;
                            Console.WriteLine($"Withdrawal successful! New balance: {accountBalance:C}");
                        }
                        else
                        {
                            Console.WriteLine("Insufficient balance.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid withdrawal amount.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid PIN.");
                }
            }
            else
            {
                Console.WriteLine("Please insert your card to proceed.");
            }
        }
    }
}