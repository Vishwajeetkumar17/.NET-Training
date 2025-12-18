using System;

namespace MyNamespace
{
    class FeetToCenti
    {
        public static void Convert()
        {
            const double inCm = 30.48;
            Console.Write("Enter the Feet : ");
            string? input = Console.ReadLine();
            if (!double.TryParse(input, out double feet))
            {
                Console.WriteLine("Enter the valid number.");
                return;
            }
            if (feet < 0)
            {
                Console.WriteLine("Enter the feet greater than 0");
                return;
            }

            double cm = feet * inCm;
            Console.WriteLine($"{feet} feet = {cm:F2} cm");
        }
    }
}