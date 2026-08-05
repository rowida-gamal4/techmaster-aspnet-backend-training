using Microsoft.AspNetCore.Mvc;
using TrainingCenter.Services.IServices;
using TrainingCenter.Common;

namespace TrainingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService service;
        public ReportsController(IReportService service)
        {
            this.service = service;
        }

        // Query 7
        [HttpGet("tracks-with-available-seats")]
        public IActionResult GetAvailableTracks()
        {
            var result = service.GetAvailableTracks();

            return Ok(result);
        }
        
        //Query 12        
        [HttpGet("unpaid-enrollments")]
        public IActionResult GetUnpaidEnrollments()
        {
            var result = service.GetUnpaidEnrollments();
            return Ok(result);
        }

        //Query 14
        [HttpGet("revenue-summary")]
        public IActionResult GetRevenueSummary()
        {
            var result = service.GetRevenueSummary();
            return Ok(result);
        }

        // Query 15 
        [HttpGet("revenue-by-track")]
        public IActionResult GetRevenueByTrack()
        {
            var result = service.GetRevenueByTrack();
            return Ok(result);
        }

        //Query 16
        [HttpGet("top-tracks")]
        public IActionResult GetTopTracks()
        {
            var result = service.GetTopTracks();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        //Query 17
        [HttpGet("instructor-workload")]
        public IActionResult GetInstructorWorkload()
        {
            var result = service.GetInstructorWorkload();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        // Query 18
        [HttpGet("students-without-payments")]
        public IActionResult GetStudentsWithoutPayments()
        {
            var result = service.GetStudentsWithoutPayments();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        
        // Query 20 - Dashboard Summary
        [HttpGet("dashboard-summary")]
        public IActionResult GetDashboardSummary()
        {
            var result = service.GetDashboardSummary();
            return Ok(result);
        }
        
        [HttpGet("track-capacity")]
        public IActionResult GetTrackCapacity()
        {
            var result = service.GetTrackCapacity();
            return Ok(result);
        }
    }
}