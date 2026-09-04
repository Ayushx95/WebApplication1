using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{

    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _db;

        public StudentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddStudentAsync(Student student)
        {
            if (student == null) return;
            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var s = await _db.Students.FindAsync(id);
            if (s == null) return false;
            _db.Students.Remove(s);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            if (student == null) return false;
            var existing = await _db.Students.FindAsync(student.Id);
            if (existing == null) return false;
            existing.Name = student.Name;
            existing.Email = student.Email;
            existing.Age = student.Age;
            existing.EnrollmentDate = student.EnrollmentDate;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Student?> GetStudentAsync(int id)
        {
            return await _db.Students.FindAsync(id);
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions
                .ToListAsync(_db.Students);
        }
    }
}
