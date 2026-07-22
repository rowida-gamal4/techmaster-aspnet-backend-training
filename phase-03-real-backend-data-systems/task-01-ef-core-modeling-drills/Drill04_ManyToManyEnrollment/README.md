# Drill 04 - Many-to-Many via Join Entity

## Objective

Practice modeling a many-to-many relationship using a join entity with additional business data.

## Relationship

- A 'Student' can enroll in many 'TrainingTracks'.
- A 'TrainingTrack' can have many 'Students'.
- The 'Enrollment' entity stores the relationship and additional information.

## Implementation

- Created the 'Enrollment' entity.
- Added 'StudentId' and 'TrainingTrackId' foreign keys.
- Added 'Status', 'EnrollmentDate', and optional 'FinalGrade'.
- Added navigation properties to all related entities.
- Created the 'AddEnrollments' migration.
- Used 'Include()' and 'ThenInclude()' to retrieve related data.
- Created DTOs to return student enrollments and track students without circular references.

## Result

- The database contains an 'Enrollments' table linking students and tracks.
- Student and track information can be retrieved through the join entity.
- API endpoints return enrollment details successfully.

## Local Setup

1. Update ConnectionStrings:DefaultConnection in appsettings.Development.json.
2. Run: dotnet ef database update
3. Run: dotnet run

Note: Production connection strings are not stored in this repository.