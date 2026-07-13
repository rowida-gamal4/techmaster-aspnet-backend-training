using System.ComponentModel.DataAnnotations;

namespace StudentManagementApi.DTOs
{
    public class PagedResultRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? TrackName { get; set; }
        public bool? IsActive { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}