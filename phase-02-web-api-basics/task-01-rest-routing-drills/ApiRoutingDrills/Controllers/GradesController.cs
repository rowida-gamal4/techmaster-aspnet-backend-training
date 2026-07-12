using Microsoft.AspNetCore.Mvc;

//Drill05
namespace ApiRoutingDrills.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradesController : ControllerBase
{
    [HttpGet("calculate")]
    public IActionResult grades([FromQuery] int score)
    {
        if (score <0 || score >100)
         return BadRequest (new { error = "Score must be between 0 and 100" }) ;
        else
        {
             string Grade;
            if (score >= 90)
                Grade = "A";
            else if (score >= 80)
                Grade = "B";
            else if (score >= 70)
                Grade = "C";
            else if (score >= 60)
                Grade = "D";
            else
                Grade = "F"; 
        return Ok(new
        {
            Score = score ,
            Grade = Grade ,
            Passed = score >=60 ? "true" :"false"
        }); 
        }      
    }
}