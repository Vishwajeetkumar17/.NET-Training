using System;

namespace Lecture12
{
    // Summary: Checks whether a number is a Strong number by summing the
    // factorial of each digit and comparing to the original number.
    public class StrongNumber
    {
        public static void CheckStrongNumber()
        {
            Console.Write("Enter a number: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int number) && number >= 0)
            {
                int originalNumber = number;
                int sum = 0;

                while (number > 0)
                {
                    int digit = number % 10;
                    int factorial = 1;

                    for (int i = 2; i <= digit; i++)
                    {
                        factorial *= i;
                    }

                    sum += factorial;
                    number /= 10;
                }

                if (sum == originalNumber)
                {
                    Console.WriteLine($"{originalNumber} is a Strong number.");
                }
                else
                {
                    Console.WriteLine($"{originalNumber} is not a Strong number.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid non-negative integer.");
            }
        }
    }
}