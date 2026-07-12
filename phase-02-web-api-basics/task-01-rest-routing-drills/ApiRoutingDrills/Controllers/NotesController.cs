using ApiRoutingDrills.DTOs;
using Microsoft.AspNetCore.Mvc;
namespace ApiRoutingDrills.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private static readonly List<CreateNoteRequest> requests = new List<CreateNoteRequest>();
        [HttpPost]

        //Drill 06
        public IActionResult CreateNote([FromBody] CreateNoteRequest userrequest)
        {
            if (string.IsNullOrWhiteSpace(userrequest.Title))
                return BadRequest(new
                {
                    message = "Title is required."
                });
            CreateNoteRequest request = new()
            {
                Id = requests.Count + 1,
                Title = userrequest.Title,
                Content = userrequest.Content,
                CreatedAt = DateTime.Now
            };
            requests.Add(request);
            return Ok(request);
        }


        //Drill 07
        [HttpGet]
        public IActionResult GetNotes()
        {
            if (!requests.Any())
                return Ok(new
                {
                    Message = "No Notes Found",
                    Notes = requests
                });
            return Ok(requests);
        }




        //Drill 08
        [HttpGet("{id}")]
        public IActionResult GetNoteById(int id)
        {
            var note = requests.FirstOrDefault(n => n.Id == id);
            if (note != null)
            {
                return Ok(note);
            }
            else
            {
                return NotFound(new { message = "Note not found" });
            }
        }


        //Drill 09
        [HttpPut("{id}")]
        public IActionResult UpdateNote(int id, [FromBody] UpdateNoteRequest userNote)
        {
            if (string.IsNullOrWhiteSpace(userNote.Title) || string.IsNullOrWhiteSpace(userNote.Content))
                return BadRequest("Title and Content are required.");
            else
            {
                var note = requests.FirstOrDefault(n => n.Id == id);
                if (note != null)
                {
                    note.Content = userNote.Content;
                    note.Title = userNote.Title;
                    return Ok(note);
                }
                else
                {
                    return NotFound(new
                    {
                        message = "Note not found"
                    });
                }

            }
        }

        //Drill 10
        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            var note = requests.FirstOrDefault(n => n.Id == id);
            if (note == null)
            {
                return NotFound(new { message = "Note not found" });
            }
            else
            {
                requests.Remove(note);
                return NoContent();
            }
        }

        //Drill 11
        [HttpGet("search")]
        public IActionResult SearchNote([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest(new
                {
                    message = "Keyword is required."
                });
            }
            var notes = requests.Where(n => n.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) || n.Content.Contains(keyword, StringComparison.OrdinalIgnoreCase));
            if (!notes.Any())
            {
                return NotFound(new { message = "Note not found" });
            }
            else
            {
                return Ok(notes);
            }
        }
        //Drill 12 
        [HttpGet("pagination")]
        public IActionResult PaginationDemo([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            if (pageNumber <= 0)
                return BadRequest(new
                {
                    message = "Page number must be greater than zero."
                });

            if (pageSize < 1 || pageSize > 50)
                return BadRequest(new
                {
                    message = "Page size must be between 1 and 50."
                });
            var notes = requests.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (notes.Any())
                return Ok(new
                {
                    items = notes,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = requests.Count
                });

            else
                return NotFound("No Notes Found");
        }


    }
}

