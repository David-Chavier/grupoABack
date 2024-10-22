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
                throw new Exception("", ex);
            }
        }

        public async Task<Student> GetByRAAsync(string academicRegistration)
        {
            return await _context.Students.FindAsync(academicRegistration);
        }

        public async Task<Student> AddAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> DeleteAsync(string academicRegistration)
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
    }
}
