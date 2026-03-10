using Microsoft.EntityFrameworkCore;
using StudentPortalDb.Models;

namespace StudentPortalDb.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentPortalDbContext _db;

        public StudentRepository(StudentPortalDbContext db)
        {
            _db = db;
        }

        public async Task<List<Student>> GetAllAsync(string q = null)
        {
            var query = _db.Students.AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                q = q.Trim().ToLower();
                query = query.Where(s =>
                    s.FullName.ToLower().Contains(q) ||
                    s.Email.ToLower().Contains(q));
            }

            return await query
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _db.Students.FirstOrDefaultAsync(s => s.StudentId == id);
        }

        public async Task AddAsync(Student student)
        {
            await _db.Students.AddAsync(student);
            await SaveAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _db.Students.Update(student);
            await SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _db.Students.FindAsync(id);

            if (student != null)
            {
                _db.Students.Remove(student);
                await SaveAsync();
            }
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            email = email.Trim().ToLower();

            return await _db.Students
                .AnyAsync(s => s.Email.ToLower() == email);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _db.Students
                .AnyAsync(s => s.StudentId == id);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}