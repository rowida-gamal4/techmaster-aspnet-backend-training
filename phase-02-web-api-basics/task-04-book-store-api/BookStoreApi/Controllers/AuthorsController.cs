using BookStoreApi.DTOs;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService service;

    public AuthorsController(IAuthorService service)
    {
        this.service = service;
    }

    [HttpGet]
    public IActionResult GetAllAuthors()
    {
        var result = service.GetAllAuthors();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult CreateAuthor([FromBody] CreateAuthorRequest request)
    {
        var result = service.CreateAuthor(request);

        if (!result.Success)
            return BadRequest(result);

        return Created("", result);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
        var result = service.DeleteAuthor(id);

        if (!result.Success)
        {
            if (result.StatusCode == StatusCodes.Status404NotFound)
                return NotFound(result);

            return BadRequest(result);
        }

        return Ok(result);
    }
}