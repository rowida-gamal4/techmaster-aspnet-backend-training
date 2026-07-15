using BookStoreApi.DTOs;
using BookStoreApi.Models;
using BookStoreApi.Seed;

namespace BookStoreApi.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly List<Author> authors = SeedData.authors;
        private readonly List<Book> books = SeedData.books;
        public ResponseDTO<AuthorResponse> CreateAuthor(CreateAuthorRequest request)
        {
            var response = new ResponseDTO<AuthorResponse>();

            if (authors.Any(a => a.FullName.Equals(request.FullName, StringComparison.OrdinalIgnoreCase)))
            {
                response.Success = false;
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Errors.Add("Author already exists.");
                return response;
            }

            Author author = new()
            {
                AuthorId = authors.Count + 1,
                FullName = request.FullName,
                Country = request.Country,
                BirthDate = request.BirthDate,
                CreatedAt = DateTime.Now
            };

            authors.Add(author);
            AuthorResponse authorResponse = new ()
            {
                AuthorId = author.AuthorId,
                FullName = author.FullName,
                Country = author.Country,
                BirthDate = author.BirthDate,
                CreatedAt = author.CreatedAt
            };
            response.Success = true;
            response.StatusCode = StatusCodes.Status201Created;
            response.Data = authorResponse ;

            return response ;
        }

       
        public ResponseDTO<List<AuthorResponse>> GetAllAuthors()
        {
            var response = new ResponseDTO<List<AuthorResponse>>();

            List<AuthorResponse> authorResponses = new();
            foreach (var author in authors)
            {
                AuthorResponse authorResponse = new()
                {
                    AuthorId = author.AuthorId,
                    FullName = author.FullName,
                    Country = author.Country,
                    BirthDate = author.BirthDate,
                    CreatedAt = author.CreatedAt
                };
                authorResponses.Add(authorResponse);
            }
          response.Success = true;
          response.StatusCode = StatusCodes.Status200OK;
          response.Data = authorResponses;

          return response;
        }
       public ResponseDTO<bool> DeleteAuthor(int id)
      {
            var response = new ResponseDTO<bool>();

            var author = authors.FirstOrDefault(a => a.AuthorId == id);

            if (author is null)
            {
                response.Success = false;
                response.StatusCode = StatusCodes.Status404NotFound;
                response.Errors.Add("Author not found.");

                return response;
            }

            var hasBooks = books.Any(b => b.AuthorId == id);

            if (hasBooks)
            {
                response.Success = false;
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.Errors.Add("Can not delete author with books.");

                return response;
            }

            authors.Remove(author);

            response.Success = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Data = true;

            return response;
        }

    }
}