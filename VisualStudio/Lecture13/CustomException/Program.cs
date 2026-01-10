namespace CustomException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter numerator: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Enter denominator: ");
            int b = int.Parse(Console.ReadLine());
            try
            {
                int result = Divide(a, b);
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByOddException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (DivideByZeroInternalException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public static int Divide(int a, int b)
        {
            try
            {
                if (b % 2 == 1)
                {
                    throw new DivideByOddException();
                }
                return a / b;
            }
            catch (DivideByZeroException ex)
            {
                throw new DivideByZeroInternalException(
                    "Internal Exception Occurred. Please contact admin.",
                    ex
                );
            }
        }
    }
}
