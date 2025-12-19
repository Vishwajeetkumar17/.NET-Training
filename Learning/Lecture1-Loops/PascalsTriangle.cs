using System;

namespace Lecture12
{
    public class PascalsTriangle
    {
        public static void PrintTriangle()
        {
            Console.Write("Enter the number of rows for Pascal's Triangle: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int rows) && rows > 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    int number = 1;
                    Console.Write(new string(' ', (rows - i) * 2));

                    for (int j = 0; j <= i; j++)
                    {
                        Console.Write($"{number,4}");
                        number = number * (i - j) / (j + 1);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid positive integer.");
            }
        }
    }
}