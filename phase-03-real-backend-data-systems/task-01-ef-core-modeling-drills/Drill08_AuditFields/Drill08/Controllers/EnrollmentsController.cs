using Drill08.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Drill08.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService service;

        public EnrollmentsController(IEnrollmentService service)
        {
            this.service = service;
        }
        [HttpGet("{id}/payment-summary")]
        public IActionResult GetEnrollmetsWithPaymentSummary(int id)
        {
            var result = service.GetPaymentSummary(id);
            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}