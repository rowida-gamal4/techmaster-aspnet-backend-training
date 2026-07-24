using Microsoft.AspNetCore.Mvc;
using TrainingCenter.DTOs;
using TrainingCenter.Services;
using TrainingCenter.Services.IServices;

namespace TrainingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TracksController : ControllerBase
    {
        private readonly ITracksService service;
        private readonly IEnrollmentService enrollmentService;

        public TracksController(ITracksService service,  IEnrollmentService enrollmentService)
        {
            this.service = service;
            this.enrollmentService = enrollmentService;
        }

        [HttpGet]
        public IActionResult GetTracks(string? keyword, int? level, string? status, int? instructorId)
        {
            var result = service.GetAllTracks(keyword, level, status, instructorId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetTrack(int id)
        {
            var result = service.GetTrackById(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateTrack(CreateTrackRequest request)
        {
            var result = service.CreateTrack(request);

            if (!result.Success)
                return BadRequest(result);

            return Created("", result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTrack(int id, UpdateTrackRequest request)
        {
            var result = service.UpdateTrack(id, request);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTrack(int id)
        {
            var result = service.DeleteTrack(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}/students")]
        public IActionResult GetTrackStudents(int id)
        {
            var result = enrollmentService.GetTrackStudents(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }
    }
}