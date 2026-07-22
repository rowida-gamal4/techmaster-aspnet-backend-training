using Drill04.Services;
using Microsoft.AspNetCore.Mvc;

namespace Drill04.Controllers
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
        [HttpGet("{id}/tracks")]
        public IActionResult GetInstractor(int id)
        {
            var result = service.GetInstructorWithTrack(id);
            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}