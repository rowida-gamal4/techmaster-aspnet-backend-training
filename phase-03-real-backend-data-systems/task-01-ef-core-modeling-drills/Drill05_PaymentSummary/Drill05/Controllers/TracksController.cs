using Drill05.Services;
using Microsoft.AspNetCore.Mvc;
namespace Drill05.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TracksController : ControllerBase
    {
        private readonly ITracksService service;

        public TracksController(ITracksService service)
        {
            this.service = service;
        }
        [HttpGet("{id}/students")]
        public IActionResult GetTrackWithStudent(int id)
        {
            var result = service.GetTrackWithStudents(id);
            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}