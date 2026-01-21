namespace _3Swap
{
    public class Program
    {
        public static void Swap(ref int n1, ref int n2)
        {
            int temp = n1;
            n1 = n2;
            n2 = temp;
        }
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();

            if(int.TryParse(input1, out int n1) && int.TryParse(input2, out int n2))
            {
                Swap(ref n1, ref n2);
                Console.WriteLine($"{n1} {n2}");
            }
            else
            {
                Console.WriteLine("Enter a Valid Number");
            }
        }
    }
}
