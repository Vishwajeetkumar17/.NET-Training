using System;

namespace Lecture2
{
    class Program
    {
        /// <summary>
        /// Entry point of the Application
        /// Creates an instance of Student class and displays the details
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {
            Student student = new Student("Vishwajeet", 17);
            Console.WriteLine(student.getName());
            Console.WriteLine(student.getRegNo());
        }
    }
}