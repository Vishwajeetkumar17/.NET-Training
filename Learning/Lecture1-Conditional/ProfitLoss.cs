using System;

namespace Lecture1
{
    public class ProfitLoss
    {
        public static void CalculateProfitOrLoss()
        {
            Console.Write("Enter Cost Price: ");
            string? costPriceInput = Console.ReadLine();
            Console.Write("Enter Selling Price: ");
            string? sellingPriceInput = Console.ReadLine();

            if (decimal.TryParse(costPriceInput, out decimal costPrice) && decimal.TryParse(sellingPriceInput, out decimal sellingPrice))
            {
                if (sellingPrice > costPrice)
                {
                    decimal profit = sellingPrice - costPrice;
                    decimal profitPercentage = (profit / costPrice) * 100;
                    Console.WriteLine($"Profit: {profit:C}, Profit Percentage: {profitPercentage:F2}%");
                }
                else if (costPrice > sellingPrice)
                {
                    decimal loss = costPrice - sellingPrice;
                    decimal lossPercentage = (loss / costPrice) * 100;
                    Console.WriteLine($"Loss: {loss:C}, Loss Percentage: {lossPercentage:F2}%");
                }
                else
                {
                    Console.WriteLine("No profit, no loss.");
                }
            }
            else
            {
                Console.WriteLine("Please enter valid numeric values for Cost Price and Selling Price.");
            }
        }
    }
}