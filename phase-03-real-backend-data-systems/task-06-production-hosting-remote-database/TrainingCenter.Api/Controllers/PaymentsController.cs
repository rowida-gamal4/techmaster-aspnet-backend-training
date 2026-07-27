using Microsoft.AspNetCore.Mvc;
using TrainingCenter.DTOs;


namespace TrainingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService service;

        public PaymentsController(IPaymentService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetPayments( DateTime? fromDate, DateTime? toDate, string? status)
        {
            var result = service.GetAllPayments(fromDate, toDate, status);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreatePayment(CreatePaymentRequest request)
        {
            var result = service.CreatePayment(request);

            if (!result.Success)
                return BadRequest(result);

            return Created ("",result);
        }

       

        [HttpPut("{id}/status")]
        public IActionResult UpdatePaymentStatus(int id, UpdatePaymentStatusRequest request)
        {
            var result = service.UpdatePaymentStatus(id, request);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }
    }
}