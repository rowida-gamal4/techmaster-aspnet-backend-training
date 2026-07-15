using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.DTOs
{
    public class CreateCategoryRequest
    {
        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public string Description { get; set; } = default!;

       
    }
}