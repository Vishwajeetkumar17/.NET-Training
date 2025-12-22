using System;

namespace Lecture12
{
    // Summary: Checks if a number is prime using basic optimizations
    // (early exits for small numbers and 6k ± 1 rule up to sqrt(n)).
    public class PrimeNumber
    {
        public static void CheckPrime()
        {
            Console.Write("Enter a number to check if it is prime: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                if (number <= 1)
                {
                    Console.WriteLine($"{number} is not a prime number.");
                    return;
                }

                if (number <= 1)
                {
                    Console.WriteLine($"{number} is not a prime number.");
                    return;
                }

                if (number == 2)
                {
                    Console.WriteLine($"{number} is a prime number.");
                    return;
                }
                if (number % 2 == 0 || number % 3 == 0)
                {
                    Console.WriteLine($"{number} is not a prime number.");
                    return;
                }

                bool isPrime = true;

                for (int i = 5; i <= Math.Sqrt(number); i += 6)
                {
                    if (number % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    Console.WriteLine($"{number} is a prime number.");
                }
                else
                {
                    Console.WriteLine($"{number} is not a prime number.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid integer.");
            }
        }
    }
}