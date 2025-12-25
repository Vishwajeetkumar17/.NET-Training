namespace ExaminationManagementtSystem
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Position { get; set; }
        public int DeptId { get; set; }
    }

    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class StuDepartment
    {
        public int DeptId { get; set; }
        public string DepName { get; set; }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public int DeptId { get; set; }

        public int BatchYear { get; set; }
    }

    public class HOD : Employee
    {
        
    }

    public class Examiner : Employee
    {

    }

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int DeptId { get; set; }
        public int Credits { get; set; }
    }

    public class Exam
    {
        public int ExamId { get; set; }
        public int CourseId { get; set; }
        public DateTime ExamDate { get; set; }
        public int DurationInHours { get; set; }

        public int DeptId { get; set; }

        public int StudentId { get; set; }
    }
}
