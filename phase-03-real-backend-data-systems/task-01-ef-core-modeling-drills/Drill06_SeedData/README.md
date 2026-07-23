# Drill 07 - Soft Delete

## Objective

Practice implementing soft delete so records are marked as deleted instead of being permanently removed from the database.

## Implementation

- Added 'IsDeleted' and 'DeletedAt' properties to the 'Student' entity.
- Implemented a 'DELETE' endpoint that marks a student as deleted.
- Deleted students remain in the database.
- The default 'GET' endpoint excludes deleted students.
- Added a separate endpoint to retrieve all students, including deleted records.

## Endpoints

- 'GET /api/students' : Returns only active (non-deleted) students.

- 'GET /api/students/deleted':  Returns all students, including soft-deleted records.

- 'DELETE /api/students/{id}' : Marks the student as deleted by setting:
    - 'IsDeleted = true'
    - 'DeletedAt = DateTime.Now'

## Result

- Students are not permanently removed from the database.
- Soft-deleted students are hidden from normal queries.
- Deleted records can still be viewed for administrative or debugging purposes.


## Local Setup

1. Update ConnectionStrings:Conn in appsettings.Development.json.
2. Run: dotnet ef database update
3. Run: dotnet run

Note: Production connection strings are not stored in this repository.