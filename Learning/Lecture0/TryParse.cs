using System;

namespace MyNamespace
{
    class TryParse
    {
        public static void TryParse1()
        {
            Console.WriteLine("Enter Age : ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int age))
            {
                bool isAdult = age >= 18;
                Console.WriteLine("Adult? " + isAdult);
            }
            else
            {
                Console.WriteLine("Invalid age. Please enter a whole number.");
            }
        }
    }
}