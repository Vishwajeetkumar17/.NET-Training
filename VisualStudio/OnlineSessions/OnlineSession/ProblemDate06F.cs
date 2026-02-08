using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSession
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter word1: ");
            string word1 = Console.ReadLine();

            Console.Write("Enter word2: ");
            string word2 = Console.ReadLine();

            int deletions = CountDeletions(word1, word2);
            Console.WriteLine("Output: " + deletions);
        }

        public static int CountDeletions(string word1, string word2)
        {
            Dictionary<char, int> freq1 = new Dictionary<char, int>();
            Dictionary<char, int> freq2 = new Dictionary<char, int>();

            foreach (char ch in word1)
            {
                if (!freq1.ContainsKey(ch))
                {
                    freq1[ch] = 0;
                }
                freq1[ch]++;
            }
            foreach (char ch in word2)
            {
                if (!freq2.ContainsKey(ch))
                {
                    freq2[ch] = 0;
                }
                freq2[ch]++;
            }

            int common = 0;
            foreach (var item in freq1)
            {
                if (freq2.ContainsKey(item.Key))
                {
                    common += Math.Min(item.Value, freq2[item.Key]);
                }
            }
            int deletions = word1.Length + word2.Length - (2 * common);
            return deletions;
        }
    }
}
