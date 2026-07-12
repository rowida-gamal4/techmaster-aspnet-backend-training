using ApiRoutingDrills.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiRoutingDrills.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConverterController : ControllerBase
{
    private readonly ConverterService service;

    public ConverterController(ConverterService service )
    {
        this.service = service;
    }

    [HttpGet("celsius-to-fahrenheit")]
    public IActionResult Convert([FromQuery] decimal value)
    {
        decimal fahrenheit = service.ConvertCelsiusToFahrenheit(value);
        return Ok(new
        {
            Celsius = value ,
            Fahrenheit = fahrenheit ,
            FormulaUsed = "(celsius * 9 / 5) + 32"
        });
    }
}