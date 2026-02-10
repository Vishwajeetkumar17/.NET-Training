using System.Reflection;

namespace Reflection
{
    public class Adder
    {
        public void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }
    }
    public class Program
    {
        public static void Main()
        {
            Type t = typeof(Adder);               // 1. Get type
            object obj = Activator.CreateInstance(t); // 2. Create instance

            MethodInfo method = t.GetMethod("Add");   // 3. Get method
            method.Invoke(obj, new object[] { 10, 20 }); // Call method
        }
    }
}
