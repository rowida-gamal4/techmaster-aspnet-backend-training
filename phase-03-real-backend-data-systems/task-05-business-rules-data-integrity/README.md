# Task 05 – Business Rules & Data Integrity

## Overview

This task focuses on implementing real business rules inside the service layer instead of relying only on database constraints. The API validates business operations before saving data to ensure the system behaves like a production application.

The implemented rules return clear error messages with --400 Bad Request-- responses for invalid operations and prevent inconsistent data from being stored.

In addition to the required rules, the project already contains extra endpoints from previous tasks. Business rules are enforced inside the corresponding service classes.

# Student Rules

### Implemented Rules
- Email must be unique.
- FullName is required through model validation.
- Students are soft deleted (IsDeleted = true) instead of being permanently removed.
- Deleted students are excluded from normal list endpoints.
- Deleted students cannot receive new enrollments.
- Inactive students cannot receive new enrollments.
- Updating a student checks for duplicate email addresses.

### Implemented In
- StudentService.CreateStudent()
- StudentService.UpdateStudent()
- StudentService.DeleteStudent()
- StudentService.GetAllStudents()
- EnrollmentService.CreateEnrollment()

# Track Rules

### Implemented Rules

- Title is required through model validation.
- Code must be unique.
- Capacity must be greater than zero.
- StartDate must be before EndDate.
- Instructor must exist before creating or updating a track.
- Track capacity cannot be exceeded.
- Closed tracks cannot accept new enrollments.
- Tracks with active enrollments cannot be deleted.
- Tracks use soft delete.

### Implemented In

- TracksService.CreateTrack()
- TracksService.UpdateTrack()
- TracksService.DeleteTrack()
- EnrollmentService.CreateEnrollment()

# Enrollment Rules

### Implemented Rules

- A student cannot have two active enrollments in the same track.
- New enrollments start with --Pending-- status.
- Closed tracks reject new enrollments.
- Track capacity counts only Active enrollments.
- Cancelled enrollments do not consume capacity.
- Completed enrollments cannot be modified.
- Deleted or inactive students cannot enroll.

### Implemented In

- EnrollmentService.CreateEnrollment()
- EnrollmentService.UpdateEnrollmentStatus()


# Payment Rules

### Implemented Rules

- Payment amount must be greater than zero.
- Payment cannot exceed the remaining balance.
- Payment status must be one of:

  - Pending
  - Paid
  - Failed
  - Refunded
- Only --Paid-- payments are included in revenue reports.
- Failed payments do not activate enrollments.
- Paid payments activate Pending enrollments.

### Implemented In

- PaymentService.CreatePayment()
- PaymentService.UpdatePaymentStatus()
- Revenue reporting methods


# Validation Strategy

Business rules are enforced inside the --Service Layer-- rather than the controllers.

The controllers are responsible only for receiving requests and returning responses, while all business validation is centralized in the services. This approach keeps the API maintainable, testable, and aligned with common ASP.NET Core architecture.


# Evidence Included

The Drive Includes:

- Successful Swagger/Postman requests.
- Failed business rule scenarios.
- Updated Postman collection.

# Result

The Training Center API now protects data integrity by preventing invalid operations before they reach the database. The application enforces real business rules for Students, Tracks, Enrollments, and Payments while returning clear, user-friendly validation messages for invalid requests.
