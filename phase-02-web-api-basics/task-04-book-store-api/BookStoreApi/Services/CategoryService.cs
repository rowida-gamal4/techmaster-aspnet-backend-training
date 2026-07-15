using BookStoreApi.DTOs;
using BookStoreApi.Models;
using BookStoreApi.Seed;

namespace BookStoreApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly List<Category> categories = SeedData.categories;
        public ResponseDTO<CategoryResponse> CreateCategory(CreateCategoryRequest request)
        {
            var response = new ResponseDTO<CategoryResponse>();
            if (categories.Any(c => c.Name.Equals(request.Name, StringComparison.OrdinalIgnoreCase)))
            {
                response.Success = false;
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Errors.Add("Category name already exists.");

                return response;
            }
            Category category = new()
            {
                CategoryId = categories.Count + 1,
                Name = request.Name,
                Description = request.Description,
                IsActive = true,

            };
            categories.Add(category);
            CategoryResponse categoryResponse = new()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
                IsActive = category.IsActive,
            };

            response.Success = true;
            response.StatusCode = StatusCodes.Status201Created;
            response.Data = categoryResponse;

            return response;
        }


        public ResponseDTO<List<CategoryResponse>> GetAllCategories()
        {
            var response = new ResponseDTO<List<CategoryResponse>>();

            var activeCategories = categories.Where(c => c.IsActive);

            List<CategoryResponse> categoryResponses = new();

            foreach (var category in activeCategories)
            {
                CategoryResponse respone = new()
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description,
                    IsActive = category.IsActive,

                };
                categoryResponses.Add(respone);
            }

            response.Success = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Data = categoryResponses;

            return response;
        }
    }
}