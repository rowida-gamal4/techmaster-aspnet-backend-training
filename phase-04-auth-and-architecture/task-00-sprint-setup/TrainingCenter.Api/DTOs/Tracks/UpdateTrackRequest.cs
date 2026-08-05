using System.ComponentModel.DataAnnotations;
using TrainingCenter.Entities;

namespace TrainingCenter.DTOs
{
    public class UpdateTrackRequest
    {
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Code { get; set; } = string.Empty;

        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public TrackLevel Level { get; set; }

        [Range(1, 1000)]
        public int Capacity { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public string Status { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int InstructorId { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
    }
}