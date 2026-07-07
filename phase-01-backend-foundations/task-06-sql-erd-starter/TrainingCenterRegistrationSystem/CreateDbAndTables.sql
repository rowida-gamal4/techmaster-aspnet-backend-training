create database TrainingCenterManagementSystem;
go

use TrainingCenterManagementSystem;
go

create table Students
(
    StudentId int identity(1,1) primary key,
    FullName nvarchar(100) not null,
    Email nvarchar(100) not null,
    PhoneNumber nvarchar(20),
    CreatedAt date 
);


create table Instructors
(
    InstructorId int identity(1,1) primary key,
    FullName nvarchar(100) not null,
    Email nvarchar(100) not null,
    Specialization nvarchar(100) not null
);


create table Tracks
(
    TrackId int identity(1,1) primary key,
    Title nvarchar(100) not null,
    Description nvarchar(200),
    DurationWeeks int not null,
    StartDate date not null,
    InstructorId int not null,

    constraint FK_Tracks_Instructors foreign key (InstructorId) references Instructors(InstructorId)
);


create table Registrations
(
    RegistrationId int identity(1,1) primary key,
    StudentId int not null,
    TrackId int not null,
    RegistrationDate date ,
    Status nvarchar(50) not null,

    constraint FK_Registrations_Students foreign key (StudentId)references Students(StudentId),

    constraint FK_Registrations_Tracks foreign key (TrackId)  references Tracks(TrackId)
);


create table Payments
(
    PaymentId int identity(1,1) primary key,
    RegistrationId int not null unique,
    Amount decimal(10,2) not null,
    PaymentDate date,
    PaymentStatus nvarchar(50) not null,

    constraint FK_Payments_Registrations foreign key (RegistrationId) references Registrations(RegistrationId)
);

