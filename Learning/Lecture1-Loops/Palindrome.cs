// Reverse & Palindrome: Reverse an integer and check if it is a palindrome using while.

using System;

namespace Lecture12
{
    public class Palindrome
    {
        public static void CheckPalindrome()
        {
            Console.Write("Enter a number : ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                int originalNumber = number;
                int revNumber = 0;

                while (number > 0)
                {
                    int digit = number % 10;
                    revNumber = (revNumber * 10) + digit;
                    number /= 10;
                }

                Console.WriteLine($"Reversed Number: {revNumber}");

                if (revNumber == originalNumber)
                {
                    Console.WriteLine($"{originalNumber} is a palindrome.");
                }
                else
                {
                    Console.WriteLine($"{originalNumber} is not a palindrome.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid integer.");
            }
        }
    }
}