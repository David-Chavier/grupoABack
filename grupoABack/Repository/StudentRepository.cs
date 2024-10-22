using grupoABack.Data;
using grupoABack.Models;
using Microsoft.EntityFrameworkCore;

namespace grupoABack.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _context;

        public StudentRepository(StudentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            try
            {
                return await _context.Students.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar todos os estudantes", ex);
            }
        }

        public async Task<Student> GetByRAAsync(string academicRegistration)
        {
            try
            {
                return await _context.Students.FindAsync(academicRegistration);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar estudante pelo registro acadêmico", ex);
            }
        }

        public async Task<Student> AddAsync(Student student)
        {
            try
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return student;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar estudante", ex);
            }
        }

        public async Task<Student> UpdateAsync(Student student)
        {
            try
            {
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return student;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar estudante", ex);
            }
        }

        public async Task<bool> DeleteAsync(string academicRegistration)
        {
            try
            {
                var student = await _context.Students.FindAsync(academicRegistration);
                if (student == null)
                {
                    return false;
                }

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar estudante", ex);
            }
        }
    }
}
