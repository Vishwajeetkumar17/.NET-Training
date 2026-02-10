using System.Text;

namespace PasswordMasking
{
    public class Program
    {
        public static void MaskedPassword(string password)
        {
            int length = password.Length;
            if(length < 3)
            {
                Console.WriteLine("Length should be greater than or equal to 3.");
                return;
            }
            StringBuilder MaskdP = new StringBuilder();
            MaskdP.Append(password[0]);
            for(int i = 1; i < length - 1; i++)
            {
                MaskdP.Append('*');
            }
            MaskdP.Append(password[length - 1]);
            Console.WriteLine("Masked Password : " + MaskdP.ToString());
        }
        static void Main(string[] args)
        {
            Console.Write("Enter a Password: ");
            string input = Console.ReadLine();
            MaskedPassword(input);
        }
    }
}
