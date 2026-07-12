using Microsoft.AspNetCore.Mvc;

namespace ApiRoutingDrills.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToolsController : ControllerBase
{
    [HttpGet("echo/{name}")]
    public IActionResult EchoName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return BadRequest(new
            {
                message = "Name cannot be empty or whitespace."
            });
        }
        return Ok(new
        {
            originalName = name,
            message = $"Hello, {name}!"
        });
    }
}