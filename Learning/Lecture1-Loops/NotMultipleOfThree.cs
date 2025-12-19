using System;

namespace Lecture12
{
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