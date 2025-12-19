using System;

namespace Lecture1
{
    internal class QuadraticFinder
    {
        public static void FindQuadrant()
        {
            Console.WriteLine("Enter X coordinate:");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Y coordinate:");
            int y = Convert.ToInt32(Console.ReadLine());

            if (x > 0 && y > 0)
            {
                Console.WriteLine("The point lies in the First Quadrant.");
            }
            else if (x < 0 && y > 0)
            {
                Console.WriteLine("The point lies in the Second Quadrant.");
            }
            else if (x < 0 && y < 0)
            {
                Console.WriteLine("The point lies in the Third Quadrant.");
            }
            else if (x > 0 && y < 0)
            {
                Console.WriteLine("The point lies in the Fourth Quadrant.");
            }
            else if (x == 0 && y != 0)
            {
                Console.WriteLine("The point lies on the Y-axis.");
            }
            else if (y == 0 && x != 0)
            {
                Console.WriteLine("The point lies on the X-axis.");
            }
            else
            {
                Console.WriteLine("The point is at the Origin.");
            }
        }
    }
}