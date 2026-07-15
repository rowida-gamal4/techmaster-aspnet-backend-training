using BookStoreApi.DTOs;
using BookStoreApi.Models;
using BookStoreApi.Seed;
using BookStoreApi.Services;

namespace BookStoreApi
{
    public class BookService : IBookService
    {
        private readonly List<Author> authors = SeedData.authors;
        private readonly List<Book> books = SeedData.books;

        private readonly List<Category> categories = SeedData.categories;

        public ResponseDTO<BookResponse> CreateBook(CreateBookRequest request)
        {
            var response = new ResponseDTO<BookResponse>();

            if (books.Any(b => b.ISBN.Equals(request.ISBN, StringComparison.OrdinalIgnoreCase)))
            {
                response.Errors.Add("ISBN already exists.");
            }

            if (!authors.Any(a => a.AuthorId == request.AuthorId))
            {
                response.Errors.Add("Author does not exist.");
            }

            var category = categories.FirstOrDefault(c => c.CategoryId == request.CategoryId);
            if (category is null)
            {
                response.Errors.Add("Category does not exist.");
            }
            else if (!category.IsActive)
            {
                response.Errors.Add("Category is inactive.");
            }

            if (request.Price <= 0)
            {
                response.Errors.Add("Price must be > zero.");
            }

            if (request.StockQuantity < 0)
            {
                response.Errors.Add("Stock can not be negative.");
            }
            if (response.Errors.Any())
            {
                response.Success = false;
                response.StatusCode = StatusCodes.Status400BadRequest;

                return response;
            }

            Book book = new()
            {
                BookId = books.Count + 1,
                Title = request.Title,
                ISBN = request.ISBN,
                PublishedYear = request.PublishedYear,
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId,
                IsAvailable = request.StockQuantity > 0 ? true : false,
                CreatedAt = DateTime.Now

            };
            books.Add(book);
            BookResponse bookResponse = new()
            {
                BookId = book.BookId,
                Title = book.Title,
                ISBN = book.ISBN,
                PublishedYear = book.PublishedYear,
                Price = book.Price,
                StockQuantity = book.StockQuantity,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId,
                IsAvailable = book.IsAvailable,
                CreatedAt = book.CreatedAt

            };

            response.Success = true;
            response.StatusCode = StatusCodes.Status201Created;
            response.Data = bookResponse;

            return response;


        }

        public ResponseDTO<bool> DeleteBook(int id)
        {
            var response = new ResponseDTO<bool>();

            var book = books.FirstOrDefault(b => b.BookId == id);

            if (book is null)
            {
                response.Success = false;
                response.StatusCode = StatusCodes.Status404NotFound;
                response.Errors.Add("Book does not exist.");
                response.Data = false;
                return response;
            }
            books.Remove(book);
            response.Success = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Data = true;

            return response;

        }

        public ResponseDTO<List<BookResponse>> GetAllBooks(SearchAndPagination filter)
        {
            var response = new ResponseDTO<List<BookResponse>>();
            var returnedBooks = books.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(filter.Title))
            {
                returnedBooks = returnedBooks.Where(b => b.Title.Contains(filter.Title, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(filter.ISBN))
            {
                returnedBooks = returnedBooks.Where(b => b.ISBN.Contains(filter.ISBN, StringComparison.OrdinalIgnoreCase));
            }

            if (filter.CategoryId != null)
            {
                returnedBooks = returnedBooks.Where(b => b.CategoryId == filter.CategoryId);
            }

            if (filter.AuthorId != null)
            {
                returnedBooks = returnedBooks.Where(b => b.AuthorId == filter.AuthorId);
            }

            if (filter.IsAvailable != null)
            {
                returnedBooks = returnedBooks.Where(b => b.IsAvailable == filter.IsAvailable);
            }

            if (filter.PageSize != null && filter.PageNumber != null)
            {
                returnedBooks = returnedBooks.Skip((filter.PageNumber.Value - 1) * filter.PageSize.Value).Take(filter.PageSize.Value);
            }

            List<BookResponse> bookResponses = new();

            foreach (var book in returnedBooks)
            {
                BookResponse bookResponse = new()
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    ISBN = book.ISBN,
                    PublishedYear = book.PublishedYear,
                    Price = book.Price,
                    StockQuantity = book.StockQuantity,
                    AuthorId = book.AuthorId,
                    CategoryId = book.CategoryId,
                    IsAvailable = book.IsAvailable,
                    CreatedAt = book.CreatedAt

                };

                bookResponses.Add(bookResponse);
            }

            response.Success = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Data = bookResponses;

            return response;
        }

