using System;

namespace Lecture1
{
    // Summary: Counts vowels and consonants in a user-provided string,
    // ignoring non-letter characters.
    public class CountVowelAndConsonant
    {
        public static void CountVowelsAndConsonants()
        {
            Console.Write("Enter a string: ");
            string? input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                int vowelCount = 0;
                int consonantCount = 0;

                foreach (char c in input.ToLower())
                {
                    switch (c)
                    {
                        case 'a':
                        case 'e':
                        case 'i':
                        case 'o':
                        case 'u':
                            vowelCount++;
                            break;
                        default:
                            if (char.IsLetter(c))
                            {
                                consonantCount++;
                            }
                            break;
                    }
                }

                Console.WriteLine($"Vowels: {vowelCount}, Consonants: {consonantCount}");
            }
            else
            {
                Console.WriteLine("Please enter a valid string.");
            }
        }
    }
}