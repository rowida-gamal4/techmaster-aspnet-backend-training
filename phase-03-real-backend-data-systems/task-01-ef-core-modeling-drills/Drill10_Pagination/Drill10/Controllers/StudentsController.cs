using Drill10.DTOs;
using Drill10.Services;
using Microsoft.AspNetCore.Mvc;

namespace Drill10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService service;

        public StudentsController(IStudentService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult GetStudents(int pageNumber = 1, int pageSize = 5)
        {
            if (pageNumber <= 0)
                return BadRequest("Page Number must be > 0.");

            if (pageSize < 1 || pageSize > 50)
                return BadRequest("pageSize must be between 1 and 50.");

            var result = service.GetStudents(pageNumber, pageSize);

            return Ok(result);
        }
        [HttpGet("deleted")]
        public IActionResult GetStudentsIncludingDeleted()
        {
            var students = service.GetAllStudentsIncludingDeleted();
            return Ok(students);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var result = service.DeleteStudent(id);

            if (result is null)
                return NotFound();

            return NoContent();
        }
        [HttpGet("{id}/enrollments")]
        public IActionResult GetStudnetWithEnrollments(int id)
        {
            var result = service.GetStudentWithEnrollmentTracks(id);
            if (result is null)
                return NotFound();

            return Ok(result);
        }

       [HttpPost]
        public IActionResult CreateStudent(CreateStudentDto studentDto)
        {
            var student = service.CreateStudent(studentDto);

            return Created("", student);
        }

       [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, UpdateStudentDto studentDto)
        {
            var student = service.UpdateStudent(id, studentDto);

            if (student is null)
                return NotFound();

            return Ok(student);
        }
    }
}