        public ResponseDTO<BookResponse> GetBookById(int id)
        {
            var response = new ResponseDTO<BookResponse>();
            var book = books.FirstOrDefault(b => b.BookId == id);

            if (book is null)
            {
                response.Success = false;
                response.StatusCode = StatusCodes.Status404NotFound;
                response.Errors.Add("Book does not exist.");
                return response;
            }

            BookResponse bookResponse = new()
            {
                BookId = book.BookId,
                Title = book.Title,
                ISBN = book.ISBN,
                PublishedYear = book.PublishedYear,
                Price = book.Price,
                StockQuantity = book.StockQuantity,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId,
                IsAvailable = book.IsAvailable,
                CreatedAt = book.CreatedAt

            };

            response.Success = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Data = bookResponse;

            return response;

        }

        public ResponseDTO<ReportsSummary> GetReportsSummary()
        {
            var totalBooks = books.Count();
            var availableBooks = books.Count(b => b.IsAvailable);
            var outOfStoscks = books.Count(b => b.StockQuantity == 0);
            var totalValue = books.Sum(b => b.Price * b.StockQuantity);

            var booksPerCategory = books.GroupBy(b => b.CategoryId).ToDictionary(
             group => categories.First(c => c.CategoryId == group.Key).Name,
             group => group.Count()
             );
             
            var booksPerAuthor = books.GroupBy(b => b.AuthorId).ToDictionary(
            group => authors.First(a => a.AuthorId == group.Key).FullName,
            group => group.Count()
            );


            ReportsSummary summary = new()
            {
                TotalBooks = totalBooks,
                AvailableBooks = availableBooks,
                OutOfStocksBooks = outOfStoscks,
                TotalInventoryValue = totalValue,
                BooksPerCategory = booksPerCategory,
                BookPerAuthor = booksPerAuthor

            };
            var response = new ResponseDTO<ReportsSummary>()
            {
                Success = true,
                StatusCode = StatusCodes.Status200OK,
                Data = summary
            };

            return response;
        }

        public ResponseDTO<BookResponse> UpdateBook(int id, UpdateBookRequest request)
        {
            var response = new ResponseDTO<BookResponse>();
            var book = books.FirstOrDefault(b => b.BookId == id);

            if (book is null)
            {
                response.Errors.Add("Book does not exist.");
            }
            if (books.Any(b => b.ISBN.Equals(request.ISBN, StringComparison.OrdinalIgnoreCase) && b.BookId != id))
            {
                response.Errors.Add("ISBN already exists.");
            }

            if (!authors.Any(a => a.AuthorId == request.AuthorId))
            {
                response.Errors.Add("Author does not exist.");
            }

            var category = categories.FirstOrDefault(c => c.CategoryId == request.CategoryId);
            if (category is null)
            {
                response.Errors.Add("Category does not exist.");
            }

            else if (!category.IsActive)
            {
                response.Errors.Add("Category is inactive.");
            }

            if (request.Price <= 0)
            {
                response.Errors.Add("Price must be > zero.");
            }

            if (request.StockQuantity < 0)
            {
                response.Errors.Add("Stock can not be negative.");
            }

            if (response.Errors.Any())
            {
                response.Success = false;
                response.StatusCode = StatusCodes.Status400BadRequest;

                return response;
            }

            book!.Title = request.Title;
            book.ISBN = request.ISBN;
            book.PublishedYear = request.PublishedYear;
            book.Price = request.Price;
            book.StockQuantity = request.StockQuantity;
            book.AuthorId = request.AuthorId;
            book.CategoryId = request.CategoryId;
            book.IsAvailable = request.StockQuantity > 0;

            BookResponse bookResponse = new()
            {
                BookId = book.BookId,
                Title = book.Title,
                ISBN = book.ISBN,
                PublishedYear = book.PublishedYear,
                Price = book.Price,
                StockQuantity = book.StockQuantity,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId,
                IsAvailable = book.IsAvailable,
                CreatedAt = book.CreatedAt

            };

            response.Success = true;
            response.StatusCode = StatusCodes.Status200OK;
            response.Data = bookResponse;

            return response;
        }

    }
}