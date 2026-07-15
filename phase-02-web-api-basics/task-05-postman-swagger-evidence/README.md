# Task 05 - Swagger & Postman Evidence Pack

This task provides proof that all Phase 02 APIs work correctly using Swagger and Postman.


# Projects Included

The Postman collection contains requests for the following projects:

- Student Management API
- Products & Categories API
- Book Store API

# Swagger Evidence

Swagger was used to verify that:

- All controllers are visible.
- All endpoints are documented.
- Request DTOs appear correctly.
- Responses can be tested directly.

Swagger screenshots are included in Drive : https://drive.google.com/drive/folders/1Ggf3MrINvhtRUYNu64ZgsJgNApvcfLXZ?usp=drive_link

# Postman Collection

The repository includes one Postman collection containing requests for all Phase 02 APIs.

Collection structure:

Student Management API
    Create Student
    Get All Students
    Get Student By Id
    Update Student
    Update Student Status
    Delete Student
    Student Stats

Products & Categories API
    Get All Categories
    Create Category
    Get All Products
    Get Product With Id
    Create Product
    Update Product
    Update Product Stock
    Delete Products
    Get Products with Filter
    Product Stock Value Report

Book Store API
    Create Author
    Get All Authors
    Delete Author
    Get All Books
    Delete Book
    Create Book
    Reports Summary
    Create Category
    Get All Categories

Error Cases
    Missing Resource 404\
    Invalid Request 400\
    Validation Error\


# Importing the Collection

1. Open Postman.
2. Select Import.
3. Choose the exported collection JSON file.
4. Import the collection.

# Base URL Configuration

Each API project runs on a different port.

Create three environment variables in Postman:

1- studentBaseUrl = https://localhost:5281
2- productsBaseUrl = https://localhost:5034
3- booksBaseUrl = https://localhost:5033

Each request uses the appropriate variable for its project.

# Success Requests

The collection includes successful requests demonstrating:

- Creating resources
- Retrieving resources
- Updating resources
- Searching and filtering
- Reports and statistics


# Error Requests

The collection also includes common error scenarios:

### Missing Resource (404)
Tests requests using IDs that do not exist.
- Get Student with invalid ID
- Delete Product with invalid ID
- Get Book with invalid ID

### Invalid Request (400)
Tests business rule failures.
- Create Book With Invalid AuthorID
- Delete Author with Books

### Validation Error
Tests model validation.
- Create Product With Negative price
- Create Book With Negative stock quantity

# Evidence Included
The Drive contains:
- Swagger screenshots
- Postman request screenshots
- Error response screenshots
- Exported Postman collection

The Repo contains:
- Exported Postman collection
- README documentation


