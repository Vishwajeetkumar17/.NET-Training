using System;

namespace Lecture12
{
    // Summary: Converts a binary string to its decimal value after validating
    // that the input contains only 0s and 1s.
    public class BinToDec
    {
        public static void ConvertBinToDec()
        {
            Console.Write("Enter a binary number: ");
            string? input = Console.ReadLine();

            if (input != null && IsBinary(input))
            {
                int decimalValue = 0;
                int power = 0;

                for (int i = input.Length - 1; i >= 0; i--)
                {
                    if (input[i] == '1')
                    {
                        decimalValue += (int)Math.Pow(2, power);
                    }
                    power++;
                }

                Console.WriteLine($"Decimal value: {decimalValue}");
            }
            else
            {
                Console.WriteLine("Please enter a valid binary number.");
            }
        }

        private static bool IsBinary(string input)
        {
            foreach (char c in input)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            return true;
        }
    }
}