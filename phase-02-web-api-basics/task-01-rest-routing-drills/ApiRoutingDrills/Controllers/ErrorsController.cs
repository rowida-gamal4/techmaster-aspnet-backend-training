//Drill15
using Microsoft.AspNetCore.Mvc;
namespace ApiRoutingDrills.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ErrorsController : ControllerBase
{


    List<string> names = new() { "ali", "arwa", "ahmed" };

    [HttpGet("demo")]
    public IActionResult ErrorShape([FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return BadRequest(new
            {
                success = false,
                code = 400,
                message = "Invalid request",
                details = new[]
     {
        "Name is required."
    }
            });
        }
        name = name.ToLower();
        if (!names.Contains(name))
        {
            return NotFound(new
            {
                success = false,
                code = 404,
                message = "Not Found",
                details = new[]
    {
        "Name not found."
    }
            });
        }
        else
        {
            return Ok(new
            {
                success = true,
                name
            });
        }


    }
}