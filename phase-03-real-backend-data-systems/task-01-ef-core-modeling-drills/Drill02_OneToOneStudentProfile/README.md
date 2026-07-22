# Drill 02 - One-to-One Relationship

## Objective

Practice modeling a one-to-one relationship in EF Core between 'Student' and 'StudentProfile'.

## Relationship

- One 'Student' has one 'StudentProfile'.
- One 'StudentProfile' belongs to one 'Student'.

## Implementation

- Created 'Student' and 'StudentProfile' entities.
- Added navigation properties on both entities.
- Configured the one-to-one relationship using Fluent API.
- Added 'StudentId' as the foreign key in 'StudentProfile'.
- Seeded one student with one profile.
- Created the 'AddStudentProfile' migration.

## Result

- The database contains 'Students' and 'StudentProfiles' tables.
- 'StudentProfiles' has a 'StudentId' foreign key.
- The relationship can be queried successfully.

## Local Setup

1. Update ConnectionStrings:DefaultConnection in appsettings.Development.json.
2. Run: dotnet ef database update
3. Run: dotnet run

Note: Production connection strings are not stored in this repository.