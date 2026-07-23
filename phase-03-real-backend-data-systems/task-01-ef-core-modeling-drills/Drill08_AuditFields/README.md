# Drill 08 - Audit Fields

## Objective

Practice tracking when records are created and updated using audit fields.

## Implementation

- Added 'CreatedAt' and 'UpdatedAt' fields to the main entities:

  - Student
  - Instructor
  - TrainingTrack
  - Enrollment
- Used 'DateTime.UtcNow' to store audit timestamps.
- 'CreatedAt' is assigned automatically when a new student is created.
- 'UpdatedAt' is assigned automatically whenever a student is updated.
- Audit fields are managed by the application and are not entered by the user.

## Design Decision

I chose to set the audit fields inside the service methods instead of overriding 'SaveChangesAsync'. This keeps the implementation simple while demonstrating how audit information is automatically managed during create and update operations.

## Endpoints

- 'POST /api/students':  Creates a new student and sets 'CreatedAt'.
- 'PUT /api/students/{id}':  Updates an existing student and sets 'UpdatedAt'.

## Result

- New records automatically receive a 'CreatedAt' timestamp.
- Updated records automatically receive an 'UpdatedAt' timestamp.
- Audit fields are stored using UTC time.

## Local Setup

1. Update ConnectionStrings:Conn in appsettings.Development.json.
2. Run: dotnet ef database update
3. Run: dotnet run

Note: Production connection strings are not stored in this repository.