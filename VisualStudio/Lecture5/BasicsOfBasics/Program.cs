namespace BasicsOfBasics
{
    public class Program
    {
        static void Main(string[] args)
        {
            SomeClass someClass = new SomeClass();
            someClass.SomeMethod(5);

            int a = 10;
            int b = 20;
            int ans = someClass.Add(ref a, ref b);
            Console.WriteLine("Addition: " + ans);
            Console.WriteLine("a: " + a);
            Console.WriteLine("b: " + b);

            int x = int.MaxValue;
            int y = 1;
            //int sum = someClass.Sum(x, y);
            //Console.WriteLine("Sum: " + sum);

            int n = 10;
            int square, half, addBy3;
            int original = someClass.MultiMath(n, out square, out half, out addBy3);
            Console.WriteLine($"Original : {original}, Square: {square}, Half: {half}, AddBy3: {addBy3}");

        }
    }

    /// <summary>
    /// Provides methods for performing arithmetic operations on integers.
    /// </summary>

    public class SomeClass{
        public void SomeMethod(int n)
        {
            Console.WriteLine("Hello, World! " + n);
        }

        /// <summary>
        /// Calculates the sum of two integers and updates their values by reference.
        /// </summary>
        /// <param name="a">The first integer to add. After the method returns, this value is increased by 100.</param>
        /// <param name="b">The second integer to add. After the method returns, this value is increased by 500.</param>
        /// <returns>The sum of the original values of <paramref name="a"/> and <paramref name="b"/>.</returns>
        public int Add(ref int a, ref int b)
        {
            checked
            {
                int c = a + b;
                a += 100;
                b += 500;
                return c;
            }
        }


        /// <summary>
        /// Calculates the sum of two 32-bit signed integers.
        /// </summary>
        /// <remarks>An exception is thrown if the result exceeds the range of a 32-bit signed
        /// integer.</remarks>
        /// <param name="a">The first value to add.</param>
        /// <param name="b">The second value to add.</param>
        /// <returns>The sum of the two specified integers.</returns>

        public int Sum(int a, int b)
        {
            checked
            {
                int c = a + b;
                return c;
            }
        }


        public int MultiMath(int n, out int square, out int half, out int addBy3)
        {
            square = n * n;
            half = n / 2;
            addBy3 = n + 3;
            return n;
        }
    }

}
