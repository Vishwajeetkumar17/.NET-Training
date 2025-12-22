using System;

namespace Lecture12
{
    // Summary: Checks if a number is an Armstrong number by summing each digit
    // raised to the power of the number of digits and comparing to the original.
    public class ArmstrongNumber
    {
        public static void CheckArmstrong()
        {
            Console.Write("Enter a number: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                int originalNumber = number;
                int sum = 0;
                int digits = number.ToString().Length;

                while (number > 0)
                {
                    int digit = number % 10;
                    sum += (int)Math.Pow(digit, digits);
                    number /= 10;
                }

                if (sum == originalNumber)
                {
                    Console.WriteLine($"{originalNumber} is an Armstrong number.");
                }
                else
                {
                    Console.WriteLine($"{originalNumber} is not an Armstrong number.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid integer.");
            }
        }
    }
}