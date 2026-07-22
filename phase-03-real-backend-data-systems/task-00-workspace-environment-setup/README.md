# Task 00 – Workspace & Environment Setup

## Objective

Prepare the Phase 03 ASP.NET Core Web API workspace before implementing the Training Center database system.

## Phase 03 Local Setup
1. Install SQL Server or use a remote SQL Server database.
2. Update ConnectionStrings:DefaultConnection locally.
3. Run: dotnet ef migrations add InitialTrainingCenterSchema
4. Run: dotnet ef database update
5. Run the API and open Swagger.

## Project Setup

1. Create the ASP.NET Core Web API project.

2. Install the required Entity Framework Core packages.
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design

## Project Structure
TrainingCenter.Api
    Controllers
    Data
        AppDbContext.cs
    Entities
    DTOs
        Students
        Tracks
        Enrollments
        Payments
        Reports
    Services
    Common
        ApiResponse.cs
        PaginationResult.cs
    Program.cs
    appsettings.json
    appsettings.Development.json

## Local Configuration

Update the connection string in appsettings.Development .json with your local SQL Server configuration.

{
   "ConnectionStrings": {
    "Conn":"Server=localhost;Database=TechMasterTask00 ;User Id=sa;Password=YOUR_PASSWORD;TrustServerCertificate=True"
  }
}

- Replace 'YOUR_PASSWORD' with your own local SQL Server password.


## Running the Project

Run the API using:
- dotnet run

After the application starts, open Swagger in your browser.

## Status

- ASP.NET Core Web API project created.
- Entity Framework Core packages installed.
- AppDbContext registered.
- Local SQL Server connection configured.
- Workspace prepared for Phase 03 development.

## Notes
- I added a temporary empty file 'getkeep' to force the empty folders to appear in github