using System;

namespace Lecture1
{
    // Summary: Returns true if the provided integer is even; otherwise false.
    public class EvenOdd
    {
        public static bool EvenOrOdd(int number)
        {
            if (number % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}