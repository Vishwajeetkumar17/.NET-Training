using System;
using System.Collections.Generic;

namespace CustomLinq
{
    public static class MyLinq
    {
        public static List<T> WhereEx<T>(
            List<T> source,
            Func<T, bool> predicate)
        {
            var result = new List<T>();
            foreach (var item in source)
            {
                if (predicate(item))
                    result.Add(item);
            }
            return result;
        }
        public static List<TResult> SelectEx<T, TResult>(
            List<T> source,
            Func<T, TResult> selector)
        {
            var result = new List<TResult>();
            foreach (var item in source)
            {
                result.Add(selector(item));
            }
            return result;
        }
        public static List<T> DistinctEx<T>(List<T> source)
        {
            var result = new List<T>();
            var set = new HashSet<T>();

            foreach (var item in source)
            {
                if (set.Add(item))
                    result.Add(item);
            }
            return result;
        }
        public static Dictionary<TKey, List<T>> GroupByEx<T, TKey>(
            List<T> source,
            Func<T, TKey> keySelector)
        {
            var result = new Dictionary<TKey, List<T>>();

            foreach (var item in source)
            {
                var key = keySelector(item);

                if (!result.ContainsKey(key))
                    result[key] = new List<T>();

                result[key].Add(item);
            }

            return result;
        }
    }
    class Program
    {
        static void Main()
        {
            var numbers = new List<int> { 1, 2, 3, 2, 4, 3, 5 };

            var filtered = MyLinq.WhereEx(numbers, x => x > 2);
            var projected = MyLinq.SelectEx(filtered, x => x * 10);
            var distinct = MyLinq.DistinctEx(projected);
            var grouped = MyLinq.GroupByEx(numbers, x => x % 2 == 0 ? "Even" : "Odd");

            foreach (var v in distinct)
                Console.WriteLine(v);

            foreach (var g in grouped)
            {
                Console.WriteLine(g.Key);
                foreach (var item in g.Value)
                    Console.WriteLine(item);
            }
        }
    }
}
