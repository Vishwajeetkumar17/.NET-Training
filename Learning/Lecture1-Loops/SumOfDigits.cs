using System;

namespace Lecture12
{
    // Summary: Computes the digital root by repeatedly summing digits
    // until a single-digit result remains.
    public class SumOfDigits
    {
        public static void CalculateDigitalRoot()
        {
            Console.Write("Enter a number: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int number) && number >= 0)
            {
                while (number >= 10)
                {
                    int sum = 0;
                    while (number > 0)
                    {
                        sum += number % 10;
                        number /= 10;
                    }
                    number = sum;
                }

                Console.WriteLine($"The digital root is: {number}");
            }
            else
            {
                Console.WriteLine("Please enter a valid non-negative integer.");
            }
        }
    }
}