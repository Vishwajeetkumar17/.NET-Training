using System.Text;

namespace PasswordGeneration
{
    public class Program
    {
        public static void Generate(string username)
        {
            if(username == null || username.Length < 8)
            {
                Console.WriteLine($"{username} is an invalid username.");
                return;
            }
            if (!validName(username))
            {
                Console.WriteLine($"{username} is an invalid username.");
                return;
            }

            char[] chars = username.ToCharArray();
            StringBuilder sb = new StringBuilder("TECH_");
            int asciiSum = 0;
            for(int i = 0; i < 4; i++)
            {
                asciiSum += (int)(char.ToLower(chars[i]));
            }
            sb.Append(asciiSum);
            sb.Append(chars[6]);
            sb.Append(chars[7]);
            Console.WriteLine(sb.ToString());
        }

        public static bool validName(string username)
        {
            string firstFour = username.Substring(0, 4);
            if (!firstFour.All(char.IsUpper))
                return false;

            if (username[4] != '@')
                return false;

            if (!int.TryParse(username.Substring(5, 3), out int number))
                return false;

            if (number < 101 || number > 115)
                return false;

            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your UserName");
            string input = Console.ReadLine();
            Generate(input);
        }
    }
}
