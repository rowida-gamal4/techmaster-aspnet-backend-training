# Task 01 - Drill 01: DbContext & First Migration

## Objective

Learn the basics of Entity Framework Core by creating the first database model, generating a migration, and creating the database table.

## What Was Implemented

- Created a 'Student' entity.
- Created 'AppDbContext'.
- Added 'DbSet<Student>'.
- Registered 'AppDbContext' in 'Program.cs'.
- Configured the SQL Server connection string.
- Created the first migration:
  dotnet ef migrations add InitialStudentSchema
- Applied the migration:
  dotnet ef database update


## DbContext and DbSet

'AppDbContext' is the main class that manages the database connection and tracks entity changes.

'DbSet<Student>' represents the  Students table and allows querying and saving 'Student' entities.

## Result

After applying the migration:
- The database was created successfully.
- The Students table was generated.
- The API runs successfully without EF Core errors.

## Evidence

This task includes Screenshots of database table + migration files

## Local Setup

1. Update ConnectionStrings:DefaultConnection in appsettings.Development.json.
2. Run: dotnet ef database update
3. Run:  dotnet run

Note: Production connection strings are not stored in this repository.