namespace _13GCD
{
    public class Program
    {
        public static int Gcd(int a, int b)
        {
            if (b == 0)
                return a;
            return Gcd(b, a % b);
        }
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine(Gcd(a, b));
        }
    }
}
