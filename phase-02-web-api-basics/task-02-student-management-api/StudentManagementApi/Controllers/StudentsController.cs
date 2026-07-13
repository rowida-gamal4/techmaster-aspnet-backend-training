using Microsoft.AspNetCore.Mvc;
using StudentManagementApi.DTOs;
using StudentManagementApi.Services;

namespace StudentManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        [HttpPost]
        public IActionResult CreateStudent([FromBody] CreateStudentRequest studentRequest)
        {
            var result = studentService.CreateStudent(studentRequest);
            if (result is null)
            {
                return BadRequest(new
                {
                    message = "Email already exists."
                });
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetStudents([FromQuery] PagedResultRequest request)
        {
            var result = studentService.GetAllStudents(request);
            if (!result.studentResponses.Any())
            {
                return Ok(new
                {
                    message = "No Students Found.",
                    result
                });
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var result = studentService.GetStudentById(id);
            if (result is null)
            {
                return NotFound(new
                {
                    message = "No Student Found with this id.",
                });
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] UpdateStudentRequest updateStudentRequest)
        {
            var result = studentService.UpdateStudent(id, updateStudentRequest);
            if (result is null)
            {
                return NotFound(new
                {
                    message = "ID is missing or Email exists"
                });
            }

            return Ok(result);
        }

        [HttpPatch("{id}/status")]
        public IActionResult UpdateStudent(int id, [FromBody] UpdateStudentStatusRequest request)
        {
            var result = studentService.UpdateStudentStatus(id, request.IsActive);
            if (result is null)
            {
                return NotFound(new
                {
                    message = "Student not found"
                });
            }

            return Ok(new
            {
                message = "Student status updated successfully.",
                IsActive = result
            });
        }

        [HttpGet("stats")]
        public IActionResult GetStats()
        {
            var result = studentService.StudentStats();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var result = studentService.DeleteStudent(id);
            if (result is null)
            {
                return NotFound(new
                {
                    message = "Student not found"
                });
            }

            return Ok(new
            {
                message = "Student deleted successfully.",

            });
        }
    }
}

