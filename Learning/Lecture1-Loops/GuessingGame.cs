using System;

namespace Lecture12
{
    public class GuessingGame
    {
        public static void PlayGame()
        {
            Random random = new Random();
            int secretNumber = random.Next(1, 101);
            int userGuess = 0;

            Console.WriteLine("Enter a number between 1 and 100. Can you guess it?");

            do
            {
                Console.Write("Enter your guess: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out userGuess))
                {
                    if (userGuess < secretNumber)
                    {
                        Console.WriteLine("Too low! Try again.");
                    }
                    else if (userGuess > secretNumber)
                    {
                        Console.WriteLine("Too high! Try again.");
                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You've guessed the correct number!");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer.");
                }

            } while (userGuess != secretNumber);
        }
    }
}