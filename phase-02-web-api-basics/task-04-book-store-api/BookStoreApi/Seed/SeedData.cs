using BookStoreApi.Models;

namespace BookStoreApi.Seed
{
    public class SeedData
    {
        public static  List<Category> categories = new()
{
    new Category
    {
        CategoryId = 1,
        Name = "Programming",
        Description = "Programming books",
        IsActive = true
    },

    new Category
    {
        CategoryId = 2,
        Name = "Database",
        Description = "SQL and database books",
        IsActive = true
    },

    new Category
    {
        CategoryId = 3,
        Name = "Computer Science",
        Description = "Algorithms and data structures",
        IsActive = true
    },

    new Category
    {
        CategoryId = 4,
        Name = "Web Development",
        Description = "Frontend and backend development",
        IsActive = true
    }
};

        public static  List<Author> authors = new()
{
    new Author
    {
        AuthorId = 1,
        FullName = "Ali Hassan",
        Country = "Egypt",
        BirthDate = new DateTime(2004, 12, 5)
    },

    new Author
    {
        AuthorId = 2,
        FullName = "Hassan Ali",
        Country = "Egypt",
        BirthDate = new DateTime(2003, 12, 18)
    },

    new Author
    {
        AuthorId = 3,
        FullName = "Arwa Ahmed",
        Country = "Egypt",
        BirthDate = new DateTime(2002, 1, 1)
    },

    new Author
    {
        AuthorId = 4,
        FullName = "Sama Samy",
        Country = "Egypt",
        BirthDate = new DateTime(2001, 3, 13)
    },

    new Author
    {
        AuthorId = 5,
        FullName = "Gamal Hassan",
        Country = "Egypt",
        BirthDate = new DateTime(2000, 6, 19)
    }

};
        public static  List<Book> books = new()
{
    new Book
    {
        BookId = 1,
        Title = "Clean Code",
        ISBN = "978013",
        PublishedYear = 2008,
        Price = 950,
        StockQuantity = 15,
        AuthorId = 1,
        CategoryId = 1,
        IsAvailable = true
    },

    new Book
    {
        BookId = 2,
        Title = "Clean Architecture",
        ISBN = "978014",
        PublishedYear = 2017,
        Price = 1100,
        StockQuantity = 10,
        AuthorId = 1,
        CategoryId = 1,
        IsAvailable = true
    },

    new Book
    {
        BookId = 3,
        Title = "Refactoring",
        ISBN = "978015",
        PublishedYear = 2018,
        Price = 1250,
        StockQuantity = 8,
        AuthorId = 2,
        CategoryId = 1,
        IsAvailable = true
    },

    new Book
    {
        BookId = 4,
        Title = "Entity Framework",
        ISBN = "978016",
        PublishedYear = 2002,
        Price = 1450,
        StockQuantity = 6,
        AuthorId = 2,
        CategoryId = 1,
        IsAvailable = true
    },

    new Book
    {
        BookId = 5,
        Title = "The Programming",
        ISBN = "978017",
        PublishedYear = 2019,
        Price = 980,
        StockQuantity = 18,
        AuthorId = 3,
        CategoryId = 1,
        IsAvailable = true
    },

    new Book
    {
        BookId = 6,
        Title = "Design Patterns",
        ISBN = "978018",
        PublishedYear = 1994,
        Price = 1300,
        StockQuantity = 12,
        AuthorId = 4,
        CategoryId = 3,
        IsAvailable = true
    },

    new Book
    {
        BookId = 7,
        Title = "C# ",
        ISBN = "978019",
        PublishedYear = 2019,
        Price = 1200,
        StockQuantity = 9,
        AuthorId = 5,
        CategoryId = 4,
        IsAvailable = true
    },

    new Book
    {
        BookId = 8,
        Title = "SQL",
        ISBN = "978020",
        PublishedYear = 2012,
        Price = 850,
        StockQuantity = 20,
        AuthorId = 2,
        CategoryId = 2,
        IsAvailable = true
    },

    new Book
    {
        BookId = 9,
        Title = "Algorithms",
        ISBN = "978021",
        PublishedYear = 2011,
        Price = 1600,
        StockQuantity = 4,
        AuthorId = 4,
        CategoryId = 3,
        IsAvailable = true
    },

    new Book
    {
        BookId = 10,
        Title = "ASP.NET Core",
        ISBN = "978021",
        PublishedYear = 2023,
        Price = 1350,
        StockQuantity = 14,
        AuthorId = 5,
        CategoryId = 4,
        IsAvailable = true
    }
};
    }
}