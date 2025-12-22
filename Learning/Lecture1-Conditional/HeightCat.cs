using System;

namespace Lecture1
{
    // Summary: Categorizes height in centimeters into Dwarf, Average, Tall,
    // or Abnormal ranges.
    public class HeightCat
    {
        public static void HeightCategory()
        {
            Console.Write("Enter Height(in cms) : ");
            string? input = Console.ReadLine();
            int height = 0;
            string category = string.Empty;

            if (int.TryParse(input, out height))
            {
                if (height < 150)
                {
                    category = "Dwarf";
                }
                else if (height >= 150 && height < 165)
                {
                    category = "Average";
                }
                else if (height >= 165 && height < 190)
                {
                    category = "Tall";
                }
                else
                {
                    category = "Abnormal";
                }
            }

            Console.WriteLine($"The Category is : {category}");
        }
    }
}