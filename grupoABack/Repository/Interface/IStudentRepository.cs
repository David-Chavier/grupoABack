using grupoABack.DTOs.StudentDTO;
using grupoABack.Models;

namespace grupoABack.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByRAAsync(string academicRegistration);
        Task<Student> AddAsync(Student student);
        Task<Student> UpdateAsync(Student student);
        Task<bool> DeleteAsync(string academicRegistration);
    }
}