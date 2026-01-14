using System;
using System.Collections.Generic;
using System.Text;

namespace LinqExample
{
    internal class GenericWithLinq
    {
       
        static void Main()
        {
            List<int> numbers = new List<int>{ 5, 12, 7, 20, 3, 15, 8 };

            var evenNumbers = numbers
                .Where(n => n % 2 == 0)
                .OrderByDescending(n => n)
                .ToList();

            foreach (var num in evenNumbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
