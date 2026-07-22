using Drill04.Services;
using Microsoft.AspNetCore.Mvc;

namespace Drill04.Controllers
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