using Microsoft.AspNetCore.Mvc;
using TrainingCenter.Common;
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

           if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreatePayment(CreatePaymentRequest request)
        {
            var result = service.CreatePayment(request);

            if (!result.Success)
                return HandleError(result);

            return Created ("",result);
        }

       

        [HttpPut("{id}/status")]
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
                _ => BadRequest(result)
            };
        }
    }
}