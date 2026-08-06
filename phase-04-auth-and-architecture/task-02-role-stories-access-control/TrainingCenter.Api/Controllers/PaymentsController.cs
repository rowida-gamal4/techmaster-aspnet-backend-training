using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingCenter.Common;
using TrainingCenter.DTOs;


namespace TrainingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService service;

        public PaymentsController(IPaymentService service)
        {
            this.service = service;
        }

       
        [HttpGet]
        [Authorize(Roles = "Admin,Student")]
        public IActionResult GetPayments( DateTime? fromDate, DateTime? toDate, string? status)
        {
            var result = service.GetAllPayments(fromDate, toDate, status);

           if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreatePayment(CreatePaymentRequest request)
        {
            var result = service.CreatePayment(request);

            if (!result.Success)
                return HandleError(result);

            return Created ("",result);
        }

       

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdatePaymentStatus(int id, UpdatePaymentStatusRequest request)
        {
            var result = service.UpdatePaymentStatus(id, request);

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