using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingCenter.Common;
using TrainingCenter.DTOs;
using TrainingCenter.Services.IServices;

namespace TrainingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService service;
        private readonly IPaymentService paymentService;
        
        public EnrollmentsController(IEnrollmentService service, IPaymentService paymentService )
        {
            this.service = service;
            this.paymentService = paymentService;
           
        }


        [HttpGet]
        [Authorize(Roles = "Admin,Instructor,Student")]
        public IActionResult GetEnrollments(EnrollmentStatus? status, int? trackId, int? studentId, string? paymentStatus)
        {
            var result = service.GetAllEnrollments(status, trackId, studentId, paymentStatus);
            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Instructor,Student")]
        public IActionResult GetEnrollment(int id)
        {
            var result = service.GetEnrollmentById(id);

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Student")]
        public IActionResult CreateEnrollment(CreateEnrollmentRequest request)
        {
            var result = service.CreateEnrollment(request);

            if (!result.Success)
                return HandleError(result);
            return Created("", result);
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateEnrollmentStatus(int id, UpdateEnrollmentStatusRequest request)
        {
            var result = service.UpdateEnrollmentStatus(id, request);

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [HttpGet("{id}/payments")]
        [Authorize(Roles = "Admin,Student")]
        public IActionResult GetEnrollmentPayments(int id)
        {
            var result = paymentService.GetEnrollmentPayments(id);

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
                ErrorType.Forbidden => StatusCode(403,result),
                _ => BadRequest(result)
            };
        }
    }
}