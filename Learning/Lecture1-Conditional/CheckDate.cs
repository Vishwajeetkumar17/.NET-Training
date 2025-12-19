using System;

namespace Lecture1
{
    public class CheckDate
    {
        public static void ValidateDate()
        {
            Console.Write("Enter day: ");
            string? dayInput = Console.ReadLine();
            Console.Write("Enter month: ");
            string? monthInput = Console.ReadLine();
            Console.Write("Enter year: ");
            string? yearInput = Console.ReadLine();

            if (int.TryParse(dayInput, out int day) &&
                int.TryParse(monthInput, out int month) &&
                int.TryParse(yearInput, out int year))
            {
                bool isValidDate = false;

                if (year >= 1 && month >= 1 && month <= 12)
                {
                    int[] daysInMonth = { 31, (IsLeapYear(year) ? 29 : 28), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

                    if (day >= 1 && day <= daysInMonth[month - 1])
                    {
                        isValidDate = true;
                    }
                }

                if (isValidDate)
                {
                    Console.WriteLine($"{day}/{month}/{year} is a valid date.");
                }
                else
                {
                    Console.WriteLine($"{day}/{month}/{year} is not a valid date.");
                }
            }
            else
            {
                Console.WriteLine("Please enter valid integers for day, month, and year.");
            }
        }

        private static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }
    }
}