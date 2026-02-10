using System;
using System.Collections.Generic;
using System.Linq;

namespace FindLongestWord
{
    public class Program
    {
        public static void WordFreq(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
            {
                Console.WriteLine("Enter a valid input.");
                return;
            }

            string cleaned = new string(
                sentence.ToLower().Where(c => !char.IsPunctuation(c)).ToArray()
            );
            string[] words = cleaned.Split(" ");
            Dictionary<string, int> freq = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (!freq.ContainsKey(word))
                {
                    freq[word] = 0;
                }
                freq[word]++;
            }
            foreach (var item in freq)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter a Sentence : ");
            string sentence = Console.ReadLine();
            WordFreq(sentence);
        }
    }
}
