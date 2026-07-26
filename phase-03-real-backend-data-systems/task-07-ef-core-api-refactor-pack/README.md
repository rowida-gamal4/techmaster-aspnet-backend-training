# Task 07 – EF Core/API Refactor Pack

## Overview

This task demonstrates the refactoring of a poorly designed EF Core Web API into a cleaner, maintainable, and production-ready implementation. The original controller was preserved for comparison, while a refactored version was created following ASP.NET Core and EF Core best practices.

The refactoring focused on improving code quality without changing the original business purpose.



# Problems Found

1. Returned full EF Core entities instead of DTOs, exposing unnecessary data.
2. Navigation properties were returned, creating large and potentially circular JSON responses.
3. No pagination, causing all enrollments to be loaded into memory.
4. No projection ('Select'), retrieving more database columns than required.
5. Accepted EF Core entities directly from the request body.
6. Business logic was implemented inside the controller instead of a service layer.
7. Duplicate active enrollments were allowed.
8. Track capacity was ignored when creating enrollments.
9. Payment amount was not validated, allowing invalid values.
10. Used synchronous EF Core methods ('ToList', 'SaveChanges', 'FirstOrDefault').
11. Returned incorrect HTTP status codes (such as '200 OK' for missing resources).
12. Used hard delete, permanently removing enrollment records.
13. No validation for missing students or tracks.
14. Payment endpoint duplicated database query logic.
15. Poor separation of responsibilities, making the controller difficult to maintain and test.


# Improvements Made

1. Introduced request DTOs instead of accepting EF entities directly.
2. Introduced response DTOs to return only the required data.
3. Moved all business logic from the controller into an 'EnrollmentService'.
4. Replaced synchronous EF Core methods with asynchronous methods ('ToListAsync', 'SaveChangesAsync', 'FirstOrDefaultAsync').
5. Added server-side pagination for the enrollment list endpoint.
6. Used projection ('Select') to return lightweight DTOs instead of full entities.
7. Added duplicate active enrollment validation.
8. Added track capacity validation before creating new enrollments.
9. Added payment amount validation to reject invalid amounts.
10. Replaced hard delete with soft delete to preserve historical records.
11. Returned appropriate HTTP status codes ('201 Created', '400 Bad Request', '404 Not Found', '204 No Content').
12. Added validation for missing students and training tracks.
13. Improved dependency injection by introducing an 'IEnrollmentService'.
14. Simplified controller actions so they only handle HTTP requests and responses.
15. Improved overall readability, maintainability, and adherence to clean architecture principles.


# Before vs After

### Before

- Controller contained business logic.
- Returned EF entities directly.
- Used synchronous EF Core methods.
- No DTOs.
- No pagination.
- No business validation.
- Hard delete.
- Incorrect HTTP status codes.

### After

- Business logic moved to the service layer.
- DTOs used for requests and responses.
- Async EF Core methods throughout.
- Projection with 'Select'.
- Pagination implemented.
- Business rules validated.
- Soft delete implemented.
- Proper RESTful status codes returned.



# Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Dependency Injection
- DTO Pattern
- Service Layer Pattern
- Async/Await


# Evidence

- Original bad controller preserved.
- Refactored implementation completed.
- Before and after screenshots included in the Drive .
- Refactoring completed through multiple meaningful commits.
- Application functionality preserved while improving code quality.

