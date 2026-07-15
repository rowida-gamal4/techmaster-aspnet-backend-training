using BookStoreApi.DTOs;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService service;

    public BooksController(IBookService service)
    {
        this.service = service;
    }

    [HttpGet]
    public IActionResult GetAllBooks([FromQuery] SearchAndPagination filter)
    {
        var result = service.GetAllBooks(filter);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetBookById(int id)
    {
        var result = service.GetBookById(id);

        if (!result.Success)
        {
            return NotFound(result);
        }

        return Ok(result);
    }

    [HttpPost]
    public IActionResult CreateBook([FromBody] CreateBookRequest request)
    {
        var result = service.CreateBook(request);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Created("",result);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id , [FromBody] UpdateBookRequest request)
    {
        var result = service.UpdateBook(id , request);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var result = service.DeleteBook(id);

        if (!result.Success)
        {
            return NotFound(result);
        }

        return Ok(result);
    }

    [HttpGet("reports/summary")]
    public IActionResult GetSummary()
    {
        var result = service.GetReportsSummary();
        return Ok(result);
    }

}