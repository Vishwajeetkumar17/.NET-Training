using System.ComponentModel;
using System.Reflection;

namespace ReflectionExample
{
    public class Program
    {
        public class Department
        {
            public int Id { get; set; }
            public string name { get; set; }

            private string location;
        }
        public static void Main()
        {
            Department obj = new Department();

            var props = obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).ToList();

            foreach (var prop in props)
            {
                Console.WriteLine(prop.Name);
            }
        }
    }
}