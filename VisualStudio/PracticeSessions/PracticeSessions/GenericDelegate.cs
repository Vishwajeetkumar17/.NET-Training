using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeSessions
{
    public class GenericDelegate
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Multiply(int a, int b)
        {
            return a * b; 
        }
        static void Main()
        {
            Func<int, int, int> Calc = Add;
            Console.WriteLine(Calc(2, 3));
            Calc = Multiply;
            Console.WriteLine(Calc(2, 3));

            Action<string> PrintMessage = msg => Console.WriteLine(msg);
            PrintMessage("Hello World");

            Predicate<int> IsEven = num => num % 2 == 0;
            Console.WriteLine(IsEven(3));
        }
    }
}
