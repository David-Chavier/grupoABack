using grupoABack.BusinessRules.StudentRules;
using grupoABack.DTOs.StudentDTO;
using grupoABack.Models;
using Microsoft.AspNetCore.Mvc;

namespace grupoABack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentBusiness _studentBusiness;

        public StudentController(IStudentBusiness studentBusiness)
        {
            _studentBusiness = studentBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var result = await _studentBusiness.GetStudentsAsync();
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }

        [HttpGet("{academicRegistration}")]
        public async Task<ActionResult<Student>> GetStudentById(string academicRegistration)
        {
            var result = await _studentBusiness.GetStudentByIdAsync(academicRegistration);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<ActionResult> CreateStudent(StudentDTO studentDTO)
        {
            var result = await _studentBusiness.CreateStudentAsync(studentDTO);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStudent(StudentDTO studentDTO)
        {
            var result = await _studentBusiness.UpdateStudentAsync(studentDTO);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok();
        }

        [HttpDelete("{academicRegistration}")]
        public async Task<ActionResult> DeleteStudent(string academicRegistration)
        {
            var result = await _studentBusiness.DeleteStudentAsync(academicRegistration);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return NoContent();
        }
    }
}
