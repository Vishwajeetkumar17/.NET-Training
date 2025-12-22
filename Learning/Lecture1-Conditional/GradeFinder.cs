using System;

namespace Lecture1
{
    // Summary: Reads a single letter grade (E,V,G,A,F) and prints the
    // corresponding description using a switch-case.
    public class GradeFinder
    {
        public static void FindGradeDescription()
        {
            Console.Write("Enter the grade (E, V, G, A, F): ");
            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || input.Length != 1)
            {
                Console.WriteLine("Please enter a valid single character grade.");
                return;
            }

            char grade = char.ToUpper(input[0]);
            string description;

            switch (grade)
            {
                case 'E':
                    description = "Excellent";
                    break;
                case 'V':
                    description = "Very Good";
                    break;
                case 'G':
                    description = "Good";
                    break;
                case 'A':
                    description = "Average";
                    break;
                case 'F':
                    description = "Fail";
                    break;
                default:
                    description = "Invalid grade entered.";
                    break;
            }

            Console.WriteLine($"The grade description is: {description}");
        }
    }
}