// GCD and LCM: Find the Greatest Common Divisor and Least Common Multiple of two numbers.

using System;

namespace Lecture12
{
    public class GCDAndLCM
    {
        public static void Calculate()
        {
            Console.Write("Enter first number: ");
            string? input1 = Console.ReadLine();
            Console.Write("Enter second number: ");
            string? input2 = Console.ReadLine();

            if (int.TryParse(input1, out int num1) && int.TryParse(input2, out int num2))
            {
                int a = num1;
                int b = num2;

                while (b != 0)
                {
                    int temp = b;
                    b = a % b;
                    a = temp;
                }
                int gcd = a;

                int lcm = (num1 * num2) / gcd;

                Console.WriteLine($"GCD of {num1} and {num2} is: {gcd}");
                Console.WriteLine($"LCM of {num1} and {num2} is: {lcm}");
            }
            else
            {
                Console.WriteLine("Please enter valid integers.");
            }
        }
    }
}