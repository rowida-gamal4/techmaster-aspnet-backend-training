using Microsoft.AspNetCore.Mvc;
using TrainingCenter.DTOs;
using TrainingCenter.Services.IServices;

namespace TrainingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService service;
        private readonly IEnrollmentService enrollmentService;

        public StudentsController(IStudentService service , IEnrollmentService enrollmentService)
        {
            this.service = service;
            this.enrollmentService = enrollmentService;
        }

        
        [HttpGet]
        public IActionResult GetStudents(string? search,bool? isActive,int pageNumber = 1,int pageSize = 10)
        {
            var result = service.GetAllStudents(search, isActive, pageNumber, pageSize);
            return Ok(result);
        }

       
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var result = service.GetStudentById(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

       
        [HttpPost]
        public IActionResult CreateStudent(CreateStudentRequest request)
        {
            var result = service.CreateStudent(request);

            if (!result.Success)
                return BadRequest(result);

            return Created("",result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, UpdateStudentRequest request)
        {
            var result = service.UpdateStudent(id, request);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var result = service.DeleteStudent(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("{id}/enrollments")]
        public IActionResult GetStudentEnrollmentHistory(int id)
        {
            var result = enrollmentService.GetStudentEnrollmentHistory(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }
    }
}