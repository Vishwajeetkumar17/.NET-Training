using System;

namespace Lecture1
{
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