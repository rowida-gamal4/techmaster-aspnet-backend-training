using Microsoft.AspNetCore.Mvc;

namespace ApiRoutingDrills.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult HealthCheck()
    {
        return Ok(new { status = "Running", service = "TechMaster API", time = DateTime.UtcNow });
    }
}