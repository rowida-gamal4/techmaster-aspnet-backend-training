# DesignDetails.md

## Tables List

- Student
- Instructor
- TrainingTrack
- Enrollment
- Payment



## Fields List

### Student

- StudentId
- FullName
- Email
- PhoneNumber
- CreatedAt
- UpdatedAt
- IsActive
- IsDeleted
- DeletedAt

### Instructor

- InstructorId
- FullName
- Email
- Specialization
- Bio
- IsActive
- CreatedAt

### TrainingTrack

- TrainingTrackId
- Title
- Code
- Description
- Level
- Capacity
- StartDate
- EndDate
- Status
- InstructorId
- CreatedAt
- IsDeleted

### Enrollment

- EnrollmentId
- StudentId
- TrainingTrackId
- EnrollmentDate
- Status
- ProgressPercentage
- FinalResult
- CreatedAt
- UpdatedAt

### Payment

- PaymentId
- EnrollmentId
- Amount
- PaymentMethod
- PaymentDate
- PaymentStatus
- ReferenceNumber
- Notes

---------------

## Primary Keys

- Student => StudentId
- Instructor => InstructorId
- TrainingTrack => TrainingTrackId
- Enrollment => EnrollmentId
- Payment => PaymentId

--------------------

## Foreign Keys

- TrainingTrack.InstructorId => Instructor.InstructorId
- Enrollment.StudentId => Student.StudentId
- Enrollment.TrainingTrackId => TrainingTrack.TrainingTrackId
- Payment.EnrollmentId => Enrollment.EnrollmentId

--------------------

## Relationship Explanation

- One Instructor can teach many TrainingTracks.
- One TrainingTrack belongs to one Instructor.
- One Student can have many Enrollments.
- One TrainingTrack can have many Enrollments.
- Each Enrollment belongs to one Student and one TrainingTrack.
- One Enrollment can have many Payments.
- Each Payment belongs to one Enrollment.




### Business Questions Supported by the Database

1. Which students are enrolled in a specific track?
- Tables Used: Student, Enrollment, TrainingTrack.
- Explanation: The Enrollment table links students to training tracks, allowing the database to retrieve all students enrolled in a selected track.


2. Which tracks have available seats?
- Tables Used: TrainingTrack, Enrollment.
- Explanation: The database compares each track's 'Capacity' with the number of enrollments to determine whether seats are still available.


3. Which enrollments are unpaid?
- Tables Used: Enrollment, Payment.
- Explanation: The database checks whether an enrollment has any successful payments or whether the total paid amount is less than the required amount.


4. How much revenue did each track generate?
- Tables Used: TrainingTrack, Enrollment, Payment.
- Explanation: Payments are linked to enrollments, and enrollments are linked to training tracks, making it possible to calculate the total revenue for each track.


5. Which instructor has the highest workload?
- Tables Used: Instructor, TrainingTrack, Enrollment.
- Explanation: The workload can be measured by counting the number of enrollments across all tracks assigned to each instructor.


6. Which students have active enrollments?
- Tables Used: Student, Enrollment.
- Explanation: The database filters enrollments by their status (for example, "Active") and returns the corresponding students.


7. Which tracks start this month?
- Tables Used: TrainingTrack.
- Explanation: The database filters training tracks using the 'StartDate' field to return those beginning during the current month.


8. What is the payment history for an enrollment?
- Tables Used: Enrollment, Payment.
- Explanation: Since each payment is linked to an enrollment, the database can return all payment records associated with a specific enrollment.


9. Which tracks are full?
- Tables Used: TrainingTrack, Enrollment.
- Explanation: The database compares the number of enrollments with the track's capacity to identify tracks that have reached their maximum capacity.


10. How many enrollments exist by status?
- Tables Used: Enrollment.
- Explanation: The database groups enrollments by the 'Status' field (such as Active, Completed, or Cancelled) and counts the number of enrollments in each category.
