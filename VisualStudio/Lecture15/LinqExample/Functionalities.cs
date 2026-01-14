using System;
using System.Collections.Generic;
using System.Text;

namespace LinqExample
{
    public class Functionalities
    {
        public static void Main(string[] args) 
        {
        // returns a boolean value
            Predicate<int> isEven = n => n % 2 == 0;
            bool check = isEven(10);
            Console.WriteLine(check);

            // a kind of delegate with void return type

            Action<string> logger = message =>
            {
                Console.WriteLine($"[LOG] {message} at {DateTime.Now}"); 
            };

            if (DateTime.Now.Hour < 12)
            {
                logger = GoodMorning();
            }
            else
            {
                logger = GoodDay();
            }

            logger("Application started");

            // function delegrate
            Func<int, int, int, string> multiplyResult = (x, y, z) =>
            {
                return $"{x} times {y} times {z} is {x * y * z}";
            };
            string result = multiplyResult(3, 4, 5);
            Console.WriteLine(result);
        }

        private static Action<string> GoodDay()
        {
            return message =>
            {
                Console.WriteLine($"[LOG] Good Day {message} at {DateTime.Now}");
            };
        }

        private static Action<string> GoodMorning()
        {
            return message =>
            {
                Console.WriteLine($"[LOG] Good Morning {message} at {DateTime.Now}");
            };
        }
    }
}
