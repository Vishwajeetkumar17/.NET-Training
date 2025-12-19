using System;

namespace Lecture12
{
    public class Fibbonacci
    {
        public static void GenerateFibbonacci()
        {
            Console.Write("Enter the number of terms for Fibbonacci series: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int terms) && terms > 0)
            {
                int first = 0, second = 1, next;

                Console.WriteLine("Fibbonacci Series:");
                for (int i = 1; i <= terms; i++)
                {
                    Console.Write(first + " ");
                    next = first + second;
                    first = second;
                    second = next;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid positive integer.");
            }
        }
    }
}