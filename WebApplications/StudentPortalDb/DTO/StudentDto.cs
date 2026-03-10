using StudentPortalDb.Models;

namespace StudentPortalDb.DTO
{
    public class StudentDto
    {
        public int StudentId { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public string Status { get; set; } = null!;

        public DateOnly JoinDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public static StudentDto Map(Student s) => new()
        {
            StudentId = s.StudentId,
            FullName = "Welcome " + s.FullName,
            Email = s.Email,
            Phone = s.Phone,
            Status = s.Status,
            JoinDate = s.JoinDate,
            CreatedAt = s.CreatedAt
        };
    }
}
