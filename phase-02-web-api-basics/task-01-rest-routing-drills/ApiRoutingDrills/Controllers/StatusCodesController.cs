//Drill 14
using ApiRoutingDrills.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ApiRoutingDrills.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusCodesController : ControllerBase
{
    private static readonly List<string> Names = new() { "ali", "arwa", "ahmed" };


    //Ok
    [HttpGet("{name}")]
    public IActionResult GetName(string name)
    {
        var result = Names.FirstOrDefault(n => n.Equals(name, StringComparison.OrdinalIgnoreCase));

        //Not found
        if (result == null)
        {
            return NotFound(new
            {
                message = "Name not found."
            });
        }
        //Ok
        return Ok(new
        {
            name = result
        });

    }
    //Created
    [HttpPost]
    public IActionResult CreateName([FromBody] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return BadRequest(new
            {
                message = "Name is required."
            });
        }

        Names.Add(name);

        return Created(string.Empty, new
        {
            name
        });
    }

    //No Content
    [HttpDelete("{name}")]
    public IActionResult DeleteName(string name)
    {
        var result = Names.FirstOrDefault(n => n.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (result == null)
        {
            return NotFound(new
            {
                message = "Name not found."
            });
        }

        Names.Remove(result);

        return NoContent();
    }
}

