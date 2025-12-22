using System;

namespace Lecture12
{
    // Summary: Prints numbers from 1 to 50, skipping those that are multiples of three
    // using continue in a for-loop.
    public class NotMultipleOfThree
    {
        public static void PrintNumbers()
        {
            for (int i = 1; i <= 50; i++)
            {
                if (i % 3 == 0)
                {
                    continue;
                }
                Console.WriteLine(i);
            }
        }
    }
}