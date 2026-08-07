# Task 03 - User Stories & Ownership Rules

## Overview

This task implements role-specific user stories for Admin ,Students and Instructors.

The main goal is to prove that authenticated users can only access data and operations they are authorized to perform.

Ownership is enforced using the current authenticated user identity from JWT claims, rather than trusting user-submitted IDs.


# Admin User Stories

## Endpoint 1 - Create Training Track

Endpoint: 'POST /api/tracks'

- Who can access: Admin
- Why: Admins are responsible for creating and managing training tracks.
- What happens if the wrong role tries: Instructor and Student requests are rejected with 403 Forbidden.
- Authorization rule: Only Admin can create a new training track.

## Endpoint 2 - Assign Instructor to Track

Endpoint: 'PUT /api/tracks/{id}/assign-instructor'

- Who can access: Admin
- Why: Admin controls which instructor is responsible for each training track.
- What happens if the wrong role tries: Instructor and Student requests are rejected with 403 Forbidden.
- Business rule: The instructor being assigned must exist and must be active.
- Ownership rule: Instructors cannot assign themselves or another instructor to tracks.

## Endpoint 3 - View All Enrollments

Endpoint: 'GET /api/enrollments'

- Who can access: Admin
- Why: Admin needs access to enrollment records across the entire training center.
- What happens if the wrong role tries: Student and Instructor requests are rejected with 403 Forbidden.

## Endpoint 4 - Approve / Update Enrollment Status

Endpoint: 'PUT /api/enrollments/{id}/status'

- Who can access: Admin
- Why: Admin manages enrollment approval and status changes.
- What happens if the wrong role tries: Instructor and Student requests are rejected with 403 Forbidden.
- Business rule: Enrollment status transitions are validated.

## Endpoint 5 - Update Payment Status

Endpoint: 'PUT /api/payments/{id}/status'

- Who can access: Admin
- Why: Payment status changes are administrative and affect financial records and enrollment state.
- What happens if the wrong role tries: Instructor and Student requests are rejected with 403 Forbidden.
- Business rules: Only valid payment status transitions are accepted.

## Endpoint 6 - View Revenue Summary

Endpoint: 'GET /api/reports/revenue-summary'

- Who can access: Admin
- Why: Revenue information is sensitive financial information and is part of administrative reporting.
- What happens if the wrong role tries: Instructor and Student requests are rejected with 403 Forbidden.

# Student User Stories

## Endpoint 1 - View My Profile

Endpoint: 'GET /api/student/me'

- Who can access: Student
- Why: Allows a student to view their own profile.
- What happens if the wrong role tries: The request is rejected with 403 Forbidden.
- Ownership rule: The student ID is obtained from the current authenticated user's account. The student cannot provide another student ID.

## Endpoint 2 - View My Enrollments

Endpoint: 'GET /api/student/my-enrollments'

- Who can access: Student
- Why: Allows a student to view their own enrollment history.
- What happens if the wrong role tries: The request is rejected with 403 Forbidden.
- Ownership rule: The student's 'StudentId' is retrieved from the authenticated user. Another student's ID cannot be supplied to access private enrollment data.

## Endpoint 3 - View My Payment History

Endpoint: 'GET /api/student/my-payments'

- Who can access: Student
- Why: Allows a student to view only payments associated with their own enrollments.
- What happens if the wrong role tries: The request is rejected with 403 Forbidden.
- Ownership rule: Payments are filtered using the current student's ID through their enrollments.

## Endpoint 4 - Browse Available Tracks

Endpoint: 'GET /api/tracks/available'

- Who can access: Admin, Instructor, Student
- Why: Allows students to browse tracks that are available for enrollment.
- What happens if the wrong role tries: Unauthorized users are rejected according to the endpoint's authorization configuration.
- Ownership rule: No student ownership check is required because available tracks are not private student data.

## Endpoint 5 - Request Enrollment

Endpoint: 'POST /api/student/enrollment-requests'

- Who can access: Student
- Why: Allows a student to request enrollment in a training track.
- What happens if the wrong role tries: The request is rejected with 403 Forbidden.
- Ownership rule: The student's identity comes from the authenticated user. A student cannot create an enrollment for another student.
- Business rule: A student cannot enroll twice in the same active track.

## Endpoint 6 - Update My Profile

Endpoint: 'PUT /api/student/me'

- Who can access: Student
- Why: Allows a student to update their permitted profile information.
- What happens if the wrong role tries: The request is rejected with 403 Forbidden.
- Ownership rule: The current student's ID is obtained from the authenticated user.
- Allowed fields: Profile information such as name, email, and phone number.
- Protected fields: Students cannot modify their role, payment information, administrative fields, or other users' information.

# Instructor User Stories

## Endpoint 1 - View My Assigned Tracks

Endpoint: 'GET /api/instructor/my-tracks'

- Who can access: Instructor
- Why: Allows an instructor to see only the tracks assigned to them.
- What happens if the wrong role tries: The request is rejected with 403 Forbidden.
- Ownership rule: The instructor ID is obtained from the current authenticated user and used to filter the tracks.
- Additional rule: The instructor cannot use an instructor ID to retrieve another instructor's tracks.

## Endpoint 2 - View Students in My Track

Endpoint: 'GET /api/instructor/tracks/{id}/students'

- Who can access: Admin, Instructor
- Why: Allows instructors to view students enrolled in their assigned tracks.
- What happens if the wrong role tries: A Student receives 403 Forbidden.
- Ownership rule: For an Instructor, the requested track must belong to the current instructor.
- Protection: An instructor cannot access the students of another instructor's track.

## Endpoint 3 - Create Track Session

Endpoint: 'POST /api/instructor/tracks/{id}/sessions'

- Who can access: Instructor
- Why: Allows an instructor to create a session for one of their assigned tracks.
- What happens if the wrong role tries: The request is rejected with 403 Forbidden.
- Ownership rule: The requested track must belong to the current instructor.
- Protected operation: An instructor cannot create sessions for another instructor's track.

## Endpoint 4 - Update Track Session

Endpoint: 'PUT /api/instructor/sessions/{id}'

- Who can access: Instructor
- Why: Allows an instructor to update session information for their own track.
- What happens if the wrong role tries: The request is rejected with 403 Forbidden.
- Ownership rule: The session must belong to a track assigned to the current instructor.
- Protected operation: An instructor cannot modify another instructor's session.

## Endpoint 5 - View Track Progress

Endpoint: 'GET /api/instructor/tracks/{id}/progress'

- Who can access: Instructor
- Why: Allows an instructor to view progress information for their assigned track.
- What happens if the wrong role tries: The request is rejected with 403 Forbidden.
- Ownership rule: The requested track must belong to the current instructor.
- Protected information: An instructor cannot view progress for another instructor's track.

