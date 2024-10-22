using grupoABack.DTOs.StudentDTO;
using grupoABack.Models;

namespace grupoABack.BusinessRules.StudentRules
{
    public interface IStudentBusiness
    {
        Task<Result> GetStudentsAsync();
        Task<Result> GetStudentByIdAsync(string academicRegistration);
        Task<Result> CreateStudentAsync(StudentDTO studentDTO);
        Task<Result> UpdateStudentAsync(StudentDTO studentDTO);
        Task<Result> DeleteStudentAsync(string academicRegistration);
    }
}
