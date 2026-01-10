namespace Example_enum
{
    // Knwon constant for a type or values
    public enum WeekDays
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public enum ProductCategory
    {
        Electronics = 1,
        Groceries = 2,
        Clothing = 3,
        Furniture = 4
    }
    public class Example_Enum
    {
        public static void Main()
        {
            //WeekDays today = WeekDays.Wednesday;
            //Console.WriteLine("Today is: " + today);

            //int enumValue = (int)WeekDays.Friday;
            //ProductCategory category = ProductCategory.Electronics;
            //Console.WriteLine("Selected category: " + category + " with value " + (int)category);
            int numValuePara = 0;
            string variableForDay = GetWeekDay(WeekDays.Thursday, ref numValuePara);
            Console.WriteLine(variableForDay);
            Console.WriteLine(numValuePara);
        }
        public static string GetWeekDay(WeekDays weekDays, ref int numValue)
        {
            numValue = (int)weekDays;
            return weekDays.ToString();
        }

        public static String MenuByDay(WeekDays day)
        {
            switch (day)
            {
                case WeekDays.Monday:
                    return "Pasta";
                case WeekDays.Tuesday:
                    return "Tacos";
                case WeekDays.Wednesday:
                    return "Chicken Curry";
                case WeekDays.Thursday:
                    return "Pizza";
                case WeekDays.Friday:
                    return "Fish and Chips";
                case WeekDays.Saturday:
                    return "Burgers";
                case WeekDays.Sunday:
                    return "Roast Dinner";
                default:
                    return "Unknown Day";
            }
        }
    }
}
