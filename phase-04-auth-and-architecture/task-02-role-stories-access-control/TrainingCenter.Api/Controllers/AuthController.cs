using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingCenter.Common;
using TrainingCenter.DTOs.Auth;
using TrainingCenter.Services.IServices;

namespace TrainingCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await authService.RegisterAsync(request);

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await authService.LoginAsync(request);
            if (!result.Success)
                return HandleError(result);

            return Ok(result);

        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var claimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(claimUserId, out var userId))
            {
                return Unauthorized();
            }

            var result = await authService.GetCurrentUser(userId);

            if (!result.Success)
                return HandleError(result);

            return Ok(result);
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
        {
            var claimUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(claimUserId, out var userId))
            {
                return Unauthorized();
            }

            var result = await authService.ChangePasswordAsync(userId, request);

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