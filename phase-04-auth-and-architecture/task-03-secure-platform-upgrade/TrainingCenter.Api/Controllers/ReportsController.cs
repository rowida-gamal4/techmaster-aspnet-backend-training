using Microsoft.AspNetCore.Mvc;
using TrainingCenter.Services.IServices;
using TrainingCenter.Common;
using Microsoft.AspNetCore.Authorization;

namespace TrainingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService service;
        public ReportsController(IReportService service)
        {
            this.service = service;
        }


        [HttpGet("tracks-with-available-seats")]
        [Authorize(Roles = "Admin,Instructor")]
        public IActionResult GetAvailableTracks()
        {
            var result = service.GetAvailableTracks();
            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [HttpGet("unpaid-enrollments")]
        [Authorize(Roles = "Admin,Instructor")]
        public IActionResult GetUnpaidEnrollments()
        {
            var result = service.GetUnpaidEnrollments();
            if (!result.Success)
                return HandleError(result);

            return Ok(result);

        }


        [HttpGet("revenue-summary")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetRevenueSummary()
        {
            var result = service.GetRevenueSummary();
            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }


        [HttpGet("revenue-by-track")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetRevenueByTrack()
        {
            var result = service.GetRevenueByTrack();
            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }


        [HttpGet("top-tracks")]
        [Authorize(Roles = "Admin,Instructor")]
        public IActionResult GetTopTracks()
        {
            var result = service.GetTopTracks();

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [HttpGet("instructor-workload")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetInstructorWorkload()
        {
            var result = service.GetInstructorWorkload();
            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [HttpGet("students-without-payments")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetStudentsWithoutPayments()
        {
            var result = service.GetStudentsWithoutPayments();
            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }


        [HttpGet("dashboard-summary")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetDashboardSummary()
        {
            var result = service.GetDashboardSummary();
            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [HttpGet("track-capacity")]
        [Authorize(Roles = "Admin,Instructor")]
        public IActionResult GetTrackCapacity()
        {
            var result = service.GetTrackCapacity();
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
                ErrorType.Validation => BadRequest(result),
                _ => BadRequest(result)
            };
        }
    }
}