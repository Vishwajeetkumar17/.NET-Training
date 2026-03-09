using LoginAndRoleBasedAccess.Data;
using LoginAndRoleBasedAccess.Models;
using LoginAndRoleBasedAccess.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace LoginAndRoleBasedAccess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboard()
        {
            var totalUsers = await _context.Users.CountAsync();
            var totalStudents = await _context.StudentRecords.CountAsync();
            var totalGrades = await _context.StudentGrades.CountAsync();
            
            return Ok(new
            {
                message = "Welcome to Admin Dashboard!",
                user = User.Identity?.Name,
                role = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Role)?.Value,
                totalUsers,
                totalStudents,
                totalGrades
            });
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users
                .Select(u => new
                {
                    u.Id,
                    u.Username,
                    u.Email,
                    u.Role,
                    u.CreatedAt
                })
                .ToListAsync();

            return Ok(users);
        }

        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            
            return Ok(new { message = "User deleted successfully" });
        }

        [HttpPost("students")]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Email))
            {
                return BadRequest(new { message = "Username and Email are required" });
            }

            var userExists = await _context.Users.AnyAsync(u => u.Username == request.Username || u.Email == request.Email);
            if (userExists)
            {
                return BadRequest(new { message = "Username or email already exists" });
            }

            var enrollmentExists = await _context.StudentRecords.AnyAsync(s => s.EnrollmentNumber == request.EnrollmentNumber);
            if (enrollmentExists)
            {
                return BadRequest(new { message = "Enrollment number already exists" });
            }

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var passwordHash = HashPassword(request.Password);
                var user = new User
                {
                    Username = request.Username,
                    Email = request.Email,
                    PasswordHash = passwordHash,
                    Role = UserRole.Student,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                var studentRecord = new StudentRecord
                {
                    UserId = user.Id,
                    EnrollmentNumber = request.EnrollmentNumber,
                    DateOfBirth = request.DateOfBirth,
                    PhoneNumber = request.PhoneNumber,
                    EnrolledAt = DateTime.UtcNow
                };

                _context.StudentRecords.Add(studentRecord);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new
                {
                    message = "Student created successfully",
                    student = new
                    {
                        studentId = studentRecord.Id,
                        userId = user.Id,
                        user.Username,
                        user.Email,
                        studentRecord.EnrollmentNumber
                    }
                });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return BadRequest(new { message = "Error creating student: " + ex.Message });
            }
        }

        [HttpGet("students")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _context.StudentRecords
                .Include(s => s.User)
                .Select(s => new StudentDetailDto
                {
                    Id = s.Id,
                    UserId = s.UserId,
                    Username = s.User!.Username,
                    Email = s.User!.Email,
                    EnrollmentNumber = s.EnrollmentNumber,
                    DateOfBirth = s.DateOfBirth,
                    PhoneNumber = s.PhoneNumber,
                    EnrolledAt = s.EnrolledAt
                })
                .ToListAsync();

            return Ok(students);
        }

        [HttpGet("students/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _context.StudentRecords
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
            {
                return NotFound(new { message = "Student not found" });
            }

            var grades = await _context.StudentGrades
                .Where(g => g.StudentId == student.Id)
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
                    StaffName = g.Staff != null ? g.Staff.Username : string.Empty,
                    GradedAt = g.GradedAt
                })
                .ToListAsync();

            var studentDetail = new StudentDetailDto
            {
                Id = student.Id,
                UserId = student.UserId,
                Username = student.User!.Username,
                Email = student.User!.Email,
                EnrollmentNumber = student.EnrollmentNumber,
                DateOfBirth = student.DateOfBirth,
                PhoneNumber = student.PhoneNumber,
                EnrolledAt = student.EnrolledAt,
                Grades = grades
            };

            return Ok(studentDetail);
        }

        [HttpDelete("students/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.StudentRecords.FindAsync(id);
            if (student == null)
            {
                return NotFound(new { message = "Student not found" });
            }

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                _context.StudentRecords.Remove(student);
                if (student.UserId > 0)
                {
                    var user = await _context.Users.FindAsync(student.UserId);
                    if (user != null)
                    {
                        _context.Users.Remove(user);
                    }
                }
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { message = "Student deleted successfully" });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return BadRequest(new { message = "Error deleting student: " + ex.Message });
            }
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

        [HttpPost("staff")]
        public async Task<IActionResult> CreateStaff([FromBody] CreateStaffRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Email))
            {
                return BadRequest(new { message = "Username and Email are required" });
            }

            var userExists = await _context.Users.AnyAsync(u => u.Username == request.Username || u.Email == request.Email);
            if (userExists)
            {
                return BadRequest(new { message = "Username or email already exists" });
            }

            try
            {
                var passwordHash = HashPassword(request.Password);
                var user = new User
                {
                    Username = request.Username,
                    Email = request.Email,
                    PasswordHash = passwordHash,
                    Role = UserRole.Staff,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    message = "Staff member created successfully",
                    staff = new
                    {
                        user.Id,
                        user.Username,
                        user.Email,
                        user.Role
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error creating staff: " + ex.Message });
            }
        }

        [HttpGet("staff")]
        public async Task<IActionResult> GetAllStaff()
        {
            var staff = await _context.Users
                .Where(u => u.Role == UserRole.Staff)
                .Select(u => new StaffDetailDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    Role = u.Role.ToString(),
                    CreatedAt = u.CreatedAt,
                    GradesAssigned = _context.StudentGrades.Count(g => g.StaffId == u.Id)
                })
                .ToListAsync();

            return Ok(staff);
        }

        [HttpGet("staff/{id}")]
        public async Task<IActionResult> GetStaffById(int id)
        {
            var staff = await _context.Users
                .Where(u => u.Id == id && u.Role == UserRole.Staff)
                .Select(u => new StaffDetailDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    Role = u.Role.ToString(),
                    CreatedAt = u.CreatedAt,
                    GradesAssigned = _context.StudentGrades.Count(g => g.StaffId == u.Id)
                })
                .FirstOrDefaultAsync();

            if (staff == null)
            {
                return NotFound(new { message = "Staff member not found" });
            }

            return Ok(staff);
        }

        [HttpDelete("staff/{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var staff = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id && u.Role == UserRole.Staff);

            if (staff == null)
            {
                return NotFound(new { message = "Staff member not found" });
            }

            _context.Users.Remove(staff);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Staff member deleted successfully" });
        }

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
