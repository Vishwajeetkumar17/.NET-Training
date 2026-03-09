using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LoginAndRoleBasedAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace LoginAndRoleBasedAccess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Student")]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboard()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            if (!int.TryParse(userId, out int parsedUserId))
            {
                return Unauthorized(new { message = "Invalid user ID" });
            }

            var studentRecord = await _context.StudentRecords
                .FirstOrDefaultAsync(s => s.UserId == parsedUserId);

            var gradesCount = studentRecord != null
                ? await _context.StudentGrades.Where(g => g.StudentId == studentRecord.Id).CountAsync()
                : 0;

            return Ok(new
            {
                message = "Welcome to Student Dashboard!",
                user = User.Identity?.Name,
                role = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Role)?.Value,
                gradesReceived = gradesCount,
                enrollmentNumber = studentRecord?.EnrollmentNumber
            });
        }

        [HttpGet("courses")]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _context.Courses
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.Credits,
                    c.Description
                })
                .ToListAsync();

            return Ok(courses);
        }

        [HttpGet("my-grades")]
        public async Task<IActionResult> GetMyGrades()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            if (!int.TryParse(userId, out int parsedUserId))
            {
                return Unauthorized(new { message = "Invalid user ID" });
            }

            var studentRecord = await _context.StudentRecords
                .FirstOrDefaultAsync(s => s.UserId == parsedUserId);

            if (studentRecord == null)
            {
                return NotFound(new { message = "Student record not found" });
            }

            var grades = await _context.StudentGrades
                .Where(g => g.StudentId == studentRecord.Id)
                .Include(g => g.Course)
                .Include(g => g.Staff)
                .Select(g => new
                {
                    g.Id,
                    courseName = g.Course!.Name,
                    g.Marks,
                    g.Grade,
                    staffName = g.Staff!.Username,
                    g.GradedAt
                })
                .ToListAsync();

            return Ok(new
            {
                studentName = User.Identity?.Name,
                enrollmentNumber = studentRecord.EnrollmentNumber,
                grades
            });
        }
    }
}
