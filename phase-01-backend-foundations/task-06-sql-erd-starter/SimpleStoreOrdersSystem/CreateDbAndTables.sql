Create Database StoreOrdersManagementSystem;
Go

Use StoreOrdersManagementSystem;
Go

create table Customers
(
    CustomerId int Identity(1,1) primary key,
    FullName Nvarchar(100) not null,
    Email Nvarchar(100) not null,
    PhoneNumber Nvarchar(20),
    CreatedAt Date 
);

create table Categories
(
    CategoryId int Identity(1,1) primary key,
    Name Nvarchar(100) not null,
    Description Nvarchar(200)
);


create table Suppliers
(
    SupplierId int Identity(1,1) primary key,
    Name Nvarchar(100) not null,
    PhoneNumber Nvarchar(20),
    Email Nvarchar(100)
);


create table Products
(
    ProductId int Identity(1,1) primary key,
    Name Nvarchar(100) not null,
    Price Decimal(10,2) not null,
    StockQuantity int not null,
    CategoryId int not null,
    SupplierId int not null,
    IsAvailable bit not null,

    Constraint FK_Products_Categories Foreign Key(CategoryId) References Categories(CategoryId),

    Constraint FK_Products_Suppliers Foreign Key(SupplierId) References Suppliers(SupplierId)
);


create table Orders
(
    OrderId int Identity(1,1) primary key,
    CustomerId int not null,
    OrderDate Date not null,
    Status Nvarchar(50) not null,
    TotalAmount Decimal(10,2) not null,

    Constraint FK_Orders_Customers Foreign Key(CustomerId) References Customers(CustomerId)
);

create table OrderItems
(
    OrderItemId int Identity(1,1) primary key,
    OrderId int not null,
    ProductId int not null,
    Quantity int not null,

    Constraint FK_OrderItems_Orders Foreign Key(OrderId)  References Orders(OrderId),

    Constraint FK_OrderItems_Products Foreign Key(ProductId) References Products(ProductId)
);