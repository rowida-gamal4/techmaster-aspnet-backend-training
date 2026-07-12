# Task 01 - REST & Routing Drill Pack

## Objective

This task focuses on learning the fundamentals of ASP.NET Core Web API by building small REST endpoints that demonstrate routing, model binding, request validation, CRUD operations, status codes, and standard API responses.

## Technologies

- ASP.NET Core 8 Web API
- C#
- Swagger (OpenAPI)
- Postman

## Drill 01 – Health Check

- Endpoint: GET /api/health
- Purpose: Verify that the API is running successfully.
- Sample Request: GET /api/health

## Drill 02 – Route Parameter Echo

- Endpoint: GET /api/tools/echo/{name}
- Purpose: Practice reading route parameters.
- Sample Request: GET /api/tools/echo/Rowida

## Drill 03 – Query String Calculator

- Endpoint: GET /api/calculator/add?a=10&b=5
- Purpose: Practice reading query string parameters and performing a calculation.
- Sample Request: GET /api/calculator/add?a=10&b=5

## Drill 04 – Temperature Conversion

- Endpoint: GET /api/converter/celsius-to-fahrenheit?value=25
- Purpose: Convert Celsius to Fahrenheit using a service registered with Dependency Injection.
- Sample Request: GET /api/converter/celsius-to-fahrenheit?value=25

## Drill 05 – Grade API

- Endpoint: GET /api/grades/calculate?score=85
- Purpose: Validate the score and calculate the student's grade.
- Sample Request: GET /api/grades/calculate?score=85

## Drill 06 – Create Note

- Endpoint: POST /api/notes
- Purpose: Create a new note using a request body DTO.
- Sample Request: POST /api/notes

## Drill 07 – Get Notes List

- Endpoint: GET /api/notes
- Purpose: Retrieve all available notes.
- Sample Request: GET /api/notes

## Drill 08 – Get Note By Id

- Endpoint: GET /api/notes/{id}
- Purpose: Retrieve a specific note by its identifier.
- Sample Request: GET /api/notes/1

## Drill 09 – Update Note

- Endpoint: PUT /api/notes/{id}
- Purpose: Update an existing note.
- Sample Request: PUT /api/notes/1

## Drill 10 – Delete Note

- Endpoint: DELETE /api/notes/{id}
- Purpose: Delete a note by its identifier.
- Sample Request: DELETE /api/notes/1

## Drill 11 – Search Notes

- Endpoint: GET /api/notes/search?keyword=api
- Purpose: Search notes by title or content.
- Sample Request: GET /api/notes/search?keyword=api

## Drill 12 – Pagination Demo

- Endpoint: GET /api/notes/pagination?pageNumber=1&pageSize=5
- Purpose: Demonstrate pagination using Skip() and Take().
- Sample Request: GET /api/notes/pagination?pageNumber=1&pageSize=5

## Drill 13 – Header Reader

- Endpoint: GET /api/request-info
- Purpose: Read the custom X-Student-Name request header.
- Sample Request: GET /api/request-info (Header: X-Student-Name: Rowida)

## Drill 14 – Status Code Practice

- Endpoint: Multiple endpoints under /api/statuscodes
- Purpose: Demonstrate the use of common HTTP status codes (200, 201, 204, 400, and 404).
- Sample Request: GET /api/statuscodes/...

## Drill 15 – Standard Error Shape

- Endpoint: GET /api/errors/demo?name=Ali
- Purpose: Demonstrate a consistent API error response format.
- Sample Request: GET /api/errors/demo?name=Ali


## Evidence

- Swagger and Postman screenshots uploaded in the Drive

## Learning Outcome

By completing this task, I practiced building RESTful APIs using ASP.NET Core Web API, including routing, model binding, validation, CRUD operations, dependency injection, pagination, request headers,  status codes, and standardized error responses.
