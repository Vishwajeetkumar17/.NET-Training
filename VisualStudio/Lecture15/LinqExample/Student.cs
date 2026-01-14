using System;
using System.Collections.Generic;
using System.Text;

namespace LinqExample
{
    public class Student
    {
        public int Id;
        public string name;
        public int mark1;
        public int mark2;

        static void Main()
        {
            Student s1 = new Student { Id = 101, name = "A", mark1 = 100, mark2 = 90 };
            Student s2 = new Student { Id = 102, name = "B", mark1 = 97, mark2 = 80 };

            Student[] Stu = { s1, s2 };

            var aver = (from s in Stu select (s.mark1 + s.mark2) / 2).Max();
            Console.Write(aver);
        }
    }
}
