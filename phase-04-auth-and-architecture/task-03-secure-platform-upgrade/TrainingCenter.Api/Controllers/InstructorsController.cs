using Microsoft.AspNetCore.Mvc;
using TrainingCenter.DTOs;
using TrainingCenter.Services.IServices;
using TrainingCenter.Common;
using Microsoft.AspNetCore.Authorization;

namespace TrainingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService service;
        private readonly IEnrollmentService enrollmentService;
        private readonly IReportService reportService;

        public InstructorsController(IInstructorService service, IEnrollmentService enrollmentService , IReportService reportService)
        {
            this.service = service;
            this.enrollmentService = enrollmentService;
            this.reportService = reportService;
        }

        #region Task03 Special Methods

        [HttpGet("my-tracks")]
        [Authorize(Roles = "Instructor")]
        public IActionResult GetMyTracks()
        {
            var result = service.GetMyTracks();

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [HttpGet("tracks/{id}/students")]
        [Authorize(Roles = "Instructor")]
        public IActionResult GetTrackStudents(int id)
        {
            var result = enrollmentService.GetTrackStudents(id);

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [HttpPost("tracks/{id}/sessions")]
        [Authorize(Roles = "Instructor")]
        public IActionResult CreateSession(
            int id,
            CreateTrackSessionRequest request)
        {
            var result = service.CreateSession(id, request);

            if (!result.Success)
                return HandleError(result);

            return Created("", result);
        }

        [HttpPut("sessions/{id}")]
        [Authorize(Roles = "Instructor")]
        public IActionResult UpdateSession(
            int id,
            UpdateTrackSessionRequest request)
        {
            var result = service.UpdateSession(id, request);

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }
        
        [HttpGet("tracks/{id}/progress")]
        [Authorize(Roles = "Instructor")]
        public IActionResult GetTrackProgress(int id)
        {
            var result = reportService.GetTrackProgress(id);

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }
        #endregion

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetInstructors()
        {
            var result = service.GetAllInstructors();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Instructor")]
        public IActionResult GetInstructorById(int id)
        {
            var result = service.GetInstructorById(id);

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [HttpGet("{id}/tracks")]
        [Authorize(Roles = "Admin,Instructor")]
        public IActionResult GetInstructorTracks(int id)
        {
            var result = service.GetInstructorTracks(id);

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateInstructor(CreateInstructorRequest request)
        {
            var result = service.CreateInstructor(request);

            if (!result.Success)
                return HandleError(result);

            return Created("", result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Instructor")]
        public IActionResult UpdateInstructor(int id, UpdateInstructorRequest request)
        {
            var result = service.UpdateInstructor(id, request);

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteInstructor(int id)
        {
            var result = service.DeleteInstructor(id);

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }
        private IActionResult HandleError<T>(GeneralResponseDto<T> result)
        {
            return result.ErrorType switch
            {
                ErrorType.NotFound => NotFound(result),
                ErrorType.Conflict => Conflict(result),
                ErrorType.BadRequest => BadRequest(result),
                ErrorType.Forbidden => StatusCode(403, result),
                _ => BadRequest(result)
            };
        }
    }
}