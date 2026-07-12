using System.ComponentModel.DataAnnotations;
namespace ApiRoutingDrills.DTOs
{
    public class CreateNoteRequest
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = default!;

        public string Content { get; set; } = default!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}


