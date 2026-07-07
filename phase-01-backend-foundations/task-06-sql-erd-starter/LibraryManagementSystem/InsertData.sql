use LibraryManagementSystem

insert into Authors (fullName , Country,BirthDate)
values
       ('Arwa','Egypt','1-1-2001'),
       ('Ali','Egypt','2-2-2002'),
       ('Mohamed','Egypt','3-3-2003')

insert into Categories (Name , [Description])
values 
      ('Comedy','comedy category'),
      ('Action','action category'),
      ('Horror','horror category')

insert into Members(FullName,Email,PhoneNumber,JoinDate,IsActive)     
 values 
         ('Rowida','rowida@gmail.com','01122055628','6-7-2026',1) ,
         ('Gamal','gamal@gmail.com','01122055629','6-6-2026',0) ,
         ('Hassan','hassan@gmail.com','01122055627','5-6-2026',0) 

insert into Books(ISBN ,Title ,PublishedYear,AvailableCopies,AuthorId,CategoryId)      
   values 
          ('A1001','Book01','2004',5,1,1),
          ('A1002','Book02','2004',10,2,1),
          ('B1003','Book03','2004',9,3,2),
          ('B1004','Book04','2004',3,1,2),
          ('A1005','Book05','2004',7,2,1),
          ('C1006','Book06','2004',8,3,3),
          ('C1007','Book07','2004',5,1,3)   

insert into BorrowRecords(BookId,MemberId,BorrowDate,DueDate,ReturnDate,Status)
values 
(1, 1, '2026-07-07', '2026-08-08', NULL, 'Borrowed'),
(3, 1, '2026-07-06', '2026-08-08', '2026-08-05', 'Returned'),
(5, 1, '2026-07-08', '2026-08-08', NULL, 'Borrowed'),
(2, 1, '2026-07-06', '2026-08-06', '2026-08-05', 'Returned'),
(4, 2, '2026-07-05', '2026-08-07', NULL, 'Borrowed');
   
