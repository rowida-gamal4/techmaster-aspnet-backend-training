using System.ComponentModel.DataAnnotations;

namespace TrainingCenter.DTOs
{
    public class AssignInstructorRequest
    {
        [Required]
        public int InstructorId { get; set; }
    }
}