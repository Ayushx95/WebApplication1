using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public interface IAttendanceRepository
    {
        Task AddAttendanceAsync(Attendance attendance);

        Task<bool> DeleteAttendanceAsync(int id);

        Task<bool> UpdateAttendanceAsync(Attendance attendance);

        Task<Attendance?> GetAttendanceAsync(int id);

        Task<List<Attendance>> GetAllAttendancesAsync();

        Task<List<Attendance>> GetAttendancesForStudentAsync(int studentId);
    }
}
