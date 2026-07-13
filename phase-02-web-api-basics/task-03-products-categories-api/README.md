# Task 03 – Products & Categories API

## Project Overview

This project is a controller-based ASP.NET Core Web API that simulates a simple store management system using in-memory data. It allows managing categories and products, supports CRUD operations, searching, filtering, stock management, and reporting.

## How to Run

1. Open the project in Visual Studio or VS Code.
2. Build and run the project.
3. Open Swagger.
4. Test the endpoints using Swagger or Postman.


# API Endpoints

## Feature 01 – Category CRUD

### Create Category
- Endpoint: 'POST /api/categories'
- Purpose: Creates a new category.
- How to Test:
  - Open Swagger.
  - Execute 'POST /api/categories'.
  - Provide a category name and description.
  - Verify that a new category is returned.

### Get All Categories
- Endpoint: 'GET /api/categories'
- Purpose: Returns all active categories.
- How to Test:
  - Execute 'GET /api/categories'.
  - Verify that only active categories are returned.

# Feature 02 – Product CRUD

### Create Product
- Endpoint: 'POST /api/products'
- Purpose: Creates a new product after validating that the category exists.
- How to Test:
  - Execute 'POST /api/products'.
  - Enter valid product information.
  - Verify that the product is created successfully.

### Get All Products

- Endpoint: 'GET /api/products'
- Purpose: Returns all available products.
- How to Test:
  - Execute 'GET /api/products'.
  - Verify that all available products are returned.

### Get Product By Id
- Endpoint: 'GET /api/products/{id}'
- Purpose: Returns a single product by its ID.
- How to Test:
  - Execute 'GET /api/products/1'.
  - Verify the returned product.
  - Try a non-existing ID and verify a 404 response.

### Update Product
- Endpoint: 'PUT /api/products/{id}'
- Purpose: Updates product information.
- How to Test:
  - Execute 'PUT /api/products/1'.
  - Modify the product information.
  - Verify the updated product is returned.

### Update Product Stock
- Endpoint: 'PATCH /api/products/{id}/stock'
- Purpose: Updates the stock quantity and availability.
- How to Test:

  - Execute 'PATCH /api/products/1/stock'.
  - Enter a new stock quantity.
  - Verify that the stock quantity and availability are updated.

### Delete Product
- Endpoint: 'DELETE /api/products/{id}'
- Purpose: Deletes a product.
- How to Test:

  - Execute 'DELETE /api/products/1'.
  - Verify the success message.
  - Try deleting the same product again to receive a 404 response.

# Feature 03 – Search & Filters

### Search and Filter Products

- Endpoint: 'GET /api/products'
- Purpose: Searches and filters products by name, category, price range, availability, and low stock.
- How to Test:
  - Execute requests such as:
    - '/api/products?name=laptop'
    - '/api/products?categoryId=1'
    - '/api/products?minPrice=500'
    - '/api/products?maxPrice=5000'
    - '/api/products?isAvailable=true'
    - '/api/products?lowStock=5'
  - Verify that the returned products match the supplied filters.

# Feature 04 – Stock Reports

### Get Stock Reports
- Endpoint: 'GET /api/products/reports/stock-value'
- Purpose: Returns business statistics including total stock value, stock value per category, low stock products, out-of-stock products, and product count by category.
- How to Test:
  - Execute 'GET /api/products/reports/stock-value'.
  - Verify that the response contains all report values and category summaries.


## Seed Data

The project contains preloaded data for testing.

### Categories

- Electronics
- Furniture
- Stationery
- Accessories

### Products

The project includes 15 seeded products.

## Technologies Used

- ASP.NET Core Web API
- C#
- Dependency Injection
- LINQ
- Swagger (OpenAPI)
- In-Memory Collections ('List')
