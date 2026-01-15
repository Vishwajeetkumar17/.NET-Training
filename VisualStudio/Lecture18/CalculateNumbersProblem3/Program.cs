using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculateNumbersProblem3
{
    /// <summary>
    /// Manages number inputs, calculates GPA,
    /// and determines the corresponding grade.
    /// </summary>
    public class Program
    {
        #region Fields

        // Stores the list of numbers
        public static List<int> NumberList = new List<int>();

        #endregion

        #region Number Management Methods

        // Adds a number to the list
        public void AddNumbers(int Numbers)
        {
            NumberList.Add(Numbers);
        }

        // Takes user input and adds a number to the list
        public void AddNumbers()
        {
            Console.Write("Enter Number: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                AddNumbers(number);
            }
            else
            {
                Console.WriteLine("Invalid Number");
            }
        }

        #endregion

        #region GPA Calculation Methods

        // Calculates and returns the GPA scored
        public double GetGPAScored()
        {
            if (NumberList.Count == 0)
            {
                return -1;
            }

            var SubjectCount = NumberList.Count;
            double GPA = NumberList.Sum(n => n * 3) / (SubjectCount * 3 * 10.0);
            return GPA;
        }

        // Determines and returns grade based on GPA
        public char GetGradeScored(double gpa)
        {
            char grade = ' ';

            if (gpa == 10)
            {
                grade = 'S';
            }
            else if (gpa < 10 && gpa >= 9)
            {
                grade = 'A';
            }
            else if (gpa < 9 && gpa >= 8)
            {
                grade = 'B';
            }
            else if (gpa < 8 && gpa >= 7)
            {
                grade = 'C';
            }
            else if (gpa < 7 && gpa >= 6)
            {
                grade = 'D';
            }
            else if (gpa < 6 && gpa >= 5)
            {
                grade = 'E';
            }
            else
            {
                Console.WriteLine("Invalid GPA");
                return ' ';
            }

            return grade;
        }

        // Calculates GPA and displays grade
        public void CalculateGPAAndGrade()
        {
            double gpa = GetGPAScored();

            if (gpa == -1)
            {
                Console.WriteLine("No Numbers Available");
                return;
            }

            Console.WriteLine($"GPA Scored: {gpa:F2}");

            char grade = GetGradeScored(gpa);
            if (grade != ' ')
            {
                Console.WriteLine("Grade: " + grade);
            }
        }

        #endregion

        #region Application Entry Point

        // Entry point of the application
        static void Main(string[] args)
        {
            Program p = new Program();
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("1. Add Number");
                Console.WriteLine("2. Calculate GPA and Grade");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        p.AddNumbers();
                        break;
                    case 2:
                        p.CalculateGPAAndGrade();
                        break;
                    case 3:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }

        #endregion
    }
}
