namespace IPrint
{
    interface IPrint
    {
        void Print();
    }

    public class Test1 : IPrint
    {
        public void Print()
        {
            System.Console.WriteLine("Hello, Test1");
        }
    }
    public class Test2 : IPrint
    {
        public void Print()
        {
            System.Console.WriteLine("Hello, Test2");
        }
    }

    public class Program 
    {
        public static void Main(string[] args)
        {
            Test1 printer1 = new Test1();
            Test2 printer2 = new Test2();
            printer1.Print();
            printer2.Print();
        }
    }



}
