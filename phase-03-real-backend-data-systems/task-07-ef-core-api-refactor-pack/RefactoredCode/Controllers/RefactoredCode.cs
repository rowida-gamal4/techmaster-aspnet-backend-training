using Microsoft.AspNetCore.Mvc;
using RefactoredCode.DTOs;
using RefactoredCode.Services;

namespace RefactoredCode.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetAll(
            int pageNumber = 1,
            int pageSize = 10)
        {
            var result = await service.GetAllAsync(pageNumber, pageSize);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEnrollmentRequest request)
        {
            var result = await service.CreateAsync(request);

            if (result == null)
                return BadRequest("Failed to create enrollment.");

            return Created("", result);
        }

        [HttpPost("pay")]
        public async Task<IActionResult> Pay(CreatePaymentRequest request)
        {
            var result = await service.CreatePaymentAsync(request);

            if (result == null)
                return BadRequest("Payment failed.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}