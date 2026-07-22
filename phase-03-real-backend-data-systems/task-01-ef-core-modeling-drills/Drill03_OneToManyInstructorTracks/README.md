# Drill 03 - One-to-Many Relationship

## Objective

Practice creating a one-to-many relationship between 'Instructor' and 'TrainingTrack'.

## Relationship

- One 'Instructor' can teach many 'TrainingTracks'.
- Each 'TrainingTrack' belongs to one 'Instructor'.

## Implementation

- Created 'Instructor' and 'TrainingTrack' entities.
- Added 'InstructorId' as the foreign key.
- Configured the relationship using Fluent API.
- Seeded instructors and training tracks.
- Created a GET endpoint to return an instructor with their tracks.
- Used DTOs to avoid circular reference issues.

## Result

- The database contains 'Instructors' and 'TrainingTracks'.
- 'TrainingTracks' has an 'InstructorId' foreign key.
- The endpoint returns an instructor with all assigned tracks.

## Local Setup

1. Update ConnectionStrings:DefaultConnection in appsettings.Development.json.
2. Run: dotnet ef database update
3. Run: dotnet run

Note: Production connection strings are not stored in this repository.