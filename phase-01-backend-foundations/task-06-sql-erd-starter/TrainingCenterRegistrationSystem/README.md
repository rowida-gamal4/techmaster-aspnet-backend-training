# Task 06 - SQL & ERD Starter

## Selected Scenario

Training Center Registration System



## Main Tables

- Students
- Instructors
- Tracks
- Registrations
- Payments



## Relationships

- One Instructor can teach many Tracks.
- One Student can have many Registrations.
- One Track can have many Registrations.
- One Registration has one Payment.



## Primary Keys

- StudentId
- InstructorId
- TrackId
- RegistrationId
- PaymentId



## Foreign Keys

- Tracks.InstructorId -> Instructors.InstructorId
- Registrations.StudentId -> Students.StudentId
- Registrations.TrackId -> Tracks.TrackId
- Payments.RegistrationId -> Registrations.RegistrationId



## Why I Designed It This Way

I separated the data into different tables so each table stores its own information. Students, instructors, and tracks are independent tables, while registrations connect students with tracks. Payments are stored in a separate table because every registration has its own payment information. Using primary and foreign keys keeps the relationships clear and helps organize the database in a simple and efficient way.


## SQL Queries in [SqlQuerie] file 

The SQL file includes the following queries:

1. Select all students.
2. Select all tracks.
3. Select students registered in a specific track.
4. Count students per track.
5. Select unpaid registrations.
6. Select tracks by instructor.
7. Select registrations with payment status using JOIN.
8. Select tracks starting after a specific date.
9. Count tracks per instructor.
10. Select student registration history.



## Conclusion

In this task, I created the ERD, built the database tables, added the relationships using primary and foreign keys, inserted sample data, and wrote the required SQL queries. The database structure supports the registration process and the required reports.
