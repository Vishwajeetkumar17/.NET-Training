using System;
using System.Text;

namespace FlipKeyLogicalProblem
{
    public class Program
    {
        public string CleanseAndInvert(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 6)
            {
                return string.Empty;
            }

            foreach (char ch in input)
            {
                if (!char.IsLetter(ch))
                {
                    return string.Empty;
                }
            }

            string lower = input.ToLower();
            StringBuilder filtered = new StringBuilder();

            foreach (char ch in lower)
            {
                if (((int)ch) % 2 != 0)
                {
                    filtered.Append(ch);
                }
            }

            char[] reversed = filtered.ToString().ToCharArray();
            Array.Reverse(reversed);

            for (int i = 0; i < reversed.Length; i++)
            {
                if (i % 2 == 0)
                {
                    reversed[i] = char.ToUpper(reversed[i]);
                }
            }

            return new string(reversed);
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Enter the word");
            string input = Console.ReadLine();

            Program program = new Program();
            string result = program.CleanseAndInvert(input);

            if (string.IsNullOrEmpty(result))
            {
                Console.WriteLine("Invalid Input");
            }
            else
            {
                Console.WriteLine($"The generated key is - {result}");
            }
        }
    }
}
