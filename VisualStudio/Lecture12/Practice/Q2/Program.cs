using System;

namespace Q2
{
    /// <summary>
    /// Demonstrates method overloading by adding integers
    /// and double values using the same method name.
    /// </summary>
    public class Source
    {
        #region Overloaded Methods

        // Adds three integer values
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        // Adds three double values
        public double Add(double a, double b, double c)
        {
            return a + b + c;
        }

        #endregion

        #region Application Entry Point

        // Entry point of the application
        static void Main(string[] args)
        {
            Source s = new Source();
            Console.WriteLine(s.Add(1, 2, 3));
            Console.WriteLine(s.Add(1.5, 2.5, 3.5));
        }

        #endregion
    }
}
