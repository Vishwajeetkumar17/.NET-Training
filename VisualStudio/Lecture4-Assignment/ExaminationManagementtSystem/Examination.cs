using System;
using System.Collections.Generic;

namespace ExaminationManagementSystem
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
    }
     
    public class Examiner : Employee
    {
        public void EvaluateExam(Exam exam) { }
    }

    public class HOD : Employee
    {
        public void ScheduleExam(Exam exam)
        {
            exam.Status = "Scheduled";
        }

        public void AssignExaminer(Exam exam, Examiner examiner)
        {
            exam.Examiner = examiner;
        }

        public void ApproveExam(Exam exam)
        {
            exam.Status = "Approved";
        }
    }

    public class Department
    {
        public int DeptId { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; } = new();
    }

    public class Course
    {
        public string CourseName { get; set; }
        public List<Semester> Semesters { get; set; } = new();
    }

    public class Semester
    {
        public int SemesterNo { get; set; }
        public List<Exam> Exams { get; set; } = new();
    }

    public class Exam
    {
        public int ExamId { get; set; }
        public DateTime ExamDate { get; set; }
        public string Status { get; set; }

        public Examiner Examiner { get; set; }
        public Room Room { get; set; }
        public List<Student> Students { get; set; } = new();
    }


    public class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
    }


    public class Block
    {
        public string BlockName { get; set; }
        public List<Room> Rooms { get; set; } = new();
    }

    public class Room
    {
        public string RoomNo { get; set; }
        public int Capacity { get; set; }
        public Block Block { get; set; }
    }
}
