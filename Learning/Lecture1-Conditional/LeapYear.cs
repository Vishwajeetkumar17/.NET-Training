using System;

namespace Lecture1
{
    public class LeapYear
    {
        public static void CheckYear()
        {
            Console.Write("Enter a year : ");
            string? input = Console.ReadLine();

            if(int.TryParse(input, out int year)){
                if(year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
                {
                    Console.WriteLine($"{year} is Leap year.");
                }
                else
                {
                    Console.WriteLine($"{year} is not a Leap year");
                }
            }
            else
            {
                Console.WriteLine("Enter a Valid Number");
            }
        }
    }
}