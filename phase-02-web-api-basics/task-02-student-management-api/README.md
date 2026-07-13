# Task 02 – Student Management API

## Overview

This project is an in-memory ASP.NET Core Web API for managing students in a training center. It demonstrates CRUD operations, filtering, searching, pagination, status management, and simple reporting without using a database.


## Technologies

- ASP.NET Core Web API (.NET 8)
- Controller-based API
- Dependency Injection
- In-Memory Data (List<Student>)
- Swagger / OpenAPI

## API Features

### Feature 01 – Create Student

- Endpoint: 'POST /api/students'
- Purpose: Creates a new student.
- How to Test:
  - Open Swagger.
  - Expand POST /api/students.
  - Click Try it out.
  - Enter a valid JSON request.
  - Execute the request.
  - Verify the created student is returned.

### Feature 02 – Get All Students

- Endpoint: 'GET /api/students'
- Purpose: Returns all students with optional searching, filtering and pagination.
- How to Test:
  - Execute the endpoint without parameters to retrieve all students.
  - Try searching by name or email.
  - Filter by track name.
  - Filter by active status.
  - Test pagination using 'pageNumber' and 'pageSize'.

### Feature 03 – Get Student By Id

- Endpoint: 'GET /api/students/{id}'
- Purpose: Returns one student by id.
- How to Test:
  - Execute with an existing student id.
  - Verify a student object is returned.
  - Execute with a non existing id.
  - Verify the API returns 404 Not Found.

### Feature 04 – Update Student

- Endpoint: 'PUT /api/students/{id}'
- Purpose: Updates an existing student's information.
- How to Test:
  - Execute with an existing student id.
  - Provide a complete request body.
  - Verify the updated student is returned.
  - Execute using a non-existing id and verify 404 Not Found.

### Feature 05 – Update Student Status

- Endpoint: 'PATCH /api/students/{id}/status'
- Purpose: Activates or deactivates a student.
- How to Test:
  - Execute the endpoint with an existing student id.
  - Send the desired 'IsActive' value.
  - Verify the returned status message.
  - Execute using a non-existing id and verify 404 Not Found.

### Feature 06 – Student Statistics

- Endpoint: 'GET /api/students/stats'
- Purpose: Returns statistics about students.
- How to Test:

  - Execute the endpoint.
  - Verify the response contains:
    - Total students
    - Active students
    - Inactive students
    - Student count grouped by track

### Feature 07 – Delete Student
- Endpoint: 'DELETE /api/students/{id}'
- Purpose: Deletes a student.
- How to Test:
  - Execute with an existing student id.
  - Verify the success response.
  - Execute with a non-existing id.
  - Verify 404 Not Found is returned.

## Sample Data

The project uses an in-memory collection of students seeded at application startup for testing purposes.

## Evidence

- Swagger and Postman screenshots uploaded in the Drive