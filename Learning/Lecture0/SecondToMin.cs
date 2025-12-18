using System;

namespace MyNamespace
{
    class SecondToMin
    {
        public static void Minutes()
        {
            Console.Write("Enter seconds: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int seconds))
            {
                Console.WriteLine("Please enter a valid number.");
                return;
            }

            if (seconds < 0)
            {
                Console.WriteLine("Seconds cannot be negative.");
                return;
            }

            int min = seconds / 60;
            int remainingSeconds = seconds % 60;

            Console.WriteLine($"{seconds} seconds = {min} minute(s) and {remainingSeconds} second(s)");
        }
    }
}