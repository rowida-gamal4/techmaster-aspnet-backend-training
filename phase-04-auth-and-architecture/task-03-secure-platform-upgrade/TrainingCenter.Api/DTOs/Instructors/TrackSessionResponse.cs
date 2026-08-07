using System.ComponentModel.DataAnnotations;
using System.Data;

namespace TrainingCenter.DTOs
{
    public class TrackSessionResponse
    {
        public int SessionId {get;set;}
        public int TrainingTrackId {get;set;}
        public DateTime SessionDate { get; set; }

       
        public string Title { get; set; } = default!;

        public string? Description { get; set; }
        public bool IsCompleted {get;set;}

        public string? MeetingLink { get; set; }
        public int CreatedByInstructorId{get;set;}
    }
}