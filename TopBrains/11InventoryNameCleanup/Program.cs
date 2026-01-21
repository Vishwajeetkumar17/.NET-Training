namespace _11InventoryNameCleanup
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a String: ");
            string input = Console.ReadLine();
            string[] arr = input.Split(" ");
            string result = "";
            foreach(string item in arr)
            {
                for(int i = 0; i < item.Length-1; i++)
                {
                    if((i == 0))
                    {
                        result += Char.ToUpper(item[0]);
                    }
                    if (item[i] == item[i + 1])
                    {
                        result = result.Remove(i + 1, 1);
                        i--;
                    }
                    result += item[i];
                }
                result += " ";
            }
            Console.WriteLine(result);
        }
    }
}
