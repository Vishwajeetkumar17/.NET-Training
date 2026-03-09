namespace LoginAndRoleBasedAccess.Models.DTOs
{
    public class CreateStudentRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string EnrollmentNumber { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }

    public class StudentDetailDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string EnrollmentNumber { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime EnrolledAt { get; set; }
        public List<StudentGradeDto> Grades { get; set; } = new();
    }

    public class AddGradeRequest
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public decimal Marks { get; set; }
        public string Grade { get; set; } = string.Empty;
    }

    public class StudentGradeDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public decimal Marks { get; set; }
        public string Grade { get; set; } = string.Empty;
        public string StaffName { get; set; } = string.Empty;
        public DateTime GradedAt { get; set; }
    }

    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
