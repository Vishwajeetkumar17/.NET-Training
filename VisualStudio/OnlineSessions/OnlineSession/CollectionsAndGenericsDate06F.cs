using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OnlineSession
{
    class Student
    {
        public string Name;
        public int Marks;
    }

    public class CollectionsAndGenericsDate06F
    {
        static void Main()
        {
            ArrayList numbers = new ArrayList();
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }

            //generic
            List<Student> students = new List<Student>();

            students.Add(new Student { Name = "A", Marks = 12 });
            students.Add(new Student { Name = "B", Marks = 34 });

            foreach (Student s in students)
            {
                Console.WriteLine($"{s.Name} - {s.Marks}");
            }
        }
    }
}
