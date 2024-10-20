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
            return Ok(await _studentBusiness.GetStudentsAsync());
        }

        [HttpPost]
        public async Task<ActionResult> CreateStudent(CreateStudentDTO createStudentDTO)
        {
            var result = await _studentBusiness.CreateStudentAsync(createStudentDTO);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(UpdateStudentDTO updateStudentDTO)
        {
            var result = await _studentBusiness.UpdateStudentAsync(updateStudentDTO);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(Guid id)
        {
            var result = await _studentBusiness.DeleteStudentAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
