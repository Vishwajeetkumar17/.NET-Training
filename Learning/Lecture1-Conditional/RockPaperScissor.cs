using System;

namespace Lecture1
{
    // Summary: Implements a two-player Rock–Paper–Scissors game using
    // conditional logic to determine the winner or a tie.
    public class RockPaperScissor
    {
        public static void PlayGame()
        {
            Console.Write("Player 1, enter your choice (rock/paper/scissors): ");
            string? player1Choice = Console.ReadLine()?.ToLower();

            Console.Write("Player 2, enter your choice (rock/paper/scissors): ");
            string? player2Choice = Console.ReadLine()?.ToLower();

            if (player1Choice == player2Choice)
            {
                Console.WriteLine("It's a tie!");
            }
            else if (player1Choice == "rock")
            {
                if (player2Choice == "scissors")
                {
                    Console.WriteLine("Player 1 wins! Rock crushes Scissors.");
                }
                else if (player2Choice == "paper")
                {
                    Console.WriteLine("Player 2 wins! Paper covers Rock.");
                }
                else
                {
                    Console.WriteLine("Invalid choice by Player 2.");
                }
            }
            else if (player1Choice == "paper")
            {
                if (player2Choice == "rock")
                {
                    Console.WriteLine("Player 1 wins! Paper covers Rock.");
                }
                else if (player2Choice == "scissors")
                {
                    Console.WriteLine("Player 2 wins! Scissors cut Paper.");
                }
                else
                {
                    Console.WriteLine("Invalid choice by Player 2.");
                }
            }
            else if (player1Choice == "scissors")
            {
                if (player2Choice == "paper")
                {
                    Console.WriteLine("Player 1 wins! Scissors cut Paper.");
                }
                else if (player2Choice == "rock")
                {
                    Console.WriteLine("Player 2 wins! Rock crushes Scissors.");
                }
                else
                {
                    Console.WriteLine("Invalid choice by Player 2.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice by Player 1.");
            }
        }
    }
}