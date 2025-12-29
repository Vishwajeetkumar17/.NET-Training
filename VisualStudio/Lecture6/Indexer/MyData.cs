using System;
using System.Collections.Generic;
using System.Text;

namespace Indexer
{
    public class MyData
    {
        private string[] values = new string[3];
        
        public string this[int index]
        {
            get
            {
                return values[index];
            }
            set
            {
                values[index] = value;
            }
        }

    }
    public class Program
    {
        static void Main()
        {
            MyData obj = new MyData();
            obj[0] = "c";
            obj[1] = "c++";
            obj[2] = "c#";

            Console.WriteLine(obj[0]);
            Console.WriteLine(obj[1]);
            Console.WriteLine(obj[2]);
        }
    }
}
