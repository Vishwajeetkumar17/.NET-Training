using System;
using System.Collections.Generic;
using System.Text;

namespace Indexer
{
    public partial class Student
    {
        public int Rno;
        public string Name;
        private string Address;
        private string[] Books = new string[3];
        public string this[int index]
        {
            get
            {
                return Books[index];
            }
            set
            {
                Books[index] = value;
            }
        }

        public void Print()
        {
            Console.WriteLine("Hello from Student Class");
        }
    }

    public class StudentDetails
    {
        public static void Main()
        {
            Student s = new Student { Rno = 1, Name = "Vishwajeet" };
            s[0] = "Maths";
            s[1] = "Science";
            s[2] = "English";
            Console.WriteLine(s[0]);
            Console.WriteLine(s[1]);
            Console.WriteLine(s[2]);
            
        }
    }
}
