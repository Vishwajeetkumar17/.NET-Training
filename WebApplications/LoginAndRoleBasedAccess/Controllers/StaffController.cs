using LoginAndRoleBasedAccess.Data;
using LoginAndRoleBasedAccess.Models;
using LoginAndRoleBasedAccess.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginAndRoleBasedAccess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Staff")]
    public class StaffController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StaffController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboard()
        {
            var staffId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            var gradesCount = await _context.StudentGrades
                .Where(g => g.StaffId == int.Parse(staffId ?? "0"))
                .CountAsync();

            return Ok(new
            {
                message = "Welcome to Staff Dashboard!",
                user = User.Identity?.Name,
                role = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Role)?.Value,
                gradesManaged = gradesCount
            });
        }

        [HttpGet("students")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _context.StudentRecords
                .Include(s => s.User)
                .Select(s => new
                {
                    s.Id,
                    s.UserId,
                    s.User!.Username,
                    s.EnrollmentNumber,
                    s.PhoneNumber,
                    s.EnrolledAt
                })
                .ToListAsync();

            return Ok(students);
        }

        [HttpGet("students/{studentId}")]
        public async Task<IActionResult> GetStudentById(int studentId)
        {
            var student = await _context.StudentRecords
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == studentId);

            if (student == null)
            {
                return NotFound(new { message = "Student not found" });
            }

            var grades = await _context.StudentGrades
                .Where(g => g.StudentId == studentId)
                .Include(g => g.Course)
                .Select(g => new
                {
                    g.Id,
                    g.CourseId,
                    g.Course!.Name,
                    g.Marks,
                    g.Grade,
                    g.GradedAt
                })
                .ToListAsync();

            return Ok(new
            {
                student = new
                {
                    student.Id,
                    student.UserId,
                    student.User!.Username,
                    student.EnrollmentNumber,
                    student.PhoneNumber
                },
                grades
            });
        }

        [HttpGet("courses")]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _context.Courses
                .Select(c => new CourseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Credits = c.Credits,
                    Description = c.Description
                })
                .ToListAsync();

            return Ok(courses);
        }

        [HttpPost("grades")]
        public async Task<IActionResult> AssignGrade([FromBody] AddGradeRequest request)
        {
            if (request.StudentId <= 0 || request.CourseId <= 0)
            {
                return BadRequest(new { message = "Invalid Student ID or Course ID" });
            }

            if (request.Marks < 0 || request.Marks > 100)
            {
                return BadRequest(new { message = "Marks must be between 0 and 100" });
            }

            var student = await _context.StudentRecords.FindAsync(request.StudentId);
            if (student == null)
            {
                return NotFound(new { message = "Student not found" });
            }

            var course = await _context.Courses.FindAsync(request.CourseId);
            if (course == null)
            {
                return NotFound(new { message = "Course not found" });
            }

            var staffId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            if (!int.TryParse(staffId, out int parsedStaffId))
            {
                return Unauthorized(new { message = "Invalid staff ID" });
            }

            var existingGrade = await _context.StudentGrades
                .FirstOrDefaultAsync(g => g.StudentId == request.StudentId && g.CourseId == request.CourseId);

            if (existingGrade != null)
            {
                existingGrade.Marks = request.Marks;
                existingGrade.Grade = request.Grade;
                existingGrade.GradedAt = DateTime.UtcNow;
                _context.StudentGrades.Update(existingGrade);
            }
            else
            {
                var grade = new StudentGrade
                {
                    StudentId = request.StudentId,
                    CourseId = request.CourseId,
                    StaffId = parsedStaffId,
                    Marks = request.Marks,
                    Grade = request.Grade,
                    GradedAt = DateTime.UtcNow
                };
                _context.StudentGrades.Add(grade);
            }

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Grade assigned successfully",
                data = new
                {
                    studentId = request.StudentId,
                    courseId = request.CourseId,
                    marks = request.Marks,
                    grade = request.Grade
                }
            });
        }

        [HttpGet("grades")]
        public async Task<IActionResult> GetMyGrades()
        {
            var staffId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            if (!int.TryParse(staffId, out int parsedStaffId))
            {
                return Unauthorized(new { message = "Invalid staff ID" });
            }

            var grades = await _context.StudentGrades
                .Where(g => g.StaffId == parsedStaffId)
                .Include(g => g.Student)
                .ThenInclude(s => s!.User)
                .Include(g => g.Course)
                .Select(g => new StudentGradeDto
                {
                    Id = g.Id,
                    StudentId = g.StudentId,
                    StudentName = g.Student!.User!.Username,
                    CourseId = g.CourseId,
                    CourseName = g.Course!.Name,
                    Marks = g.Marks,
                    Grade = g.Grade,
                    StaffName = "You",
                    GradedAt = g.GradedAt
                })
                .ToListAsync();

            return Ok(grades);
        }

        [HttpGet("grades/student/{studentId}")]
        public async Task<IActionResult> GetStudentGrades(int studentId)
        {
            var student = await _context.StudentRecords.FindAsync(studentId);
            if (student == null)
            {
                return NotFound(new { message = "Student not found" });
            }

            var grades = await _context.StudentGrades
                .Where(g => g.StudentId == studentId)
                .Include(g => g.Course)
                .Include(g => g.Staff)
                .Select(g => new StudentGradeDto
                {
                    Id = g.Id,
                    StudentId = g.StudentId,
                    StudentName = student.User!.Username,
                    CourseId = g.CourseId,
                    CourseName = g.Course!.Name,
                    Marks = g.Marks,
                    Grade = g.Grade,
                    StaffName = g.Staff!.Username,
                    GradedAt = g.GradedAt
                })
                .ToListAsync();

            return Ok(grades);
        }
    }
}
