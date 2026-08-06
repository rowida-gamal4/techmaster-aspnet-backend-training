using Microsoft.AspNetCore.Mvc;
using TrainingCenter.DTOs;
using TrainingCenter.Services.IServices;
using TrainingCenter.Common;
using Microsoft.AspNetCore.Authorization;

namespace TrainingCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService service;

        public InstructorsController(IInstructorService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetInstructors()
        {
            var result = service.GetAllInstructors();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Instructor")]
        public IActionResult GetInstructorById(int id)
        {
            var result = service.GetInstructorById(id);

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [HttpGet("{id}/tracks")]
        [Authorize(Roles = "Admin,Instructor")]
        public IActionResult GetInstructorTracks(int id)
        {
            var result = service.GetInstructorTracks(id);

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateInstructor(CreateInstructorRequest request)
        {
            var result = service.CreateInstructor(request);

            if (!result.Success)
                return HandleError(result);

            return Created("", result);
        }

        [HttpPut("{id}")]
       [Authorize(Roles = "Admin,Instructor")]
        public IActionResult UpdateInstructor(int id, UpdateInstructorRequest request)
        {
            var result = service.UpdateInstructor(id, request);

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteInstructor(int id)
        {
            var result = service.DeleteInstructor(id);

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