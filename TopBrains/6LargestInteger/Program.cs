namespace _6LargestInteger
{
    public class Program
    {
        public static int Largest(int a, int b, int c)
        {
            if(a > b && a > c)
            {
                return a;
            }
            else if(b > a && b > c)
            {
                return b;
            }
            return c;
        }
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();
            string input3 = Console.ReadLine();

            if(int.TryParse(input1, out int a) && int.TryParse(input2, out int b) && int.TryParse(input3, out int c))
            {
                Console.WriteLine(Largest(a, b, c));
            }
            else
            {
                Console.WriteLine("Enter a Valid Input");
            }
        }
    }
}
