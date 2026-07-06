# Task 05 - Debug & Refactor Pack

## Overview

In this task, I refactored the original order calculator code. The original code was working, but everything was written inside `Program.cs`, which made it hard to read, maintain, and update.

My goal was to keep the same functionality while making the code cleaner and easier to understand.



## Project Structure


DebugRefactorPack
    Models
       Customer.cs
       CustomerType.cs
       Order.cs
    Services
       OrderCalculator.cs
       ReceiptPrinter.cs
    Helper
       ValidationHelper.cs
    UI
       ConsoleMenu.cs
    Program.cs

## Improvements I Made

1. Created a `Customer` class instead of storing customer information in variables.
2. Created an `Order` class to hold the order information.
3. Replaced the customer type string with a `CustomerType` enum.
4. Moved all calculation logic into the `OrderCalculator` class.
5. Created a `ValidationHelper` class to validate user input.
6. Added validation for customer name, product name, price, quantity, and customer type.
7. Replaced magic numbers with constants such as tax rate, discount rates, and shipping cost.
8. Created a `ReceiptPrinter` class to print the receipt instead of printing everything inside `Program.cs`.
9. Created a `ConsoleMenu` class to handle all user input and application flow.
10. Improved variable and class names to make the code easier to read.
11. Separated responsibilities between classes to make the project easier to maintain.


## Business Rules

* Price must be greater than zero.
* Quantity must be greater than zero.
* Customer name cannot be empty.
* Product name cannot be empty.
* Tax is 14%.
* Shipping costs 50 if the total after discount is less than 1000.
* Shipping is free if the total after discount is 1000 or more.
* Discount is applied before tax.
* Tax is calculated after discount.
* Shipping is added after tax.



## Notes Before Refactoring

* All code was inside one file.
* Variables had unclear names.
* Business logic and user input were mixed together.
* There was no validation.
* Magic numbers were used directly in the code.
* The receipt was printed directly from `Program.cs`.


## Notes After Refactoring

* The code is divided into separate classes.
* Business logic is inside `OrderCalculator`.
* Input validation is handled by `ValidationHelper`.
* The receipt is printed by `ReceiptPrinter`.
* `ConsoleMenu` is responsible for interacting with the user.
* Models represent the application data.
* The project is easier to read and maintain.


## Conclusion

This refactoring kept the original functionality while making the code cleaner and more organized. Separating the project into different classes made it easier to understand, test, and maintain. It also follows better object-oriented programming practices than the original version.
