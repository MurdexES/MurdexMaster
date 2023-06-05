use [ProductsDB]

create table Products
(
  Id int identity (1,1) not null primary key ,
  ProdName nvarchar(max) not null check (ProdName <> ''),
  ProdDesc nvarchar(max) not null check (ProdDesc <> ''),
  ProdPrice money not null ,
  ProdBrand nvarchar(100) not null check (ProdBrand <> '')
);


