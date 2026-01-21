namespace _2MultiplicationTable
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();
            List<int> mult = new List<int>();

            if (int.TryParse(input1, out int n) && int.TryParse(input2, out int upto))
            {
                for (int i = 1; i <= upto; i++)
                {
                    mult.Add(n * i);
                }
            }
            else
            {
                Console.WriteLine("Enter a Valid Input");
            }
            foreach(var i in mult)
            {
                Console.WriteLine(i);
            }
        }
    }
}
