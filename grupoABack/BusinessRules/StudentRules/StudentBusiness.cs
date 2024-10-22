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

        public async Task<Result> GetStudentsAsync()
        {
            var result = await _studentRepository.GetAllAsync();

            return new Result(true, "", result);
        }

        public async Task<Result> GetStudentByIdAsync(string academicRegistration)
        {
            var result = await _studentRepository.GetByRAAsync(academicRegistration);

            return new Result(true, "", result);
        }

        public async Task<Result> CreateStudentAsync(StudentDTO studentDTO)
        {
            var student = await _studentRepository.GetByRAAsync(studentDTO.AcademicRegistration);

            if (student != null)
            {
                return new Result (false, "Já tem um cadastro com esse registro acadêmico" );
            }

            var newStudent = new Student
            {
                Name = studentDTO.Name,
                CPF = studentDTO.CPF,
                AcademicRegistration = studentDTO.AcademicRegistration,
                Email = studentDTO.Email
            };

            var resultStudent = await _studentRepository.AddAsync(newStudent);

            if (resultStudent == null)
            {
                return new Result (false, "Falha ao criar estudante");
            }

            return new Result (true);
        }

        public async Task<Result> UpdateStudentAsync(StudentDTO studentDTO)
        {
            var existingStudent = await _studentRepository.GetByRAAsync(studentDTO.AcademicRegistration);
            if (existingStudent == null)
            {
                return new Result(false, "Registro acadêmico não encontrado");
            }

            existingStudent.Name = studentDTO.Name;
            existingStudent.Email = studentDTO.Email;

            await _studentRepository.UpdateAsync(existingStudent);

            return new Result(true);
        }

        public async Task<Result> DeleteStudentAsync(string academicRegistration)
        {
            var result = await _studentRepository.DeleteAsync(academicRegistration);

            return new Result(result);
        }
    }
}
