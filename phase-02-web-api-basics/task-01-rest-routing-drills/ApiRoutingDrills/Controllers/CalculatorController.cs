using Microsoft.AspNetCore.Mvc;

namespace ApiRoutingDrills.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculatorController : ControllerBase
{
    [HttpGet("add")]
    public IActionResult Add ([FromQuery] decimal a,[FromQuery] decimal b)
    {
        decimal sum = a + b ;
        return Ok(new
        {
            A = a,
            B = b ,
            Operation = "+",
            Result =  sum
        });
    }
}