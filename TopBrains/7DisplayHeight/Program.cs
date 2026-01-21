namespace _7DisplayHeight
{
    public class Program
    {
        public static string Category(int height)
        {
            if (height > 0 && height < 150) return "Short";
            else if (height >= 150 && height < 180) return "Average";
            else if (height >= 180) return "Tall";
            else return "Invalid";
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if(int.TryParse(input, out int height))
            {
                Console.WriteLine(Category(height));
            }
        }
    }
}
