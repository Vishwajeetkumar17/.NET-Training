namespace AttributeExample
{
    public class Calculator
    {
        [Obsolete("Use the Add(int, int) method instead")]
        public int OldAdd(int a ,int b)
        {
            return a + b;
        }
        public int Subtract(int a ,int b)
        {
            return a - b; 
        }
        public int Add(int a ,int b)
        {
            return a + b;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Calculator c = new Calculator();
            int oldSum = c.OldAdd(5, 6);
            int subtract = c.Subtract(5, 6);
            int sum = c.Add(5, 6);
            Console.WriteLine($"{oldSum}, {subtract}, {sum}");
        }
    }
}
