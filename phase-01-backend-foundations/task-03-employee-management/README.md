# Task 03 - Employee Management Console App

## Overview

A simple console-based Employee Management System built with C#. The application allows HR employees to manage employee records, search and filter employees, sort data, and generate salary reports using in-memory collections.

## Project Structure


task-03-employee-management/
    README.md
    EmployeeManagement/
        Program.cs
        ValidationHelper.cs
    
        Models
            Employee.cs
            Department.cs
     
        Services
            EmployeeService.cs
            EmployeeReportService.cs
     
        UI
           ConsoleMenu.cs

## Features


 Add Employee                                           
 Update Employee                                       
 Deactivate Employee                                    
 Search by Employee ID                                  
 Search by Full Name (Case-Insensitive & Partial Match) 
 Filter by Department                                   
 Sort by Salary (Ascending/Descending)                 
 Sort by Hire Date (Ascending/Descending)              
 Sort by Name                                           
 Salary Reports                                         
 View All Employees                                   

## Validation

* Employee ID is generated automatically.
* Email format is validated.
* Salary must be greater than zero.
* Hire date cannot be in the future.
* Department selection is validated.
* Employee records are deactivated instead of deleted.



## Notes

* Data is stored in memory using a seeded employee list.
* Business logic is separated into two service classes.
* Console interaction is handled through a separate menu class.
* Validation logic is reused through a `ValidationHelper` class to avoid reapeating code.
