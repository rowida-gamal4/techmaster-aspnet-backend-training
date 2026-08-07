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
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService service;
        private readonly IEnrollmentService enrollmentService;

        public StudentsController(IStudentService service, IEnrollmentService enrollmentService)
        {
            this.service = service;
            this.enrollmentService = enrollmentService;
        }

        #region Task03 Special Methods

        [HttpGet("me")]
        [Authorize(Roles = "Student")]
        public IActionResult GetMyProfile()
        {
            var result = service.GetMyProfile();

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [HttpGet("my-enrollments")]
        [Authorize(Roles = "Student")]
        public IActionResult GetMyEnrollments()
        {
            var result = service.GetMyEnrollments();

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [HttpGet("my-payments")]
        [Authorize(Roles = "Student")]
        public IActionResult GetMyPayments()
        {
            var result = service.GetMyPayments();

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [HttpPost("enrollment-requests")]
        [Authorize(Roles = "Student")]

        public IActionResult CreateEnrollmentRequest(int trainingTrackId)
        {
            var result = service.CreateStudentEnrollmentRequest(trainingTrackId);

            if (!result.Success)
                return HandleError(result);

            return Created("", result);
        }
        [HttpPut("me")]
        [Authorize(Roles = "Student")]

        public IActionResult UpdateMyProfile(UpdateStudentMe request)
        {
            var result = service.UpdateMyProfile(request);

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        #endregion



        [HttpGet]
        [Authorize(Roles = "Admin,Instructor")]
        public IActionResult GetStudents(string? search, bool? isActive, bool includeDeleted = false, int pageNumber = 1, int pageSize = 10)
        {
            var result = service.GetAllStudents(search, isActive, includeDeleted, pageNumber, pageSize);

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Instructor,Student")]
        public IActionResult GetStudentById(int id)
        {
            var result = service.GetStudentById(id);

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateStudent(CreateStudentRequest request)
        {
            var result = service.CreateStudent(request);

            if (!result.Success)
                return HandleError(result);

            return Created("", result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateStudent(int id, UpdateStudentRequest request)
        {
            var result = service.UpdateStudent(id, request);

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteStudent(int id)
        {
            var result = service.DeleteStudent(id);

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }



        [HttpGet("{id}/enrollments")]
        [Authorize(Roles = "Admin,Student")]
        public IActionResult GetStudentEnrollmentHistory(int id)
        {
            var result = enrollmentService.GetStudentEnrollmentHistory(id);

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
                ErrorType.Forbidden => StatusCode(403, result),
                _ => BadRequest(result)
            };
        }
    }
}