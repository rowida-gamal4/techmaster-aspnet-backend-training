using Microsoft.AspNetCore.Mvc;
using TrainingCenter.Services.IServices;

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

        [HttpGet("dashboard-summary")]
        public IActionResult GetDashboardSummary()
        {
            var result = service.GetDashboardSummary();
            return Ok(result);
        }

        [HttpGet("unpaid-enrollments")]
        public IActionResult GetUnpaidEnrollments()
        {
            var result = service.GetUnpaidEnrollments();
            return Ok(result);
        }

        [HttpGet("track-capacity")]
        public IActionResult GetTrackCapacity()
        {
            var result = service.GetTrackCapacity();
            return Ok(result);
        }

        [HttpGet("revenue-summary")]
        public IActionResult GetRevenueSummary()
        {
            var result = service.GetRevenueSummary();
            return Ok(result);
        }

        [HttpGet("revenue-by-track")]
        public IActionResult GetRevenueByTrack()
        {
            var result = service.GetRevenueByTrack();
            return Ok(result);
        }
    }
}