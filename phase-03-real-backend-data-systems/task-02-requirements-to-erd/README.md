# Task 02 - Requirements to ERD

## Objective

Convert the provided business requirements into a database design before implementation.

## What was completed

- Designed the database entities.
- Identified all fields for each entity.
- Defined primary and foreign keys.
- Modeled one-to-many relationships.
- Created an ERD diagram.
- Identified business rules.
- Documented business questions supported by the database.

## Design Decisions

- Integer keys are used for all primary keys.
- Foreign keys are used to enforce relationships.
- Decimal is used for monetary values.
- Audit fields such as CreatedAt and UpdatedAt are included where needed.
- Soft delete is supported using IsDeleted and DeletedAt.
- Email addresses should be unique for students and instructors.
- Payments are stored separately from enrollments to support multiple payments per enrollment.

## Files

- Task02RequirementsToERD.pdf
- DesignDetails.md

## Result

The ERD provides the database blueprint for the future ASP.NET Web API implementation.