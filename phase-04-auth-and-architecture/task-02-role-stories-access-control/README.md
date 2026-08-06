# Task 02 - Role Stories & Access Control

This task protects the API endpoints based on three roles:

- Admin
- Instructor
- Student

Every protected endpoint has an authorization rule that defines who can access it, why they can access it, and what happens when the wrong role tries to access it.

# Endpoint 1 - Get Students

'GET /api/students'

- Who can access: Admin, Instructor
- Why: Admin needs to manage and view students. Instructor can view students related to their assigned tracks.
- What happens if wrong role tries: Student receives '403 Forbidden'.

# Endpoint 2 - Get Student By ID

'GET /api/students/{id}'

- Who can access: Admin, Student
- Why: Admin can view any student. Student can view only their own profile.
- What happens if wrong role tries: Student trying to access another student's profile receives '403 Forbidden'. Other unauthorized roles also receive '403 Forbidden'.

# Endpoint 3 - Create Student

'POST /api/students'

- Who can access: Admin
- Why: Student management is an Admin responsibility.
- What happens if wrong role tries: Instructor or Student receives '403 Forbidden'.

# Endpoint 4 - Update Student

'PUT /api/students/{id}'

- Who can access: Admin
- Why: Admin has full access to student management.
- What happens if wrong role tries: Instructor or Student receives '403 Forbidden'.

# Endpoint 5 - Delete Student

'DELETE /api/students/{id}'

- Who can access: Admin
- Why: Deleting students is an administrative operation.
- What happens if wrong role tries: Instructor or Student receives '403 Forbidden'.

# Endpoint 6 - Get Student Enrollment History

'GET /api/students/{id}/enrollments'

- Who can access: Admin, Student
- Why: Admin can view enrollment history. Student can view their own enrollment history.
- What happens if wrong role tries: Student trying to access another student's history receives '403 Forbidden'.

# Endpoint 7 - Get Instructors

'GET /api/instructors'

- Who can access: Admin
- Why: Instructor management is an Admin responsibility.
- What happens if wrong role tries: Instructor or Student receives '403 Forbidden'.

# Endpoint 8 - Get Instructor By ID

'GET /api/instructors/{id}'

- Who can access: Admin, Instructor
- Why: Admin can view any instructor. Instructor can view their own profile.
- What happens if wrong role tries: Instructor trying to access another instructor's profile receives '403 Forbidden'. Student receives '403 Forbidden'.

# Endpoint 9 - Get Instructor Tracks

'GET /api/instructors/{id}/tracks'

- Who can access: Admin, Instructor
- Why: Admin can view any instructor's tracks. Instructor can view their own assigned tracks.
- What happens if wrong role tries: Instructor trying to view another instructor's tracks receives '403 Forbidden'. Student receives '403 Forbidden'.

# Endpoint 10 - Create Instructor

'POST /api/instructors'

- Who can access: Admin
- Why: Admin manages instructor accounts.
- What happens if wrong role tries: Instructor or Student receives '403 Forbidden'.

# Endpoint 11 - Update Instructor

'PUT /api/instructors/{id}'

- Who can access: Admin, Instructor for their own profile
- Why: Admin can update any instructor. Instructor can update only their own profile.
- What happens if wrong role tries: Instructor trying to update another instructor receives '403 Forbidden'. Student receives '403 Forbidden'.

# Endpoint 12 - Delete Instructor

'DELETE /api/instructors/{id}'

- Who can access: Admin
- Why: Deleting instructors is an administrative operation.
- What happens if wrong role tries: Instructor or Student receives '403 Forbidden'.

# Endpoint 13 - Get Tracks

'GET /api/tracks'

- Who can access: Admin, Instructor, Student
- Why: Admin manages tracks. Instructor needs to see assigned tracks. Student needs to see available tracks.
- What happens if wrong role tries: An unauthenticated user receives '401 Unauthorized'.

