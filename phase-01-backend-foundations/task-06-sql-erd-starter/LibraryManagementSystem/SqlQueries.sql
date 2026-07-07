use LibraryManagementSystem
--1
select * from Books

--2
select * from Members m where m.IsActive =1

--3
select b.Title , c.Name as CategoryName
from Books b join Categories c
on c.CategoryId = b.CategoryId
where c.Name = 'Horror'

--4
select c.Name , COUNT(*) as TotalBooks
from Books b join Categories c
on b.CategoryId = c.CategoryId
group by c.Name 

--5
select b.Title ,m.FullName as MemberName ,BR.BorrowDate ,BR.[Status] 
from BorrowRecords BR join Books b
on BR.BookId = b.BookId
join Members m 
on m.MemberId = br.MemberId

--6
SELECT b.Title ,m.FullName as MemberName ,BR.BorrowDate ,BR.DueDate ,BR.[Status] 
from BorrowRecords br join Books b
on b.BookId = br.BookId
join Members m 
on m.MemberId = br.MemberId
where br.ReturnDate is null
--AND br.DueDate < GETDATE();

--7
select b.Title ,m.FullName as MemberName ,BR.BorrowDate ,BR.[ReturnDate] , br.[Status]
from BorrowRecords br join Books b
on br.BookId = b.BookId
join Members m 
on m.MemberId = br.MemberId
where m.FullName ='Rowida';

--8
select b.BookId , b.Title , b.ISBN , b.PublishedYear
from Books b 
where b.AvailableCopies > 0

--9
select b.AuthorId ,a.FullName as AuthorName, COUNT(*) as TotalBooks
from Books b join Authors a
on b.AuthorId = a.AuthorId
group by b.AuthorId , a.FullName 

--10
SELECT top(5) b.Title, COUNT(*) as BorrowCount
from Books b join BorrowRecords br 
on b.BookId = br.BorrowRecordId
group by b.Title
order by BorrowCount desc