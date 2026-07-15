# Book Store API

## Project Overview

The Book Store API is an ASP.NET Core Web API that manages books, authors, and categories using inmemory collections. The project follows a layered architecture with Controllers, Services, DTOs, Models, and Seed Data. It demonstrates RESTful API design, validation, DTO mapping, filtering, reporting, and proper HTTP status codes in preparation for Entity Framework Core.

# Technologies Used

 ASP.NET Core Web API
 .NET 8
 C#
 LINQ
 Data Annotations
 Swagger / OpenAPI

# Seed Data

The application contains preloaded data for testing.

# Feature 01 – Authors API

This feature manages authors that books can be assigned to.

## Endpoint 1
Route: 'GET /api/authors'
Purpose: Returns all authors.
How to Test: Send a GET request to '/api/authors'. Verify that all authors are returned.

## Endpoint 2
Route: 'POST /api/authors'
Purpose: Creates a new author.
How to Test: Send a POST request with valid author information. Verify that the author is created successfully. Try creating another author with the same name to verify the validation rule.

## Endpoint 3
Route: 'DELETE /api/authors/{id}'
Purpose: Deletes an author if there are no books assigned to that author.
How to Test: Delete an author without books and verify success. Try deleting an author that has books or an author that does not exist to verify the error responses.

-------------------------------
# Feature 02 – Categories API

This feature manages book categories.

## Endpoint 1
Route: 'GET /api/categories'
Purpose: Returns all active categories.
How to Test: Send a GET request to '/api/categories'. Verify that only active categories are returned.

## Endpoint 2
Route: 'POST /api/categories'
Purpose: Creates a new category.
How to Test: Send a POST request with valid category information. Verify that the category is created successfully. Try creating another category with the same name to verify the uniqueness validation.

--------------------------------
# Feature 03 – Books API

This feature manages book records.

## Endpoint 1
Route: 'GET /api/books'
Purpose: Returns all books with optional search, filtering, and pagination.
How to Test: Test the following requests:
- '/api/books'
- '/api/books?title=Clean'
- '/api/books?isbn=978'
- '/api/books?authorId=2'
- '/api/books?categoryId=1'
- '/api/books?isAvailable=true'
- '/api/books?pageNumber=1&pageSize=5'

## Endpoint 2
Route: 'GET /api/books/{id}'
Purpose: Returns a single book by its id.
How to Test: Request an existing id and then request a non-existing id to verify the '404 Not Found' response.

## Endpoint 3
Route: 'POST /api/books'
Purpose: Creates a new book after validating all business rules.
How to Test: Create a valid book, then test duplicate ISBN, invalid AuthorId, invalid CategoryId, inactive CategoryId, negative stock quantity, and invalid price.

## Endpoint 4
Route: 'PUT /api/books/{id}'
Purpose: Updates an existing book.
How to Test: Update a valid book, then test updating a non-existing book and sending invalid data.

## Endpoint 5
Route: 'DELETE /api/books/{id}'
Purpose: Deletes a book.
How to Test: Delete an existing book, then try deleting a non-existing book.

----------------------------------------
# Feature 04 – Reports Summary

This feature provides management statistics about the bookstore.

## Endpoint 1
Route: 'GET /api/books/reports/summary'
Purpose: Returns: Total books. Available books. Out of stock books. Books per category. Books per author.Total inventory value.
How to Test: Send a GET request to '/api/books/reports/summary'. Verify that all report values are returned correctly based on the seeded data.


# Validation Rules

### Authors
 Full name is required.
 Author names must be unique.

### Categories
 Name is required.
 Category names must be unique.
 Inactive categories cannot be assigned to books.

### Books
 Title is required.
 ISBN is required.
 ISBN must be unique.
 Price must be greater than zero.
 Stock quantity cannot be negative.
 Author must exist.
 Category must exist.
 Category must be active.



# Review Questions

### Why did you use these routes?

The routes follow RESTful API conventions where each resource has its own endpoint and the HTTP method determines the operation being performed.

### What DTOs did you create?

 CreateAuthorRequest
 AuthorResponse
 CreateCategoryRequest
 CategoryResponse
 CreateBookRequest
 UpdateBookRequest
 BookResponse
 SearchAndPagination
 ReportsSummary
 ResponseDTO<T>

### What validation rules did you apply?

 Required fields.
 Unique author names.
 Unique category names.
 Unique ISBN.
 Existing author validation.
 Existing category validation.
 Active category validation.
 Positive price validation.
 Nonnegative stock validation.

### How will this change when EF Core is added?

The inmemory collections will be replaced with SQL Server tables through Entity Framework Core. Services will use DbContext instead of seed lists, while the API routes, DTOs, and business rules will remain almost unchanged.

