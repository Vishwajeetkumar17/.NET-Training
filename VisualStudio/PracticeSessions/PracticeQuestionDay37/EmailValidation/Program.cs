namespace EmailValidation
{
    public class Program
    {
        public static bool EmailValidator(string message)
        {
            if(string.IsNullOrEmpty(message))
            {
                return false;
            }
            string lowerCheck = message.ToLower();
            if(message != lowerCheck)
            {
                return false;
            }
            string[] check = message.Split('@');
            if(check.Length != 2)
            {
                return false;
            }
            if (check[1] != "gmail.com")
            {
                return false;
            }
            List<char> invalidChars = new List<char>() { '_', '&', '=', '+', '-', '*', '/', '\'', ',', '<', '>', '!', ' ' };
            foreach (var item in check[0])
            {
                if (invalidChars.Contains(item))
                {
                    return false;
                }
            }
            if (check.Contains(".."))
            {
                return false;
            }
            return true;

        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a Gmail Id: ");
                string input = Console.ReadLine();
                string output = EmailValidator(input) ? "Valid" : "Invalid";
                Console.WriteLine(output);
                Console.WriteLine("Write 'quit' is terminate");
                string exit = Console.ReadLine();
                if (exit == "quit")
                {
                    break;
                }
            }
        }
    }
}
