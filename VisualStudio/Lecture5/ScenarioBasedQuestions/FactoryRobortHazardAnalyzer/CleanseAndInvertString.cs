using ScenarioBasedProblem;

namespace ScenarioBasedProblem
{
    public class CleanseAndInvertString
    {
        public string CleanseAndInvert(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 6)
            {
                return string.Empty;
            }

            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                if (!char.IsLetter(ch))
                {
                    return string.Empty;
                }
            }

            input = input.ToLower();
            string filtered = "";

            for (int i = 0; i < input.Length; i++)
            {
                int ascii = (int)input[i];
                if (ascii % 2 != 0)
                {
                    filtered += input[i];
                }
            }

            char[] arr = filtered.ToCharArray();
            Array.Reverse(arr);
            string reversed = new string(arr);

            string result = "";
            for (int i = 0; i < reversed.Length; i++)
            {
                if (i % 2 == 0)
                {
                    result += char.ToUpper(reversed[i]);
                }
                else
                {
                    result += reversed[i];
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the word");
            string input = Console.ReadLine();

            CleanseAndInvertString cais = new CleanseAndInvertString();
            string output = cais.CleanseAndInvert(input);

            if (string.IsNullOrEmpty(output))
            {
                Console.WriteLine("Invalid Input");
            }
            else
            {
                Console.WriteLine($"The generated key is - {output}");
            }
        }
    }
}