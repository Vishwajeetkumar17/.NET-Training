// Summary: Displays a loop-driven console menu to run selected exercises
// such as Armstrong check, Pascal's Triangle, Palindrome, and more.
using System;

namespace Lecture12
{
    // Summary: Displays a simple menu loop to invoke different tasks like
    // Armstrong check, Pascal's Triangle, Palindrome, and other demos.
    public class MenuSystem
    {
        public static void ShowMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Check Armstrong Number");
                Console.WriteLine("2. Print Pascal's Triangle");
                Console.WriteLine("3. Check Palindrome");
                Console.WriteLine("4. Print Numbers Not Multiple of Three");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string? input = Console.ReadLine();
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        ArmstrongNumber.CheckArmstrong();
                        break;
                    case 2:
                        PascalsTriangle.PrintTriangle();
                        break;
                    case 3:
                        Palindrome.CheckPalindrome();
                        break;
                    case 4:
                        NotMultipleOfThree.PrintNumbers();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the menu.");
                        break;
                    default:
                        Console.WriteLine("Please select a valid option (1-5).");
                        break;
                }

                Console.WriteLine();

            } while (choice != 5);
        }
    }
}