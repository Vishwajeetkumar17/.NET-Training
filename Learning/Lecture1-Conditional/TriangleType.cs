using System;

namespace Lecture1
{
    public class TriangleType
    {
        public static void CheckTriangleType()
        {
            Console.Write("Enter length of side A: ");
            string? inputA = Console.ReadLine();
            Console.Write("Enter length of side B: ");
            string? inputB = Console.ReadLine();
            Console.Write("Enter length of side C: ");
            string? inputC = Console.ReadLine();

            if (double.TryParse(inputA, out double sideA) &&
                double.TryParse(inputB, out double sideB) &&
                double.TryParse(inputC, out double sideC))
            {
                if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                {
                    Console.WriteLine("Side lengths must be positive numbers.");
                    return;
                }

                if (sideA == sideB && sideB == sideC)
                {
                    Console.WriteLine("The triangle is Equilateral.");
                }
                else if (sideA == sideB || sideB == sideC || sideA == sideC)
                {
                    Console.WriteLine("The triangle is Isosceles.");
                }
                else
                {
                    Console.WriteLine("The triangle is Scalene.");
                }
            }
            else
            {
                Console.WriteLine("Please enter valid numeric values for the sides.");
            }
        }
    }
}