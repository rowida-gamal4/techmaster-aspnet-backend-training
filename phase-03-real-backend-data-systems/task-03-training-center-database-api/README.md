# Task 03 - DTOs, Services & Response Shape

## Overview

This task implements the Training Center REST API using ASP.NET Core and Entity Framework Core. The API follows a layered architecture where controllers delegate business logic to services and all responses are returned using DTOs instead of EF Core entities.

## Implemented Features

- Student CRUD with soft delete.
- Instructor CRUD and instructor tracks.
- Training Track CRUD with filtering.
- Enrollment management with validation.
- Payment management with filtering and status updates.
- Reporting endpoints for dashboard, revenue, unpaid enrollments and track capacity.

## API Design

- Controllers contain minimal logic.
- Business logic is implemented inside services.
- EF Core 'DbContext' is used only in the service layer.
- Request and response DTOs are used for all endpoints.
- A standard response object ('GeneralResponseDto') is returned for every request.

## Technologies

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger
- Postman

## Testing

The API was tested using Swagger and Postman. Success and failure cases were verified for the implemented endpoints.
