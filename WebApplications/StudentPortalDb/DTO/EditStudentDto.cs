using System.ComponentModel.DataAnnotations;
using StudentPortalDb.Models;

namespace StudentPortalDb.DTO
{
    public class EditStudentDto
    {
        public int StudentId { get; set; }

        [Required]
        [StringLength(120)]
        public string FullName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(180)]
        public string Email { get; set; } = null!;

        [StringLength(30)]
        public string? Phone { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = null!;

        [Required]
        public DateOnly JoinDate { get; set; }

        public static EditStudentDto Map(Student s) => new()
        {
            StudentId = s.StudentId,
            FullName = s.FullName,
            Email = s.Email,
            Phone = s.Phone,
            Status = s.Status,
            JoinDate = s.JoinDate
        };
    }
}
