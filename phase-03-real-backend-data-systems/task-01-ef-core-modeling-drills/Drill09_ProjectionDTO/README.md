# Drill 09 - Projection DTO

## Objective

Practice returning DTOs using LINQ projection instead of exposing EF Core entities directly.

## Implementation

- Created 'StudentListItemDto' for the students list endpoint.
- Created 'TrackDetailsDto' for the track details endpoint.
- Used '.Select()' to project entities directly into DTOs.
- Returned only the fields required by the client.
- Did not return EF Core entities or large navigation graphs.
- Avoided using 'Include' because projection retrieves only the required data.

## Endpoints

- 'GET /api/students':  Returns a list of students using 'StudentListItemDto'.

- 'GET /api/students/deleted':  Returns all students, including soft-deleted records, using 'StudentListItemDto'.

- 'GET /api/tracks/{id}':  Returns track details using 'TrackDetailsDto'.

## Code Snippet

### Student Projection

var students = context.Students.Where(s => !s.IsDeleted).Select(s => new StudentListItemDto
    {
        Id = s.Id,
        FullName = s.FullName,
        Email = s.Email
    }).ToList();


### Track Projection

var track = context.TrainingTracks.Where(t => t.TrackId == id).Select(t => new TrackDetailsDto
    {
        TrackId = t.TrackId,
        TrackName = t.TrackName,
        InstructorName = t.Instructor.FullName
    }).FirstOrDefault();

## Result

- API responses expose only the required fields.
- EF Core entities are not returned directly.
- Projection improves performance by selecting only the needed data.


## Local Setup

1. Update ConnectionStrings:Conn in appsettings.Development.json.
2. Run: dotnet ef database update
3. Run: dotnet run

Note: Production connection strings are not stored in this repository.