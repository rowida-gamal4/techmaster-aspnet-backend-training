Use StoreOrdersManagementSystem;
Go

--1
select * from Products

--2
select *from Products
where IsAvailable = 1;

--3
select p.Name as ProductName ,p.Price ,p.StockQuantity ,p.IsAvailable ,c.Name  as CategoryName,c.[Description]
from Products p join Categories c
on p.CategoryId = c.CategoryId 
where c.Name ='Electronics' ;

--4
select p.ProductId , p.Name , p.StockQuantity ,p.Price 
from Products p 
where p.StockQuantity < 5


--5
select * from Orders 
where CustomerId = 1

--6
select o.OrderId , o.OrderDate ,o.[Status] ,o.TotalAmount ,
       c.FullName as CustomerName ,p.Name as ProductName , c.PhoneNumber as CustomerNumber ,
       oI.Quantity 
from Orders o join Customers c 
on o.CustomerId = c.CustomerId
join OrderItems oI
on  o.OrderId = oI.OrderId
join Products p 
on p.ProductId = oi.ProductId

--7
select sum(O.TotalAmount) as TotalSales
from Orders O 
where O.[Status] = 'Completed' ;

--8
select c.Name as CategoryName ,COUNT(p.ProductId) as TotalProducts
from Categories c
join Products p  
on c.CategoryId = p.CategoryId 
group by c.CategoryId ,c.Name 

--9
select Top(10) p.ProductId ,p.Name , COUNT(oi.OrderItemId) as orderCount
from Products p join OrderItems oi 
on p.ProductId = oi.ProductId 
group by p.ProductId , p.Name 
order by orderCount desc 

--10 
select s.Name as SupplierName, p.Name as ProductName, p.Price, p.StockQuantity
from Suppliers s left join  Products p 
on s.SupplierId = p.SupplierId;