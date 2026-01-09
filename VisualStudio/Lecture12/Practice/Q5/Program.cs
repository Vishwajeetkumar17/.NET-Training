using System;
using System.Collections.Generic;

namespace Q5
{
    // Delegate to check scholarship eligibility
    public delegate bool IsEligibleforScholarship(Student std);

    /// <summary>
    /// Demonstrates scholarship eligibility checking using delegates
    /// and processes a list of students.
    /// </summary>
    public class Program
    {
        #region Eligibility Logic

        // Determines whether a student is eligible for scholarship
        public static bool ScholarshipEligibility(Student std)
        {
            if (std != null && std.Marks > 80 && std.SportsGrade == 'A')
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Application Entry Point

        // Entry point of the application
        public static void Main(string[] args)
        {
            List<Student> lstStudent = new List<Student>();

            Student obj1 = new Student
            {
                RollNo = 1,
                Name = "Raj",
                Marks = 75,
                SportsGrade = 'A'
            };
            Student obj2 = new Student
            {
                RollNo = 2,
                Name = "Rahul",
                Marks = 82,
                SportsGrade = 'A'
            };
            Student obj3 = new Student
            {
                RollNo = 3,
                Name = "Kiran",
                Marks = 89,
                SportsGrade = 'B'
            };
            Student obj4 = new Student
            {
                RollNo = 4,
                Name = "Sunil",
                Marks = 86,
                SportsGrade = 'A'
            };

            lstStudent.Add(obj1);
            lstStudent.Add(obj2);
            lstStudent.Add(obj3);
            lstStudent.Add(obj4);

            string result = Student.GetEligibleStudents(lstStudent, ScholarshipEligibility);
            Console.WriteLine(result);
        }

        #endregion
    }
}
