# Drill 05 - One-to-One Payment Summary

## Objective

Practice modeling a one-to-one relationship between 'Enrollment' and 'PaymentSummary' using EF Core.

## Relationship

- One 'Enrollment' has one 'PaymentSummary'.
- One 'PaymentSummary' belongs to one 'Enrollment'.

## Implementation

- Created the 'PaymentSummary' entity.
- Added 'TotalRequired', 'TotalPaid', 'RemainingAmount', and 'PaymentStatus'.
- Configured a one-to-one relationship with 'Enrollment' using Fluent API.
- Used 'decimal' for all money values.
- Calculated 'RemainingAmount' as a computed property.
- Seeded sample payment summary data.
- Created a GET endpoint to retrieve an enrollment's payment summary.
- Used a DTO to return the response.

## Result

- The database contains a 'PaymentSummaries' table linked to 'Enrollments'.
- Money values are stored as 'decimal'.
- Payment status values ('Pending', 'PartiallyPaid', 'Paid') are stored correctly.
- The API successfully returns an enrollment with its payment summary.

## Local Setup

1. Update ConnectionStrings:Conn in appsettings.Development.json.
2. Run: dotnet ef database update
3. Run: dotnet run

Note: Production connection strings are not stored in this repository.