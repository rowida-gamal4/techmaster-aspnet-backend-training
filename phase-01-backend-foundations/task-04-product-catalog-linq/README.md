# Product Catalog with LINQ

## Overview

This is a C# Console Application that simulates a simple product catalog for an online store.
The project demonstrates how LINQ can be used to filter, search, sort, group, aggregate, project, and paginate data in memory.


## Project Structure
ProductCatalogWithLinq/
    DTO/
       ProductSummary.cs
    Models/
       Product.cs
        
    Services/
       ProductQueryService.cs

    UI/
       ConsoleMenu.cs

    Program.cs
    README.md

## Implemented Queries

### 1. View Available Products

Returns only products that are available and have stock greater than zero using Where Linq.

### 2. Filter by Category

Asks the user for a category name and returns all matching products regardless of letter casing using Where, Equals, StringComparison.OrdinalIgnoreCase

### 3. Search by Product Name

Allows searching products using a partial keyword using Where, Contains.


### 4. Sort Products by Price

Displays products sorted either from the lowest price to the highest or from the highest price to the lowest Using OrderBy,OrderByDescending


### 5. Pagination Simulation

Simulates database pagination by asking the user for a page number and page size, then displaying only the requested page of products using Skip -Take .

## Other Implemented Queries

- Filter by Price Range
- Group Products by Category
- Count Products per Category
- Calculate Total Stock Value
- Stock Value per Category
- Top 5 Most Expensive Products
- Low Stock Products
- Out of Stock Products
- Product Summary DTO Projection
- Supplier Report
- Recently Added Products
- Category Statistics
- Products Above Average Price
- Combined Search & Filter

## LINQ Concepts Used

- Where
- Select
- OrderBy
- OrderByDescending
- GroupBy
- Count
- Sum
- Average
- Min
- Max
- Skip
- Take

## Features

- Console menu interface
- Input validation
- Case-insensitive searching
- Readable console output
- LINQ-based queries
- Seeded sample data
- Pagination support

## Technologies

- C#
- .NET Console Application
- LINQ