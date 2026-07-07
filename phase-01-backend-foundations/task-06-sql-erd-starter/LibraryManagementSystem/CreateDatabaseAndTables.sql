Create Database LibraryManagementSystem ;
go
use LibraryManagementSystem ;


create table Authors
(
    AuthorId int IDENTITY(1,1) primary key ,
    FullName Nvarchar(100) not null ,
    BirthDate Date ,
    Country nvarchar(100)
);

create table Categories
(
    CategoryId int IDENTITY(1,1) primary key ,
    Name Nvarchar(100) not null ,
    Description nvarchar(100) 
);

create table Members
(
    MemberId int IDENTITY(1,1) primary key ,
    FullName Nvarchar(100) not null ,
    Email Nvarchar(100) not null ,
    PhoneNumber Nvarchar(100),
    JoinDate Date ,
    IsActive bit ,
);

create table Books
(
  BookId int IDENTITY(1,1) primary key ,
  ISBN nvarchar(50) ,
  Title nvarchar(50) ,
  PublishedYear int ,
  AvailableCopies int ,
  AuthorId int REFERENCES Authors(AuthorId) ,
  CategoryId int not null ,
  constraint FK_Books_Categories foreign key (CategoryId) REFERENCES Categories (CategoryId) 
  
)
CREATE TABLE BorrowRecords
(
    BorrowRecordId int IDENTITY(1,1) primary key,
    BookId INT NOT NULL,
    MemberId INT NOT NULL,
    BorrowDate Date ,
    DueDate Date ,
    ReturnDate Date ,
    Status Nvarchar(50) ,
    constraint FK_BorrowRecords_Books foreign key (BookId) REFERENCES Books (BookId) ,
    constraint FK_BorrowRecords_Members foreign key (MemberId) REFERENCES Members (MemberId)
)
----------------------------------------------------
