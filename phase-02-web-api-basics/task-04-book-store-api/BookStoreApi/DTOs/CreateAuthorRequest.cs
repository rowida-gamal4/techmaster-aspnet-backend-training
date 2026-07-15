using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.DTOs
{
    public class CreateAuthorRequest
    {
        [Required]
        public string FullName { get; set; } = default!;

        [Required]
        public string Country { get; set; } = default!;

        public DateTime? BirthDate { get; set; }
    }
}