using System;

namespace StudentInfo
{
    class Program
    {
        public class Student
        {
            public int StId { get; set; }
            public string Name { get; set; }

            public string EduLevel { get; set; }

            public void DisplayInfo()
            {
                Console.WriteLine($"Student ID: {StId}");
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Education Level: {EduLevel}");
            }

        }
        public class HigherSchoolStudent : Student
        {
            List<int> hSchool = new List<int>();

            public void AddHigherSchoolStudent(int StId)
            {
                hSchool.Add(StId);
            }

            public void DisplayHigherSchoolStudents()
            {
                Console.WriteLine("Higher School Students IDs And Names:");
                for(int i = 0; i < hSchool.Count; i++)
                {
                    Console.WriteLine($"Id = {hSchool[i]} and Name = {Name}");
                }
            }
        }

        public class UGStudent : Student
        {
            List<int> ug = new List<int>();

            public void AddHigherSchoolStudent(int StId)
            {
                ug.Add(StId);
            }

            public void DisplayHigherSchoolStudents()
            {
                Console.WriteLine("Higher School Students IDs And Names:");
                for (int i = 0; i < ug.Count; i++)
                {
                    Console.WriteLine($"Id = {ug[i]} and Name = {Name}");
                }
            }
        }

        public class PGStudent : Student
        {
            List<int> pg = new List<int>();

            public void AddHigherSchoolStudent(int StId)
            {
                pg.Add(StId);
            }

            public void DisplayHigherSchoolStudents()
            {
                Console.WriteLine("Higher School Students IDs And Names:");
                for (int i = 0; i < pg.Count; i++)
                {
                    Console.WriteLine($"Id = {pg[i]} and Name = {Name}");
                }
            }
        }

        public static void
    }
}