# Task 06 - SQL & ERD Starter

## Selected Scenario

Library Management System

## Main Entities

- Authors
- Categories
- Books
- Members
- BorrowRecords


## Relationships

- One Author can write many Books.
- One Category can contain many Books.
- One Member can have many BorrowRecords.
- One Book can appear in many BorrowRecords.


## Primary Keys

- AuthorId
- CategoryId
- BookId
- MemberId
- BorrowRecordId


## Foreign Keys

- Books.AuthorId -> Authors.AuthorId
- Books.CategoryId -> Categories.CategoryId
- BorrowRecords.BookId -> Books.BookId
- BorrowRecords.MemberId -> Members.MemberId


## Why I Designed It This Way

I separated the data into different tables so each table has its own responsibility. Books are connected to authors and categories using foreign keys instead of storing the same information multiple times. Members and borrow records are also separated because one member can borrow many books. This design reduces duplicate data and makes the database easier to organize and query.


## SQL Queries

The SQL file [SqlQuerie] includes all the queries.

1. Select all books.
2. Select all active members.
3. Select books by category.
4. Count books per category.
5. Select borrow records with member name and book title using JOIN.
6. Select overdue books.
7. Select borrowing history for one member.
8. Select available books.
9. Count how many books each author has.
10. Select the top 5 most borrowed books.



