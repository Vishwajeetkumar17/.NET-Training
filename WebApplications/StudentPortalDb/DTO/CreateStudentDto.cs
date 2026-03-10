using System.ComponentModel.DataAnnotations;

namespace StudentPortalDb.DTO
{
    public class CreateStudentDto
    {
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
        public DateOnly JoinDate { get; set; }
    }
}
