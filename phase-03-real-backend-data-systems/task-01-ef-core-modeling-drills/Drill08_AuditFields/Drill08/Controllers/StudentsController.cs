using Drill08.DTOs;
using Drill08.Services;
using Microsoft.AspNetCore.Mvc;

namespace Drill08.Controllers
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
        public IActionResult GetStudents()
        {
            var students = service.GetAllStudents();
            return Ok(students);
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