using System.Net.Mail;
using System.Text;

namespace EmailCleaner
{
    public class Program
    {
        public static void EmailClean(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Please enter a valid input.");
                return;
            }

            string cleaned = new string(
                email.Where(c => !char.IsWhiteSpace(c)).ToArray()
            ).ToLower();

            try
            {
                var addr = new MailAddress(cleaned);
                if (addr.Address != cleaned)
                    throw new FormatException();
            }
            catch
            {
                Console.WriteLine("Invalid email format.");
                return;
            }
            if (cleaned.EndsWith("@gmail.com"))
            {
                cleaned = cleaned.Replace("@gmail.com", "@company.com");
            }
            Console.WriteLine(cleaned);
        }
        static void Main(string[] args)
        {
            Console.Write("Enter a Email ID : ");
            string input = Console.ReadLine();

            EmailClean(input);
        }
    }
}
