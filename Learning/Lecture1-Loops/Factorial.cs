using System;

namespace Lecture12
{
    // Summary: Computes the factorial of a non-negative integer iteratively
    // using BigInteger to handle large results safely.
    public class Factorial
    {
        public static void CalculateFactorial()
        {
            Console.Write("Enter an integer to calculate its factorial: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int number) && number >= 0)
            {
                try
                {
                    System.Numerics.BigInteger factorial = 1;

                    for (int i = 2; i <= number; i++)
                    {
                        factorial *= i;
                    }

                    Console.WriteLine($"Factorial of {number} is: {factorial}");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The factorial is too large to compute.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid non-negative integer.");
            }
        }
    }
}