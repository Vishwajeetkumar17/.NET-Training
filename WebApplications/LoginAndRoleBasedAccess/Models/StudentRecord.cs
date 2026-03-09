namespace LoginAndRoleBasedAccess.Models
{
    public class StudentRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string EnrollmentNumber { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
    }

    public class StudentGrade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public StudentRecord? Student { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public int StaffId { get; set; }
        public User? Staff { get; set; }
        public decimal Marks { get; set; }
        public string Grade { get; set; } = string.Empty;
        public DateTime GradedAt { get; set; } = DateTime.UtcNow;
    }

    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
