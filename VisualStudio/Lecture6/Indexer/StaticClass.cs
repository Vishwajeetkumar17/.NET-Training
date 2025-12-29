using System;
using System.Collections.Generic;
using System.Text;

namespace Indexer
{
    public static class StaticClass
    {
        public static int Rno;

        static StaticClass()
        {
            Rno = 10;
            Console.WriteLine("Static Constructor Called");
        }

        //public static void Print()
        //{
        //    Console.WriteLine("Hello from Static Class");
        //    Console.WriteLine("Rno: " + Rno);
        //}

        public static int getCount(this string str)
        {
            int count = 0;
            foreach (char c in str)
            {
                if (c.Equals(' '))
                    count++;
            }
            return count;
        }

        public static void Main(string[] args) 
        {
            //StaticClass.Print();
            //StaticClass.Print();
            string str = "I am fine ";
            Console.WriteLine(str.getCount());
        }
    }
}
