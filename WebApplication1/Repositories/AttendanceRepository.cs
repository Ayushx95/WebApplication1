using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _db;

        public AttendanceRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAttendanceAsync(Attendance attendance)
        {
            if (attendance == null) return;
            await _db.Attendances.AddAsync(attendance);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            var a = await _db.Attendances.FindAsync(id);
            if (a == null) return false;
            _db.Attendances.Remove(a);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAttendanceAsync(Attendance attendance)
        {
            if (attendance == null) return false;
            var existing = await _db.Attendances.FindAsync(attendance.Id);
            if (existing == null) return false;
            existing.Date = attendance.Date;
            existing.Present = attendance.Present;
            existing.Notes = attendance.Notes;
            existing.StudentId = attendance.StudentId;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Attendance?> GetAttendanceAsync(int id)
        {
            return await _db.Attendances.Include(a => a.Student).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Attendance>> GetAllAttendancesAsync()
        {
            return await _db.Attendances.Include(a => a.Student).ToListAsync();
        }

        public async Task<List<Attendance>> GetAttendancesForStudentAsync(int studentId)
        {
            return await _db.Attendances
                .Where(a => a.StudentId == studentId)
                .Include(a => a.Student)
                .ToListAsync();
        }
    }
}
