Use StoreOrdersManagementSystem;
Go

Insert Into Customers
(FullName, Email, PhoneNumber, CreatedAt)
Values
('Rowida','rowida@gmail.com','01122055628','2026-07-01'),
('Gamal','gamal@gmail.com','01122055629','2026-07-02'),
('Hassan','hassan@gmail.com','01122055627','2026-07-03'),
('Arwa','arwa@gmail.com','01122055626','2026-07-04'),
('Ali','ali@gmail.com','01122055625','2026-07-05');


Insert Into Categories
(Name, Description)
Values
('Electronics','Electronic products'),
('Books','Books category'),
('Sports','Sports products'),
('Clothes','Clothes category'),
('Accessories','Accessories');



Insert Into Suppliers
(Name, PhoneNumber, Email)
Values
('Mohamed','01000000001','mohamed@gmail.com'),
('Ahmed','01000000002','ahmed@gmail.com'),
('Sara','01000000003','sara@gmail.com'),
('Omar','01000000004','omar@gmail.com'),
('Mona','01000000005','mona@gmail.com');


Insert Into Products
(Name, Price, StockQuantity, CategoryId, SupplierId, IsAvailable)
Values
('Laptop',25000,10,1,1,1),
('Keyboard',800,30,1,2,1),
('Book',350,20,2,3,1),
('Football',500,15,3,4,1),
('T-Shirt',250,40,4,5,1),
('Mouse',400,5,1,2,1),
('Headphones',1500,0,1,1,0),
('Bag',600,12,5,5,1),
('Basketball',700,3,3,4,1),
('Novel',200,25,2,3,1);



Insert Into Orders
(CustomerId, OrderDate, Status, TotalAmount)
Values
(1,'2026-07-01','Completed',25800),
(2,'2026-07-02','Completed',850),
(3,'2026-07-03','Pending',1500),
(1,'2026-07-04','Completed',950),
(4,'2026-07-05','Completed',700);


Insert Into OrderItems
(OrderId, ProductId, Quantity)
Values
(1,1,1),
(1,2,1),
(2,3,2),
(3,7,1),
(4,4,1),
(4,5,1),
(4,6,1),
(5,9,1),
(5,10,1),
(2,10,1);