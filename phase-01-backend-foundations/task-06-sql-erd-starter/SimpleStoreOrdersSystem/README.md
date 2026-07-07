# Task 06 - SQL & ERD Starter

## Selected Scenario

Simple Store & Orders System


## Main Entities

- Customers
- Categories
- Suppliers
- Products
- Orders
- OrderItems



## Relationships

- One Customer can have many Orders.
- One Order can have many OrderItems.
- One Product can appear in many OrderItems.
- One Category can contain many Products.
- One Supplier can supply many Products.



## Primary Keys

- CustomerId
- CategoryId
- SupplierId
- ProductId
- OrderId
- OrderItemId


## Foreign Keys

- Products.CategoryId -> Categories.CategoryId
- Products.SupplierId -> Suppliers.SupplierId
- Orders.CustomerId -> Customers.CustomerId
- OrderItems.OrderId -> Orders.OrderId
- OrderItems.ProductId -> Products.ProductId



## Why I Designed It This Way

I divided the system into separate tables so each table stores one type of information. Customers, products, categories, and suppliers are stored separately to avoid repeating data. Orders and order items are also separated because one order can contain multiple products. I used primary keys to identify each record and foreign keys to connect the related tables. This design makes the database easier to maintain and supports all the required queries.



## SQL Queries

The SQL file [SqlQuerie] includes all the queries.

1. Select all products.
2. Select available products.
3. Select products by category.
4. Select products with low stock.
5. Select orders for one customer.
6. Select order details using JOIN.
7. Calculate total sales.
8. Count products per category.
9. Select best-selling products.
10. Select suppliers with their products.

