using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    public class ArrayListCollection
    {
        static void Main()
        {
            ArrayList al = new ArrayList();
            al.Add(1);
            al.Add(2);
            al.Add(3);
            al.Add(4);
            al.Add(5);
            foreach (var item in al)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("The capacity of ArrayList is :" + al.Capacity);
            al.Insert(3, 300);
            foreach (var item in al)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            al.Remove(2);
            foreach (var item in al)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            al.RemoveAt(3);

            foreach (var item in al)
            {
                Console.Write(item + " ");
            }

        }
    }
}
