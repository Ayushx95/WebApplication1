using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IStudentRepository
    {
        Task AddStudentAsync(Student student);

        Task<bool> DeleteStudentAsync(int id);

        Task<bool> UpdateStudentAsync(Student student);

        Task<Student?> GetStudentAsync(int id);

        Task<List<Student>> GetAllStudentsAsync();
    }
}
