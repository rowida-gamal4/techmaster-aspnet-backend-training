using BookStoreApi.DTOs;

namespace BookStoreApi.Services
{
    public interface IAuthorService
    {
        public  ResponseDTO<List<AuthorResponse>> GetAllAuthors();
        public ResponseDTO<AuthorResponse> CreateAuthor(CreateAuthorRequest request);

        public ResponseDTO<bool> DeleteAuthor(int id);
    }
}