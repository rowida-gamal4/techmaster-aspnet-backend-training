using System.ComponentModel.DataAnnotations;
namespace ApiRoutingDrills.DTOs
{
    public class UpdateNoteRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;

        public string Content { get; set; } = default!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}


