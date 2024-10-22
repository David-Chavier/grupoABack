using grupoABack.DTOs.StudentDTO;
using grupoABack.Models;
using grupoABack.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace grupoABack.BusinessRules.StudentRules
{
    public class StudentBusiness : IStudentBusiness
    {
        private readonly IStudentRepository _studentRepository;

        public StudentBusiness(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student> GetStudentByIdAsync(Guid id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<bool> CreateStudentAsync(CreateStudentDTO createStudentDTO)
        {
            var student = new Student
            {
                Name = createStudentDTO.Name,
                CPF = createStudentDTO.CPF,
                AcademicRegistration = createStudentDTO.AcademicRegistration,
                Email = createStudentDTO.Email
            };

            var resultStudent = await _studentRepository.AddAsync(student);

            if (resultStudent == null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateStudentAsync(UpdateStudentDTO updateStudentDTO)
        {
            var existingStudent = await _studentRepository.GetByIdAsync(updateStudentDTO.Id);
            if (existingStudent == null)
            {
                return false;
            }

            existingStudent.Name = updateStudentDTO.Name;
            existingStudent.CPF = updateStudentDTO.CPF;

            await _studentRepository.UpdateAsync(existingStudent);

            return true;
        }

        public async Task<bool> DeleteStudentAsync(Guid id)
        {
            return await _studentRepository.DeleteAsync(id);
        }
    }
}
