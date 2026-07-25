# Task 04 - Querying, Filtering, Pagination & Reports

## Overview

For this task, the Training Center API was extended with production-style querying, filtering, pagination, and reporting features using Entity Framework Core.

## Note
The project was not built from scratch for Task 04. Instead, the API developed during Task 03 was enhanced and updated to support the required query specifications while keeping the project closer to a real-world backend application.

So the project contains additional CRUD and business endpoints beyond the required 20 queries. These endpoints were implemented in Task 03 and were intentionally kept because they represent functionality expected in a complete Training Center API.

To make the required queries easy to review, every query implementation is marked inside the service layer using comments 

## Where To Find Them 

- Queries 7 , 12 , 15 , 16 ,17 ,18 , 20 => ReportService.cs
- Queries 1 , 2 , 3 => StudentService.cs 
- Queries 8 , 9 , 10 , 11 , 14 , 19 EnrollmentService.cs 
- Queries 4 , 5 , 6 => TrackService.cs
- Queries 13 => PaymentService.cs

# Five Important Query Explanations

## Query 03 – Paged Students List
- Endpoint: GET /api/students?pageNumber=1&pageSize=10
- Purpose: Returns students using server-side pagination instead of returning all records.
- EF Core Concepts: Count() - Skip() - Take() - Projection with Select()
- Why it is important: Pagination is one of the most common requirements in production APIs. Instead of returning every student, only the requested page is retrieved, improving performance and reducing network traffic.

## Query 07 – Tracks With Available Seats

- Endpoint: GET /api/reports/tracks-with-available-seats
- Purpose: Returns tracks that still have available seats by comparing each track's capacity with its active enrollment count.
- EF Core Concepts: Where() - Count() - Projection with Select()
- Why it is important: This query demonstrates how business rules can be implemented using EF Core to provide useful operational reports rather than simple CRUD operations.

## Query 13 – Payments By Date Range

- Endpoint: GET /api/payments?from=2026-07-01&to=2026-07-31
- Purpose: Returns payments made within a specified date range.
- EF Core Concepts: Conditional Where() - IQueryable composition - Date filtering
- Why it is important: Date filtering is commonly used in financial systems and reporting dashboards. The endpoint validates the supplied dates before executing the query.

## Query 16 – Top Tracks By Enrollment

- Endpoint: GET /api/reports/top-tracks
- Purpose: Returns the five tracks with the highest number of active enrollments.
- EF Core Concepts: GroupBy() - OrderByDescending() - Count() - Take()
- Why it is important: This query demonstrates aggregation and ranking, allowing administrators to quickly identify the most popular training tracks.

## Query 20 – Dashboard Summary

- Endpoint: GET /api/reports/dashboard-summary
- Purpose: Returns the main dashboard statistics in a single response.
- EF Core Concepts: Count() - Sum() - Any() - Multiple aggregate queries
- Why it is important: Dashboards typically require information from several tables. This endpoint combines multiple aggregate queries into one response, reducing the number of API calls needed by the client application.


# Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- LINQ
- Swagger
- Postman

# Notes

- All responses use DTOs instead of exposing Entity Framework entities.
- Filtering is implemented using conditional IQueryable composition.
- Reports use LINQ aggregation functions such as Count, Sum, GroupBy, Any, and Select.
- Swagger was used to verify endpoints.
- Postman was used to test success and failure scenarios.
- The API includes additional endpoints implemented during Task 03 to resemble a real production project. The required Task 04 queries are clearly identified with numbered comments (Query 01 through Query 20) inside the service layer for easy review.


# Postman Collection +  Screenshots
in the drive 