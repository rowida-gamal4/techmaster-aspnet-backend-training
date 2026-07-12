using Microsoft.AspNetCore.Mvc;
//Drill 13
namespace ApiRoutingDrills.Controllers;

[ApiController]
[Route("api/request-info")]
public class RequestInfoController : ControllerBase
{
    [HttpGet]
    public IActionResult GetRequestInfo()
    {
        var studentName = Request.Headers["X-Student-Name"].FirstOrDefault();

        if (string.IsNullOrWhiteSpace(studentName))
        {
            return BadRequest(new
            {
                message = "X-Student-Name header is required."
            });
        }

        return Ok(new
        {
            studentName,
            requestPath = Request.Path
        });
    }
}