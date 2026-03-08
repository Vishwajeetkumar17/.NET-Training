using StudentPortalDb.Models;
using StudentPortalDb.Repositories;

namespace StudentPortalDb.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Student>> SearchAsync(string q = null)
            => await _repo.GetAllAsync(q);

        public async Task<Student> GetByIdAsync(int id)
            => await _repo.GetByIdAsync(id);

        public async Task AddAsync(Student student)
            => await _repo.AddAsync(student);

        public async Task UpdateAsync(Student student)
            => await _repo.UpdateAsync(student);

        public async Task DeleteAsync(int id)
            => await _repo.DeleteAsync(id);

        public async Task<bool> ExistsAsync(int id)
            => await _repo.ExistsAsync(id);

        public async Task<bool> EmailExistsAsync(string email)
            => await _repo.EmailExistsAsync(email);
    }
}