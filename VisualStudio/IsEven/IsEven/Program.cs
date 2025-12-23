using System;

namespace FirstApp
{
    public class Program
    {
        public bool isEven(int number)
        {
            return number % 2 == 0;
        }

        static void Main(string[] args)
        {
            Program pro = new Program();

            Console.WriteLine("Enter a number to find if it is even or odd and (q to quit)");
            string? input = Console.ReadLine();
            int number = 0;
            string result = string.Empty;


            while (input != "q" || input != "Q")
            {
                if (input == "q" || input == "Q")
                {
                    break;
                }
                if (int.TryParse(input, out number))
                {
                    result = pro.isEven(number) ? "even" : "odd";
                    Console.WriteLine($"{number} is {result}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer or 'q' to quit.");
                }
                Console.WriteLine("Enter a number to find if it is even or odd and (q to quit)");
                input = Console.ReadLine();
            }
        }
    }
}