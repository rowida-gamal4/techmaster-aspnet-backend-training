# Task 01 - EF Core Modeling Drill Pack

## Objective

Practice the core concepts of Entity Framework Core by building different database relationships, creating migrations, seeding data, and exposing data through simple Web API endpoints.

## Drills Completed

- Drill 01 - DbContext & First Migration
- Drill 02 - One-to-One Relationship
- Drill 03 - One-to-Many Relationship
- Drill 04 - Many-to-Many Using Join Entity
- Drill 05 - Payment Summary (One-to-One)
- Drill 06 - Seed Data
- Drill 07 - Soft Delete
- Drill 08 - Audit Fields
- Drill 09 - Projection DTO
- Drill 10 - Pagination

## What I Learned

- Creating and configuring 'DbContext' and 'DbSet'.
- Building one-to-one, one-to-many, and many-to-many relationships.
- Creating and applying EF Core migrations.
- Seeding sample data with 'HasData'.
- Implementing soft delete.
- Managing audit fields ('CreatedAt' and 'UpdatedAt').
- Returning DTOs using LINQ projection.
- Implementing server-side pagination.

## How to Run

1. Update the development connection string in 'appsettings.Development.json'.
2. Run 'dotnet ef database update'.
3. Run 'dotnet run'.
4. Open Swagger and test the endpoints.

## Notes

Each drill is implemented in its own project with its own migration and README. Database screenshots and API responses are included as evidence for the completed drills.

## Local Setup

1. Update ConnectionStrings:Conn in appsettings.Development.json.
2. Run: dotnet ef database update
3. Run: dotnet run

Note: Production connection strings are not stored in this repository.