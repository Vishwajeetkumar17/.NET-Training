using System;
using System.Collections.Generic;
using System.Linq;

namespace Second
{
    // Base constraints
    public interface IStudent
    {
        int StudentId { get; }
        string Name { get; }
        int Semester { get; }
    }

    public interface ICourse
    {
        string CourseCode { get; }
        string Title { get; }
        int MaxCapacity { get; }
        int Credits { get; }
    }

    // 1. Generic enrollment system
    public class EnrollmentSystem<TStudent, TCourse>
        where TStudent : IStudent
        where TCourse : ICourse
    {
        private Dictionary<TCourse, List<TStudent>> _enrollments = new();

        // TODO: Enroll student with constraints
        public bool EnrollStudent(TStudent student, TCourse course)
        {
            // Rules:
            // - Course not at capacity
            // - Student not already enrolled
            // - Student semester >= course prerequisite (if any)
            // - Return success/failure with reason

            if (student == null || course == null)
                return false;

            if (!_enrollments.ContainsKey(course))
                _enrollments[course] = new List<TStudent>();

            var list = _enrollments[course];

            if (list.Any(s => s.StudentId == student.StudentId))
                return false;

            if (list.Count >= course.MaxCapacity)
                return false;

            if (course is LabCourse lc && student.Semester < lc.RequiredSemester)
                return false;

            list.Add(student);
            return true;
        }

        // TODO: Get students for course
        public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
        {
            // Return immutable list
            if (_enrollments.TryGetValue(course, out var list))
                return list.AsReadOnly();

            return new List<TStudent>().AsReadOnly();
        }

        // TODO: Get courses for student
        public IEnumerable<TCourse> GetStudentCourses(TStudent student)
        {
            // Return courses student is enrolled in
            return _enrollments.Where(e => e.Value.Any(s => s.StudentId == student.StudentId)).Select(e => e.Key);
        }

        // TODO: Calculate student workload
        public int CalculateStudentWorkload(TStudent student)
        {
            // Sum credits of all enrolled courses
            return GetStudentCourses(student).Sum(c => c.Credits);
        }
    }

    // 2. Specialized implementations
    public class EngineeringStudent : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }
        public string Specialization { get; set; }
    }

    public class LabCourse : ICourse
    {
        public string CourseCode { get; set; }
        public string Title { get; set; }
        public int MaxCapacity { get; set; }
        public int Credits { get; set; }
        public string LabEquipment { get; set; }
        public int RequiredSemester { get; set; } // Prerequisite
    }

    // 3. Generic gradebook
    public class GradeBook<TStudent, TCourse>
        where TStudent : IStudent
        where TCourse : ICourse
    {
        private Dictionary<(TStudent, TCourse), double> _grades = new();
        private EnrollmentSystem<TStudent, TCourse> _enrollment;

        public GradeBook(EnrollmentSystem<TStudent, TCourse> enrollment)
        {
            _enrollment = enrollment;
        }

        // TODO: Add grade with validation
        public void AddGrade(TStudent student, TCourse course, double grade)
        {
            // Grade must be between 0 and 100
            // Student must be enrolled in course

            if (grade < 0 || grade > 100)
                throw new Exception("Invalid grade");

            if (!_enrollment.GetEnrolledStudents(course).Any(s => s.StudentId == student.StudentId))
                throw new Exception("Student not enrolled");

            _grades[(student, course)] = grade;
        }

        // TODO: Calculate GPA for student
        public double? CalculateGPA(TStudent student)
        {
            // Weighted by course credits
            // Return null if no grades

            var records = _grades.Where(g => g.Key.Item1.StudentId == student.StudentId).Select(g => (grade: g.Value, course: g.Key.Item2)).ToList();

            if (!records.Any())
                return null;

            double weighted = records.Sum(r => r.grade * r.course.Credits);
            int credits = records.Sum(r => r.course.Credits);

            return weighted / credits;
        }

        // TODO: Find top student in course
        public (TStudent student, double grade)? GetTopStudent(TCourse course)
        {
            // Return student with highest grade

            var result = _grades.Where(g => EqualityComparer<TCourse>.Default.Equals(g.Key.Item2, course)).OrderByDescending(g => g.Value).FirstOrDefault();

            if (result.Key.Item1 == null)
                return null;

            return (result.Key.Item1, result.Value);
        }
    }

    // 4. TEST SCENARIO: Create a simulation
    // a) Create 3 EngineeringStudent instances
    // b) Create 2 LabCourse instances with prerequisites
    // c) Demonstrate:
    //    - Successful enrollment
    //    - Failed enrollment (capacity, prerequisite)
    //    - Grade assignment
    //    - GPA calculation
    //    - Top student per course

    public class Program
    {
        public static void Main()
        {
            var s1 = new EngineeringStudent { StudentId = 1, Name = "Aman", Semester = 3 };
            var s2 = new EngineeringStudent { StudentId = 2, Name = "Riya", Semester = 1 };
            var s3 = new EngineeringStudent { StudentId = 3, Name = "Karan", Semester = 4 };

            var c1 = new LabCourse { CourseCode = "LAB1", Title = "Electronics Lab", MaxCapacity = 2, Credits = 3, RequiredSemester = 2 };
            var c2 = new LabCourse { CourseCode = "LAB2", Title = "Automation Lab", MaxCapacity = 1, Credits = 4, RequiredSemester = 3 };

            var enrollment = new EnrollmentSystem<EngineeringStudent, LabCourse>();

            enrollment.EnrollStudent(s1, c1);
            enrollment.EnrollStudent(s3, c1);
            enrollment.EnrollStudent(s2, c1);
            enrollment.EnrollStudent(s2, c2);
            enrollment.EnrollStudent(s1, c2);

            var gradebook = new GradeBook<EngineeringStudent, LabCourse>(enrollment);

            gradebook.AddGrade(s1, c1, 85);
            gradebook.AddGrade(s3, c1, 90);
            gradebook.AddGrade(s1, c2, 88);

            Console.WriteLine(gradebook.CalculateGPA(s1));

            var top = gradebook.GetTopStudent(c1);
            if (top != null)
                Console.WriteLine($"{top?.student.Name} {top?.grade}");
        }
    }

}