# Endpoint 14 - Get Track By ID

'GET /api/tracks/{id}'

- Who can access: Admin, Instructor, Student
- Why: Admin can view all tracks. Instructor can view assigned tracks. Student can view available tracks.
- What happens if wrong role tries: An unauthenticated user receives '401 Unauthorized'.

# Endpoint 15 - Create Track

'POST /api/tracks'

- Who can access: Admin
- Why: Track management is Admin-owned.
- What happens if wrong role tries: Instructor or Student receives '403 Forbidden'.

# Endpoint 16 - Update Track

'PUT /api/tracks/{id}'

- Who can access: Admin, Instructor for their assigned track
- Why: Admin can update any track. Instructor can update only a track assigned to them, with limited update permissions.
- What happens if wrong role tries: Instructor trying to update another instructor's track receives '403 Forbidden'. Student receives '403 Forbidden'.

# Endpoint 17 - Delete Track

'DELETE /api/tracks/{id}'

- Who can access: Admin
- Why: Track deletion is an administrative operation.
- What happens if wrong role tries: Instructor or Student receives '403 Forbidden'.

# Endpoint 18 - Get Track Students

'GET /api/tracks/{id}/students'

- Who can access: Admin, Instructor for their own track
- Why: Admin can view students in all tracks. Instructor can view students enrolled in their assigned tracks.
- What happens if wrong role tries: Instructor trying to access another instructor's track receives '403 Forbidden'. Student receives '403 Forbidden'.

# Endpoint 19 - Get All Enrollments

'GET /api/enrollments'

- Who can access: Admin, Instructor
- Why: Admin can view all enrollments. Instructor can view enrollments belonging to their own tracks.
- What happens if wrong role tries: Student receives '403 Forbidden'.

# Endpoint 20 - Get Enrollment By ID

'GET /api/enrollments/{id}'

- Who can access: Admin, Instructor for their own track, Student for their own enrollment
- Why: Each role can access enrollment information within its own business boundary.
- What happens if wrong role tries: A user trying to access an enrollment outside their allowed scope receives '403 Forbidden'.

# Endpoint 21 - Create Enrollment

'POST /api/enrollments'

- Who can access: Admin, Student for themselves
- Why: Admin can enroll students. Student can create an enrollment only for themselves and cannot enroll another student.
- What happens if wrong role tries: Student trying to enroll another student receives '403 Forbidden'. Instructor receives '403 Forbidden'.

# Endpoint 22 - Update Enrollment Status

'PUT /api/enrollments/{id}/status'

- Who can access: Admin
- Why: Enrollment status management is an administrative operation.
- What happens if wrong role tries: Instructor or Student receives '403 Forbidden'.

# Endpoint 23 - Get Enrollment Payments

'GET /api/enrollments/{id}/payments'

- Who can access: Admin, Student for their own enrollment
- Why: Admin can view payment history. Student can view payment history belonging to their own enrollment.
- What happens if wrong role tries: Student trying to access another student's enrollment payments receives '403 Forbidden'. Instructor receives '403 Forbidden'.

# Endpoint 24 - Get All Payments

'GET /api/payments'

- Who can access: Admin, Student for their own payments
- Why: Admin has full access to payment records. Student can view only their own payment history.
- What happens if wrong role tries: Student receives only their own payments. Instructor receives '403 Forbidden'.

# Endpoint 25 - Create Payment

'POST /api/payments'

- Who can access: Admin
- Why: Payment creation is handled as an administrative/payment-management operation.
- What happens if wrong role tries: Instructor or Student receives '403 Forbidden'.

# Endpoint 26 - Update Payment Status

'PUT /api/payments/{id}/status'

- Who can access: Admin
- Why: Payment status changes are Admin-only.
- What happens if wrong role tries: Instructor or Student receives '403 Forbidden'.

# Endpoint 27 - Available Tracks Report

