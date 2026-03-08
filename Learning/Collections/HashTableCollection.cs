using System;

using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    public class HashTableCollection
    {
        public static void Main()
        {
            Hashtable ht = new Hashtable();
            ht.Add("1", "One");
            ht.Add("2", "Two");
            ht.Add("3", "Three");
            ht.Add("4", "Four");
            ht.Add("5", "Five");
            foreach (var item in ht.Keys)
            {
                Console.WriteLine(item + " : " + ht[item]);
            }
            Console.WriteLine("Value for key '3': " + ht["3"]);
            ht.Remove("2");
            Console.WriteLine("After removing key '2':");
            foreach (var item in ht.Keys)
            {
                Console.WriteLine(item + " : " + ht[item]);
            }

        }
    }
}
