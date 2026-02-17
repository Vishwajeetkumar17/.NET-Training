using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionPractice
{
    public class PredicateFilterWithGenericList05
    {
        public static void Main()
        {
            var nums = new List<int> { 2, 5, 8, 11, 14 };

            var evens = Filter(nums, n => n % 2 == 0);
            Console.WriteLine(string.Join(",", evens));         // Expected: 2,8,14

            var big = Filter(nums, n => n >= 10);
            Console.WriteLine(string.Join(",", big));           // Expected: 11,14
        }

        // ✅ TODO: Students implement only this function
        public static List<T> Filter<T>(List<T> items, Predicate<T> match)
        {
            // TODO: return a new list with matched items
            List<T> check = new List<T>();
            Predicate<T> filter = match;
            foreach (T item in items)
            {
                if (filter(item))
                {
                    check.Add(item);
                }
            }
            return check;
        }
    }
}
