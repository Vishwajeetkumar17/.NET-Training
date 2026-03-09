using System.ComponentModel.DataAnnotations;

namespace ViewsForWebApi.Models
{
    public enum UserRole
    {
        Student,
        Staff,
        Admin
    }

    public class SignupRequestModel
    {
        [Required]
        [MinLength(3)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public UserRole Role { get; set; } = UserRole.Student;
    }

    public class LoginRequestModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class AuthResponseModel
    {
        public string Token { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; }
    }

    public class DashboardResponseModel
    {
        public string Message { get; set; } = string.Empty;
        public string? User { get; set; }
        public string? Role { get; set; }
        public int? TotalUsers { get; set; }
        public int? TotalStudents { get; set; }
        public int? TotalGrades { get; set; }
        public int? GradesManaged { get; set; }
        public int? GradesReceived { get; set; }
        public string? EnrollmentNumber { get; set; }
    }

    public class AppUserModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
    }

    public class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string Description { get; set; } = string.Empty;
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

    public class CreateStudentRequestModel
    {
        [Required]
        [MinLength(3)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string EnrollmentNumber { get; set; } = string.Empty;

        public string DateOfBirth { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
    }

    public class AddGradeRequestModel
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal Marks { get; set; }

        [Required]
        public string Grade { get; set; } = string.Empty;
    }

    public class GradeRequestModel
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public string Grade { get; set; } = string.Empty;
    }

    public class MessageResponseModel
    {
        public string Message { get; set; } = string.Empty;
    }

    public class GradeResponseModel : MessageResponseModel
    {
        public int StudentId { get; set; }
        public string Grade { get; set; } = string.Empty;
    }

    public class ApiServiceResult<T>
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Data { get; set; }
    }

    public class CreateStaffRequestModel
    {
        [Required]
        [MinLength(3)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }

    public class StaffDetailDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int GradesAssigned { get; set; }
    }
}
