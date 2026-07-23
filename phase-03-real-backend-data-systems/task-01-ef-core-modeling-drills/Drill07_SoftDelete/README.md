# Drill 06 - Seed Data

## Objective

Practice seeding realistic data using EF Core 'HasData' so the application can be tested without manually inserting records.

## Implementation

- Seeded 5 students.
- Seeded 2 instructors.
- Seeded 3 training tracks.
- Seeded 5 enrollments.
- Seeded payment summary records.
- Used EF Core 'HasData' to create repeatable seed data without generating duplicates.

## Sample IDs

### Students

- ID : Name           
- 1  : Rowida Gamal   
- 2  : Arwa Ali       
- 3  : Hassan Mohamed 
- 4  : Gamal Hassan   
- 5  : Mona Ali       

### Instructors

- ID : Name         
- 1  : Sama Samy    
- 2  : Sara Mohamed 

### Training Tracks

- ID : Track                 
- 1  : ASP.NET Core          
- 2  : Entity Framework Core 
- 3  : Flutter               

### Enrollments

- ID : Student ID : Track ID 
- 1  : 2          : 1        
- 2  : 1          : 2        
- 3  : 1          : 1        
- 4  : 3          : 3        
- 5  : 4          : 2        

## Result

- The database is populated with sample data after applying migrations.
- Seed data is repeatable and does not create duplicate records.
- Reviewers can use the sample IDs above to test the API endpoints.

## Local Setup

1. Update ConnectionStrings:Conn in appsettings.Development.json.
2. Run: dotnet ef database update
3. Run: dotnet run

Note: Production connection strings are not stored in this repository.