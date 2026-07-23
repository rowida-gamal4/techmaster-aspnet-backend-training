using Drill06.Services;
using Microsoft.AspNetCore.Mvc;

namespace Drill06.Controllers
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
        [HttpGet("{id}/enrollments")]
        public IActionResult GetStudnetWithEnrollments(int id)
        {
            var result = service.GetStudentWithEnrollmentTracks(id);
            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}