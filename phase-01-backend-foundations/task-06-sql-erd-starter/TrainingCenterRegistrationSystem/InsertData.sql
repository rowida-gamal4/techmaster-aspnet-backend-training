use TrainingCenterManagementSystem;
go 

insert into Students
(FullName, Email, PhoneNumber, CreatedAt)
values
('Rowida','rowida@gmail.com','01122055628','2026-07-01'),
('Gamal','gamal@gmail.com','01122055629','2026-07-02'),
('Hassan','hassan@gmail.com','01122055627','2026-07-03'),
('Arwa','arwa@gmail.com','01122055626','2026-07-04'),
('Ali','ali@gmail.com','01122055625','2026-07-05');

insert into Instructors
(FullName, Email, Specialization)
values
('Mohamed','mohamed@gmail.com','ASP.NET'),
('Ahmed','ahmed@gmail.com','SQL Server'),
('Sara','sara@gmail.com','Flutter');

insert into Tracks
(Title, Description, DurationWeeks, StartDate, InstructorId)
values
('ASP.NET Backend','Web API and EF Core',12,'2026-08-01',1),
('SQL Server','Database Design and SQL',8,'2026-08-10',2),
('Flutter','Mobile Development',10,'2026-09-01',3),
('C# Fundamentals','Programming Basics',6,'2026-07-20',1),
('Entity Framework Core','ORM and LINQ',8,'2026-09-15',2);

insert into Registrations
(StudentId, TrackId, RegistrationDate, Status)
values
(1,1,'2026-07-05','Confirmed'),
(2,1,'2026-07-06','Confirmed'),
(3,2,'2026-07-07','Pending'),
(4,3,'2026-07-08','Confirmed'),
(5,4,'2026-07-09','Confirmed'),
(1,5,'2026-07-10','Pending'),
(2,2,'2026-07-11','Confirmed');

insert into Payments
(RegistrationId, Amount, PaymentDate, PaymentStatus)
values
(1,5000,'2026-07-05','Paid'),
(2,5000,'2026-07-06','Paid'),
(3,3000,null,'Unpaid'),
(4,4500,'2026-07-08','Paid'),
(5,2000,'2026-07-09','Paid'),
(6,3500,null,'Unpaid'),
(7,3000,'2026-07-11','Paid');