'GET /api/reports/tracks-with-available-seats'

- Who can access: Admin, Instructor
- Why: Admin can view all available tracks. Instructor can use track availability information for their work.
- What happens if wrong role tries: Student receives '403 Forbidden'.

# Endpoint 28 - Unpaid Enrollments Report

'GET /api/reports/unpaid-enrollments'

- Who can access: Admin , Instructor
- Why: This report exposes payment-related information and is administrative.
- What happens if wrong role tries: Student receives '403 Forbidden'.

# Endpoint 29 - Revenue Summary Report

'GET /api/reports/revenue-summary'

- Who can access: Admin
- Why: Revenue information is confidential administrative information.
- What happens if wrong role tries: Instructor or Student receives '403 Forbidden'.

# Endpoint 30 - Revenue By Track Report

'GET /api/reports/revenue-by-track'

- Who can access: Admin
- Why: This report exposes financial information.
- What happens if wrong role tries: Instructor or Student receives '403 Forbidden'.

# Endpoint 31 - Top Tracks Report

'GET /api/reports/top-tracks'

- Who can access: Admin, Instructor for their own tracks
- Why: Admin can see all track performance. Instructor can use track performance information for their own work.
- What happens if wrong role tries: Student receives '403 Forbidden'.

# Endpoint 32 - Instructor Workload Report

'GET /api/reports/instructor-workload'

- Who can access: Admin , Instructor for their own tracks
- Why: This report contains information about instructor workload across the system.
- What happens if wrong role tries: Student receives '403 Forbidden'.

# Endpoint 33 - Students Without Payments Report

'GET /api/reports/students-without-payments'

- Who can access: Admin
- Why: This report exposes payment-related information and is administrative.
- What happens if wrong role tries: Instructor or Student receives '403 Forbidden'.

# Endpoint 34 - Dashboard Summary

'GET /api/reports/dashboard-summary'

- Who can access: Admin
- Why: The dashboard contains system-wide statistics, including revenue and unpaid payment information.
- What happens if wrong role tries: Instructor or Student receives '403 Forbidden'.

# Endpoint 35 - Track Capacity Report

'GET /api/reports/track-capacity'

- Who can access: Admin, Instructor for their own tracks
- Why: Admin can view all track capacity information. Instructor can view capacity information for assigned tracks.
- What happens if wrong role tries: Student receives '403 Forbidden'.

# Audit Logs

Audit logs are administrative and are not implemented as part of the current phase.

- Admin: Full access
- Instructor: Own operations only (optional)
- Student: No access

# Access Matrix

This matrix is the source of truth for authorization testing.

| Endpoint Group   | Admin              | Instructor                          | Student                  | Notes                                       |

| Students CRUD    | Full access        | Read students in own tracks only    | Own profile only         | No public student list                      |
| Instructors CRUD | Full access        | Own profile only                    | No access                | Instructor cannot create another instructor |
| Tracks           | Full access        | Assigned tracks read/update limited | Read available tracks    | Track management is Admin-owned             |
| Enrollments      | Full access        | Read own track enrollments          | Own enrollments only     | Student cannot enroll another student       |
| Payments         | Full access        | No revenue access                   | Own payment history only | Payment status is Admin-only                |
| Reports          | Full admin reports | Own track reports                   | No admin reports         | Role-specific reporting                     |
| Audit Logs       | Full access        | Own operations optional             | No access                | Audit is administrative                     |

# Authorization Behavior

The API uses JWT authentication and role-based authorization.

- 401 Unauthorized means the request does not contain a valid authentication token.
- 403 Forbidden means the user is authenticated but their role does not have permission to access the endpoint or resource.
- Admin has the highest level of access.
- Instructor access is limited to their own profile, assigned tracks, and related track data.
- Student access is limited to their own profile, enrollments, and payment history.

The role is read from the authenticated user's JWT claims and is used to enforce access-control rules.
