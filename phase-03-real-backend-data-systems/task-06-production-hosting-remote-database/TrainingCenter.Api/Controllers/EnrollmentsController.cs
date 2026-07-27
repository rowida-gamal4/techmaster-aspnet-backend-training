using Microsoft.AspNetCore.Mvc;
using TrainingCenter.DTOs;
using TrainingCenter.Services.IServices;

namespace TrainingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService service;
        private readonly IPaymentService paymentService;

        public EnrollmentsController(IEnrollmentService service, IPaymentService paymentService)
        {
            this.service = service;
            this.paymentService = paymentService;
        }

       
        [HttpGet]
        public IActionResult GetEnrollments(  string? status, int? trackId,int? studentId, string? paymentStatus)
        {
            var result = service.GetAllEnrollments(status, trackId, studentId, paymentStatus);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetEnrollment(int id)
        {
            var result = service.GetEnrollmentById(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateEnrollment(CreateEnrollmentRequest request)
        {
            var result = service.CreateEnrollment(request);

            if (!result.Success)
                return BadRequest(result);

            return Created("",result);
        }

        [HttpPut("{id}/status")]
        public IActionResult UpdateEnrollmentStatus(int id, UpdateEnrollmentStatusRequest request)
        {
            var result = service.UpdateEnrollmentStatus(id, request);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}/payments")]
        public IActionResult GetEnrollmentPayments(int id)
        {
            var result = paymentService.GetEnrollmentPayments(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }
    }
}