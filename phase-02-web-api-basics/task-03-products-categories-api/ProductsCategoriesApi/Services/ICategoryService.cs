using ProductsCategoriesApi.DTOs;

namespace ProductsCategoriesApi.Services
{
    public interface ICategoryService
    {
        public CategoryResponse CreateCategory(CreateCategoryRequest request);

        public List<CategoryResponse> GetAllCategories();

        
    }
}