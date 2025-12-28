using System;
using System.Collections.Generic;

namespace StreamBuzz
{
    /// <summary>
    /// Represents statistical data for a content creator, including the creator's name and weekly like counts.
    /// </summary>
    public class CreatorStats
    {
        public string CreatorName { get; set; }
        public double[] WeeklyLikes { get; set; }
    }

    /// <summary>
    /// Provides methods for registering content creators, displaying top-performing posts, and calculating average
    /// engagement statistics in a console-based application.
    /// </summary>

    public class Program
    {
        public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

        /// <summary>
        /// Registers a new creator by prompting the user for the creator's name and weekly like counts, then adds the
        /// entry to the engagement board.
        /// </summary>
        public void RegisterCreator()
        {
            CreatorStats record = new CreatorStats();

            Console.Write("Enter Creator Name: ");
            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Creator name cannot be empty.");
                return;
            }

            record.CreatorName = name;
            record.WeeklyLikes = new double[4];

            Console.WriteLine("Enter Weekly Likes (Week 1 to 4):");

            for (int i = 0; i < 4; i++)
            {
                string? likesInput = Console.ReadLine();

                if (double.TryParse(likesInput, out double likes) && likes >= 0)
                {
                    record.WeeklyLikes[i] = likes;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a non-negative number.");
                    i--;
                }
            }

            EngagementBoard.Add(record);
            Console.WriteLine("Creator registered successfully.\n");
        }

        /// <summary>
        /// Prompts the user to enter a like threshold and displays the number of posts per creator that meet or exceed
        /// the specified threshold for the current week.
        /// </summary>
        public void TopPosts()
        {
            Console.Write("Enter like threshold: ");
            string? input = Console.ReadLine();

            if (!double.TryParse(input, out double threshold))
            {
                Console.WriteLine("Invalid threshold value.");
                return;
            }

            if (EngagementBoard.Count == 0)
            {
                Console.WriteLine("No engagement data available.");
                return;
            }

            Dictionary<string, int> topPosts = new Dictionary<string, int>();

            foreach (var creator in EngagementBoard)
            {
                int count = 0;
                foreach (var likes in creator.WeeklyLikes)
                {
                    if (likes >= threshold)
                        count++;
                }

                if (count > 0)
                    topPosts[creator.CreatorName] = count;
            }

            if (topPosts.Count == 0)
            {
                Console.WriteLine("No top-performing posts this week.");
                return;
            }

            foreach (var entry in topPosts)
            {
                Console.WriteLine($"{entry.Key} - {entry.Value}");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Calculates the average number of likes per week across all creators in the engagement board.
        /// </summary>
        /// <returns>The average number of likes per week as a double. Returns 0 if there are no creators or no weekly likes
        /// recorded.</returns>
        public double CalculateAverageLikes()
        {
            if (EngagementBoard.Count == 0)
                return 0;

            double totalLikes = 0;
            int count = 0;

            foreach (var creator in EngagementBoard)
            {
                foreach (var likes in creator.WeeklyLikes)
                {
                    totalLikes += likes;
                    count++;
                }
            }

            return count == 0 ? 0 : totalLikes / count;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            bool exit = true;

            while (exit)
            {
                Console.WriteLine("1. Register Creator");
                Console.WriteLine("2. Show Top Posts");
                Console.WriteLine("3. Calculate Average Likes");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string? input = Console.ReadLine();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Please enter a valid number.\n");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        program.RegisterCreator();
                        break;

                    case 2:
                        program.TopPosts();
                        break;

                    case 3:
                        double avgLikes = program.CalculateAverageLikes();
                        Console.WriteLine($"Average Likes: {avgLikes}\n");
                        break;

                    case 4:
                        exit = false;
                        Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.\n");
                        break;
                }
            }
        }
    }
}
