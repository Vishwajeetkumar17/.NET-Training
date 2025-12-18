using System;

namespace MyNamespace
{
    class IsPrime
    {
        public static void IsPrimeFun()
        {
            Console.Write("Enter a number : ");
            int n = int.Parse(Console.ReadLine());
            bool isPrime = true;
            if (n <= 1)
            {
                Console.WriteLine($"{n} Not a Prime Number");
                return;
            }
            if (n <= 3 || n == 5)
            {
                Console.WriteLine($"{n} a Prime Number");
                return;
            }
            if (n % 2 == 0 || n % 3 == 0 || n % 5 == 0)
            {
                Console.WriteLine($"{n} Not a Prime Number");
                return;
            }

            for (int i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                Console.WriteLine(n + " is prime number");
            }

            else
            {
                Console.WriteLine(n + " is not prime number");
            }
        }
    }
}