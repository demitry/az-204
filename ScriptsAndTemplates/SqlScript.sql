create database appdb;
use appdb;
DROP TABLE Products;

CREATE TABLE Products
(
	ProductId int,
	ProductName varchar(1000),
	Quantity int
);

INSERT INTO Products(ProductId, ProductName, Quantity) VALUES (0, 'MySql', 0), (1, 'Mobile', 100), (2, 'Laptop', 200), (3, 'Tabs', 300);

select * from Products;