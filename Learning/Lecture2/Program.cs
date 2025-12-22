using System;

namespace Lecture2
{

    public class Student : System.Object
    {
        private string name;
        private int regNo;

        public Student(string name, int regNo)
        {
            this.name = name;
            this.regNo = regNo;
        }

        public string getName()
        {
            return name;
        }
        public int getRegNo()
        {
            return regNo;
        }
        
        public static void Main()
        {
            Student stu = new Student("Vishwajeet", 17);
            Console.WriteLine(stu.getName());
            Console.WriteLine(stu.getRegNo());
        }
    }
}