using ProductsCategoriesApi.DTOs;
using ProductsCategoriesApi.Models;
using ProductsCategoriesApi.SeededData;

namespace ProductsCategoriesApi.Services
{
    public class CategoryService : ICategoryService
    {
       private readonly List<Category> categories = Seed.Categories;
        public CategoryResponse CreateCategory(CreateCategoryRequest request)
        {
            if (categories.Any(c=>c.Name.Equals(request.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return null ;
            }
            Category category = new()
            {
                CategoryId = categories.Count +1 ,
                Name = request.Name ,
                Description = request.Description ,
                IsActive = true ,
                CreatedAt = DateTime.UtcNow
            };
            categories.Add(category);
            CategoryResponse respone = new (){
                CategoryId = category.CategoryId ,
                Name = category.Name ,
                Description = category.Description ,
                IsActive = category.IsActive ,
                CreatedAt = category.CreatedAt
            };
            return respone ;
        }

        public List<CategoryResponse> GetAllCategories()
        {
            var activeCategories = categories.Where(c=>c.IsActive);
            List<CategoryResponse> categoryResponses = new() ;
            foreach (var category in activeCategories)
            {
                CategoryResponse respone = new (){
                CategoryId = category.CategoryId ,
                Name = category.Name ,
                Description = category.Description ,
                IsActive = category.IsActive ,
                CreatedAt = category.CreatedAt
                
            };
              categoryResponses.Add(respone);
            }
            return categoryResponses ;
        }
    }
}