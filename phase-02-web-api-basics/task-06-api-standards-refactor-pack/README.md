# Task 06 - API Standards & Refactor Pack

## Overview

This task focused on refactoring a poorly designed ASP.NET Core Web API into a cleaner, more maintainable, and RESTful application. The original implementation mixed business logic, validation, and data storage inside the controller. The refactored version separates responsibilities using models, DTOs, and a service layer while following better API design practices.


# Project Structure

Task06-ApiStandards-Refactor-Pack/
     README.md
     OriginalBadCode/
         ProductsController.cs
     RefactoredApi/
         Controllers/
             ProductsController.cs
         DTOs/
       CreateProductRequest.cs
             ProductResponse.cs
         Models/
             Product.cs
         Services/
             IProductService.cs
             ProductService.cs
        Program.cs

# Original Problems

The original API had several design issues:

- Controller contained business logic and data storage.
- Product model used public fields instead of properties.
- POST endpoint accepted query parameters instead of a request body DTO.
- Validation returned -200 OK- with error messages.
- Missing products returned -200 OK- instead of -404 Not Found-.
- No service layer existed.
- Routes were not RESTful ('all' and 'get').
- Controller was responsible for validation, storage, and response generation.
- No separation between API models and response models.


# Improvements Made

The API was refactored with the following improvements:

1. Converted the 'Product' model from public fields to properties.
2. Added a 'CreateProductRequest' DTO for incoming requests.
3. Added a 'ProductResponse' DTO to control response data.
4. Introduced 'IProductService' and 'ProductService' to separate business logic from the controller.
5. Moved product creation and retrieval logic out of the controller.
6. Updated routes to follow REST conventions:
   - 'POST /api/products'
   - 'GET /api/products'
   - 'GET /api/products/{id}'
7. Replaced incorrect status codes with proper HTTP responses:
   - --201 Created-- for successful creation.
   - --404 Not Found-- when a product does not exist.
   - Automatic --400 Bad Request-- validation using Data Annotations and '[ApiController]'.
8. Added model validation using Data Annotations such as 'Required' and 'Range'.
9. Returned DTOs instead of exposing the domain model directly.
10. Reduced controller responsibility, making it cleaner, easier to maintain, and easier to test.


# Before vs After

# Before                          
- Business logic inside controller 
- Public fields in model           
- Query string parameters in POST  
- Validation returned '200 OK'     
- No service layer                 
- Poor route names ('all', 'get')  
- Controller handled everything    
- Domain model returned directly   

# After                                   
- Business logic moved to 'ProductService' 
- Auto-properties with getters and setters 
- Request body DTO                         
- Proper HTTP status codes                 
- Service layer with dependency injection  
- RESTful routes                           
- Clear separation of responsibilities     
- Response DTO returned                    

# What I Learned

Through this task, I learned why separating responsibilities makes an API easier to maintain and extend. Using DTOs helps prevent exposing internal models and allows better control over request and response data. Moving business logic into a service keeps controllers small and focused on handling HTTP requests. I also learned the importance of returning the correct HTTP status codes and following RESTful route conventions. Finally, I practiced using dependency injection and Data Annotations to build cleaner and more professional ASP.NET Core APIs.

# Technologies Used

- ASP.NET Core Web API
- C#
- Dependency Injection
- Data Annotations
- RESTful API Design
- Swagger/OpenAPI

# Screenshots

Add screenshots demonstrating:

- Original bad API code
- Successful product creation
- Get all products
- Get product by ID
- Validation error (400 Bad Request)
- Product not found (404 Not Found)

# Result

The final API is cleaner, follows REST principles, separates concerns properly, uses DTOs and a service layer, and returns appropriate HTTP status codes while preserving the original functionality.
