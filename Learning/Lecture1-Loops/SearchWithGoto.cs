using System;

namespace Lecture12
{
    // Summary: Searches for a target value in a 5x5 matrix using nested loops
    // and a 'goto' label for early exit when found.
    public class SearchWithGoto
    {
        public static void SearchInMatrix()
        {
            int[,] matrix = new int[5, 5]
            {
                { 1, 2, 3, 4, 5 },
                { 6, 7, 8, 9, 10 },
                { 11, 12, 13, 14, 15 },
                { 16, 17, 18, 19, 20 },
                { 21, 22, 23, 24, 25 }
            };

            Console.Write("Enter a number to search for (1-25): ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int target) && target >= 1 && target <= 25)
            {
                bool found = false;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == target)
                        {
                            found = true;
                            goto Found;
                        }
                    }
                }

            Found:
                if (found)
                {
                    Console.WriteLine($"Number {target} found in the matrix.");
                }
                else
                {
                    Console.WriteLine($"Number {target} not found in the matrix.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid integer between 1 and 25.");
            }
        }
    }
}