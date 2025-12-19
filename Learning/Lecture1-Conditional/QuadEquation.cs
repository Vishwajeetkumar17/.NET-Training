using System;

namespace Lecture1
{
    public class QuadEquation
    {
        public static void Equation()
        {
            Console.WriteLine("Enter values of a, b, c:");
            string? input1 = Console.ReadLine();
            string? input2 = Console.ReadLine();
            string? input3 = Console.ReadLine();
            double d = 0;

            if (double.TryParse(input1, out double a) && double.TryParse(input2, out double b) && double.TryParse(input3, out double c))
            {
                d = b * b - 4 * a * c;

                if (d > 0)
                {
                    double r1 = (-b + Math.Sqrt(d)) / (2 * a);
                    double r2 = (-b - Math.Sqrt(d)) / (2 * a);
                    Console.WriteLine("Roots are real and distinct:");
                    Console.WriteLine($"Root1 = {r1:F2}, Root2 = {r2:F2}");
                }
                else if (d == 0)
                {
                    double r = -b / (2 * a);
                    Console.WriteLine("Roots are real and equal:");
                    Console.WriteLine($"Root = {r:F2}");
                }
                else
                {
                    double real = -b / (2 * a);
                    double imag = Math.Sqrt(-d) / (2 * a);
                    Console.WriteLine("Roots are complex:");
                    Console.WriteLine($"Root1 = {real:F2} + {imag:F2}i");
                    Console.WriteLine($"Root2 = {real:F2} - {imag:F2}i");
                }
            }
            else
            {
                Console.WriteLine("Enter valid numbers for a, b, and c.");
            }
        }
    }
}