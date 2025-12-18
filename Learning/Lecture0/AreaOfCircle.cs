using System;

namespace MyNamespace
{
    class AreaOfCircle
    {
        public static void Area()
        {
            Console.Write("Enter the Radius : ");
            string? input = Console.ReadLine();

            if (double.TryParse(input, out double radius))
            {
                if (radius < 0)
                {
                    Console.WriteLine("Radius cannot be negative.");
                    return;
                }
                else
                {
                    double area = Math.PI * radius * radius;
                    Console.WriteLine($"Area of Circle is {area:F2}");
                }
            }
            else
            {
                Console.WriteLine("Enter a valid number");
            }
        }
    }
}