using Microsoft.AspNetCore.Mvc;
using TrainingCenter.DTOs;
using TrainingCenter.Services.IServices;

namespace TrainingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService service;

        public InstructorsController(IInstructorService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetInstructors()
        {
            var result = service.GetAllInstructors();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetInstructorById(int id)
        {
            var result = service.GetInstructorById(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("{id}/tracks")]
        public IActionResult GetInstructorTracks(int id)
        {
            var result = service.GetInstructorTracks(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }


        [HttpPost]
        public IActionResult CreateInstructor(CreateInstructorRequest request)
        {
            var result = service.CreateInstructor(request);

            if (!result.Success)
                return BadRequest(result);

            return Created("",result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInstructor(int id, UpdateInstructorRequest request)
        {
            var result = service.UpdateInstructor(id, request);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInstructor(int id)
        {
            var result = service.DeleteInstructor(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }
    }
}