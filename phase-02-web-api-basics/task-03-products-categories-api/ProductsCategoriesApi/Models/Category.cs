using System.ComponentModel.DataAnnotations;

namespace ProductsCategoriesApi.Models
{
    public class Category
    {
        public int CategoryId {get;set;}

        [Required]
        public string Name {get;set;} = default! ;

        [Required]
        public string Description {get;set;} = default! ;
        public bool IsActive {get;set;} 
        public DateTime CreatedAt {get;set;} = DateTime.UtcNow ;
    }
}