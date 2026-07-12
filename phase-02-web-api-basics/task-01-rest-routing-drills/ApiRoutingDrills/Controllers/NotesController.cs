using ApiRoutingDrills.DTOs;
using Microsoft.AspNetCore.Mvc;
namespace ApiRoutingDrills.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly List<CreateNoteRequest> requests = new();
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
                return BadRequest();
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




    }
}

