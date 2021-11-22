create database Sports_Shop
create table Customer_Management_Module(Customer_Id int primary key not null identity(1,1),Name varchar(100) not null, Contact_Number varchar(200) not null, Address varchar(300) not null,Email_Id varchar(200))
create table Item_Management_Module(Name varchar(100) not null, Item_Id int primary key not null identity(1,1),Price decimal not null,Color varchar(100),Size varchar(100),Description varchar(500))
create table Order_Module(order_Id int primary key not null identity(1,1),order_date date,Customer_Id int foreign key references Customer_Management_Module,Item_Id int foreign key references Item_Management_Module)
select *from Customer_Management_Module;
select *from Item_Management_Module;
select *from Order_Module;