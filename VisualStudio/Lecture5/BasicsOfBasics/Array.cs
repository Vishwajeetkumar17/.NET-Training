using System;
using System.Collections.Generic;
using System.Text;

namespace BasicsOfBasics
{
    public class Array
    {
        public static void Main(string[] args)
        {
            {
                int[][] data = new int[3][];
                data[0] = new int[] { 1, 2, 3 };
                data[1] = new int[] { 10, 20 };
                data[2] = new int[] { 7, 8, 9, 10 };

                for (int i = 0; i < data.Length; i++)
                {
                    Console.Write("Row " + i + ": ");
                    foreach (var v in data[i]) Console.Write(v + " ");
                    Console.WriteLine();
                }
            }
        }
    }
}
