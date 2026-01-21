using System.Collections.Generic;

namespace _1Programming
{
    public class Program
    {
        public static int Sum(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }

        public static bool IsLucky(int n)
        {
            int square = n * n;
            int sumSquare = Sum(n) * Sum(n);
            if(Sum(square)==sumSquare) return true;
            return false;
            
        }
        public static bool IsPrime(int n)
        {
            if(n <= 1) return false;
            for(int i = 2; i <= Math.Sqrt(n); i++)
            {
                if(n % i == 0)
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            string? input1 = Console.ReadLine();
            string? input2 = Console.ReadLine();

            int total = 0;
            if ((int.TryParse(input1, out int First)) && (int.TryParse(input2, out int Second))){
                for (int i = First; i <= Second; i++)
                {
                    if (IsLucky(i) && !IsPrime(i)) total++;
                }
                Console.WriteLine(total);
            }
            else
            {
                Console.WriteLine("Enter a Valid Input");
            }
        }
    }
}
