using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    public class GenericsProject<T>
    {
        public void Add(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine(d1 + d2);
        }
        public void Subtract(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine(d1 - d2);
        }
        public void Multiply(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine(d1 * d2);
        }
        public void Divide(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine(d1 / d2);
        }

    }
        public class Program
    {
        public static void Main()
        {
            GenericsProject<int> gp = new GenericsProject<int>();
            gp.Add(10, 20);
            gp.Subtract(20, 10);
            gp.Multiply(10, 20);
            gp.Divide(20, 10);
            GenericsProject<double> gpDouble = new GenericsProject<double>();
            gpDouble.Add(10.5, 20.5);
            gpDouble.Subtract(20.5, 10.5);
            gpDouble.Multiply(10.5, 20.5);
            gpDouble.Divide(20.5, 10.5);

        }
    }
}
