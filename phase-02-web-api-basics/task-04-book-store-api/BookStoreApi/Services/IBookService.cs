using BookStoreApi.DTOs;

namespace  BookStoreApi.Services
{
    public interface IBookService
    {
        public ResponseDTO<BookResponse >GetBookById(int id);
        public ResponseDTO<List<BookResponse> >GetAllBooks(SearchAndPagination filter);
        public ResponseDTO<BookResponse > CreateBook(CreateBookRequest request);
        public ResponseDTO<BookResponse > UpdateBook(int id,UpdateBookRequest request);
        public ResponseDTO<bool> DeleteBook(int id);
        public ResponseDTO<ReportsSummary> GetReportsSummary();
    }
}