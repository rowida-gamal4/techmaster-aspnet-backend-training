using BookStoreApi.DTOs;

namespace BookStoreApi.Services
{
    public interface ICategoryService
    {
        public ResponseDTO<List<CategoryResponse>> GetAllCategories() ;
        public ResponseDTO<CategoryResponse> CreateCategory(CreateCategoryRequest request);
    }
}