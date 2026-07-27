# Phase 03 – Real Backend Data Systems

## Overview

This phase focuses on building a production-style ASP.NET Core Web API using Entity Framework Core. The project demonstrates database modeling, relationships, business rules, reporting queries, code refactoring, and production deployment. Instead of building isolated CRUD endpoints, the project applies real backend practices such as soft delete, validation, business logic, reporting, and deployment to a live hosting environment.

The solution was extended beyond the required drills to resemble a real backend application. Additional endpoints were added where appropriate, while the required training tasks remain clearly identified by comments indicating their corresponding query or task numbers.


# Technologies

- ASP.NET Core 8 Web API
- Entity Framework Core 8
- SQL Server
- LINQ
- Swagger / OpenAPI
- Postman
- Dependency Injection
- MonsterASP.NET Hosting
- Remote SQL Server Database


# Project Structure

- Task 00 – Workspace & Environment Setup
- Task 01 – EF Core Modeling Drill Pack
- Task 02 – CRUD API Endpoints
- Task 03 – EF Core Query Drill Pack
- Task 04 – Reports & Dashboard Queries
- Task 05 – Business Rules & Data Integrity
- Task 06 – Production Hosting & Remote Database
- Task 07 – EF Core/API Refactor Pack


# Main Features

- Student Management
- Instructor Management
- Training Track Management
- Enrollment Management
- Payment Management
- Dashboard & Reporting Endpoints
- Business Rule Validation
- Soft Delete Support
- Pagination
- Filtering
- Searching
- Production Deployment

# Implemented Business Rules

### Student Rules

- Unique email addresses.
- Soft delete instead of hard delete.
- Deleted students are excluded from normal queries.
- Inactive students cannot create new enrollments.
- Deleted students cannot create new enrollments.

### Track Rules

- Instructor must exist.
- Track capacity must be greater than zero.
- Track code must be unique.
- Start date must be before end date.
- Full tracks reject new enrollments.
- Closed tracks reject new enrollments.

### Enrollment Rules

- Duplicate active enrollments are prevented.
- Capacity ignores cancelled enrollments.
- Completed enrollments cannot be modified.
- Completed enrollments cannot be cancelled.

### Payment Rules

- Payment amount must be positive.
- Overpayments are rejected.
- Only paid payments are included in revenue reports.
- Failed payments do not activate enrollments.


# Reporting Endpoints

Implemented management reports include:

- Revenue Summary
- Revenue by Track
- Top Tracks
- Instructor Workload
- Students Without Payments
- Advanced Enrollment Filter
- Dashboard Summary


# Production Deployment

The API has been successfully deployed to a live hosting environment.

Production deployment includes:

- Remote SQL Server database
- HTTPS enabled
- Live ASP.NET Core Web API
- Live Swagger documentation
- Remote Entity Framework Core migrations
- Secure production configuration
- Secrets excluded from GitHub


# Refactor Pack

The original bad EF Core code was preserved and a fully refactored version was implemented.

Improvements include:

- Service layer extraction
- DTO-based requests and responses
- Async EF Core operations
- Pagination
- Projection
- Business rule validation
- Proper HTTP status codes
- Soft delete
- Cleaner architecture
- Improved maintainability

-

# Testing

The project was tested using:

- Swagger
- Postman
- SQL Server

Validation scenarios include both successful requests and invalid business rule cases.



# Notes

- The project contains additional endpoints beyond the required training tasks to better simulate a real production backend.
- Every required query from the drill pack is clearly marked inside the code with its corresponding query number, making it easy to review the required implementations separately from the extended functionality.
- Production secrets and database credentials are not committed to the repository.
- Deployment evidence, screenshots, and testing results are included with the task submissions.


# Learning Outcomes

By completing this phase, the project demonstrates practical experience with:

- Entity Framework Core modeling
- LINQ query composition
- RESTful API design
- Business rule implementation
- Data integrity
- Reporting queries
- Service-based architecture
- Production deployment
- Remote database management
- Backend refactoring and maintainability
