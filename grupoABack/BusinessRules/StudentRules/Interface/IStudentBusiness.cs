using grupoABack.DTOs.StudentDTO;
using grupoABack.Models;

namespace grupoABack.BusinessRules.StudentRules
{
    public interface IStudentBusiness
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<bool> CreateStudentAsync(CreateStudentDTO createStudentDTO);
        Task<bool> UpdateStudentAsync(UpdateStudentDTO updateStudentDTO);
        Task<bool> DeleteStudentAsync(Guid id);
    }
}
