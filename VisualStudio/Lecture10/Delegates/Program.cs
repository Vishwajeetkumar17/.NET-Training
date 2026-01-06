namespace Delegates
{
    public delegate int DelegateAddFunctionName(int a, int b);
    public class ExampleOfDelegate
    {
        public int a;
        public int b;

        public static void Main()
        {
            ExampleOfDelegate p = new ExampleOfDelegate();
            DelegateAddFunctionName delegateVarable = new DelegateAddFunctionName(p.AddMethod3);
            Console.WriteLine(delegateVarable(1, 2));
        }

        private int AddMethod3(int a, int b)
        {
            return a + b + 40;
        }


        private int AddMethod2(int a, int b)
        {
            return a + b + 10;
        }
    }
}