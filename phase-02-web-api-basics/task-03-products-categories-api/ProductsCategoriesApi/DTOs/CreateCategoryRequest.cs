using System.ComponentModel.DataAnnotations;

namespace ProductsCategoriesApi.DTOs
{
    public class CreateCategoryRequest
    {
        [Required]
        public string Name {get;set;} = default! ;

        [Required]
        public string Description {get;set;} = default! ;
      
    }
}