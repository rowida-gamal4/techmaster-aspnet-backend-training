# Drill 10 - Pagination

## Objective

Practice implementing server-side pagination using 'Skip', 'Take', and pagination metadata.

## Implementation

- Added 'pageNumber' and 'pageSize' query parameters.
- Validated that 'pageNumber' must be greater than '0'.
- Validated that 'pageSize' must be between '1' and '50'.
- Created a generic 'PaginationResult<T>' DTO.
- Returned paginated student data along with pagination metadata.
- Used 'Count()' to calculate the total number of records.
- Used 'Skip()' and 'Take()' to return only the required page.

## Pagination Formula

The number of records to skip is calculated using: skip = (pageNumber - 1) - pageSize;


## Endpoint

'GET /api/students?pageNumber=1&pageSize=5'

## Result

- Pagination is performed on the server.
- Only the requested records are returned.
- The response includes metadata needed by the client to build pagination UI.
- Invalid page numbers and page sizes return '400 Bad Request'.

## Local Setup

1. Update ConnectionStrings:Conn in appsettings.Development.json.
2. Run: dotnet ef database update
3. Run: dotnet run

Note: Production connection strings are not stored in this repository.