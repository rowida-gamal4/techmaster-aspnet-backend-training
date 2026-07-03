# Task 02 - OOP Bank Account System

A simple console-based banking system built with C# to practice Object-Oriented Programming (OOP), encapsulation, business rules, and separation of concerns.

## Features

1. Create project structure.
2. Create enums: AccountType and TransactionType. 
3. Create Customer model. 
4. Create Transaction model. 
5. Create BankAccount model with encapsulated balance. 
6. Implement Deposit and Withdraw behavior. 
7. Create BankService. 
8. Implement account creation. 
9. Implement transfer logic.
10. Implement transaction history.
11. Build ConsoleMenu.


## Project Structure


task-02-bank-account-system/
 README.md
 BankAccountSystem/
   Models/
        Customer.cs
        BankAccount.cs
        Transaction.cs
        AccountType.cs
        TransactionType.cs
   Services/
        BankService.cs
   UI/
        ConsoleMenu.cs
   Program.cs


## OOP Concepts Used

- Classes and Objects
- Encapsulation (Balance has a private setter)
- Enums
- Methods
- Collections (List<T>)
- Separation of Concerns

## Business Rules

- Customer name, email and phone are required.
- Initial balance cannot be negative.
- Deposit amount must be positive.
- Withdrawal amount must be positive.
- Withdrawal cannot exceed account balance.
- Source and destination accounts cannot be the same.
- Every successful deposit, withdrawal and transfer creates a transaction.
- Initial balance also creates a deposit transaction.

