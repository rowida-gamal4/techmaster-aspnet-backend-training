use TrainingCenterManagementSystem;
go 

--1
select * from Students 


--2
select * from Tracks;

--3
select s.* 
from Students s join Registrations r
on s.StudentId = r.StudentId
join Tracks t 
on r.TrackId = t.TrackId
where t.Title = 'Flutter';

--4
select t.Title, count(r.RegistrationId) as TotalStudents
from Tracks t left join Registrations r
on t.TrackId = r.TrackId
group by t.TrackId, t.Title;

--5
select r.* 
from Registrations r left join Payments p
on r.RegistrationId = p.RegistrationId
where p.PaymentId is null or p.PaymentStatus = 'Unpaid';

--6
select t.* , i.FullName as InstractorName
from Tracks t join Instructors i 
on t.InstructorId = i.InstructorId
where i.FullName = 'Sara'

--7
select r.RegistrationId , s.FullName as StudentName ,t.Title as TrackTitle ,r.Status as RegistrationStatus, p.PaymentStatus, p.Amount
from Registrations r join Students s 
on r.StudentId = s.StudentId 
join Tracks t 
on r.TrackId = t.TrackId
join Payments p 
on p.RegistrationId = r.RegistrationId 


--8
select * from Tracks 
where StartDate > '2026-09-01';

--9
select i.FullName, count(t.TrackId) as TotalTracks
from Instructors i Left join Tracks t
on i.InstructorId = t.InstructorId
group by i.InstructorId, i.FullName;

--10
select  s.FullName as StudentName, t.Title as TrackTitle,r.RegistrationDate,r.Status
from Students s join Registrations r
on s.StudentId = r.StudentId
join Tracks t
on r.TrackId = t.TrackId
where s.FullName = 'Rowida';