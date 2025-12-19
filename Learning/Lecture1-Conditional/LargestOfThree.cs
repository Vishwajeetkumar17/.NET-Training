using System;

namespace Lecture1
{
    public class LargestOfThree
    {
        public static void Largest()
        {
            Console.Write("Enter First number as input : ");
            string? input1 = Console.ReadLine();
            Console.Write("Enter Second number as input : ");
            string? input2 = Console.ReadLine();
            Console.Write("Enter Third number as input : ");
            string? input3 = Console.ReadLine();
            int largest = 0;

            if (int.TryParse(input1, out int num1) && int.TryParse(input2, out int num2) && int.TryParse(input3, out int num3))
            {
                if (num1 > num2 && num1 > num3)
                {
                    largest = num1;
                }
                else if (num2 > num1 && num2 > num3)
                {
                    largest = num2;
                }
                else
                {
                    largest = num3;
                }
            }

            Console.WriteLine($"The largest number is : {largest}");
        }
    }
}