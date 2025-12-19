// Diamond Pattern: Print a diamond shape using * characters with nested loops.

using System;

namespace Lecture12
{
    public class DiamondPattern
    {
        public static void PrintDiamond()
        {
            Console.Write("Enter the number of rows for the diamond pattern: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int rows) && rows > 0)
            {
                for (int i = 1; i <= rows; i++)
                {
                    Console.Write(new string(' ', rows - i));
                    Console.WriteLine(new string('*', 2 * i - 1));
                }

                for (int i = rows - 1; i >= 1; i--)
                {
                    Console.Write(new string(' ', rows - i));
                    Console.WriteLine(new string('*', 2 * i - 1));
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid positive integer.");
            }
        }
    }
}