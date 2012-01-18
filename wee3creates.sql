----------------------------------
--DROPS
drop table orderlines;
drop table orders;
drop table customer;
drop table product;

-----------------------------------
--creates

create table customer
(
	CustomerId	int not null,
	fname 		varchar(20)	not null,
	lname		varchar(20) not null,
	primary key (CustomerId)
);

create table orders
(
	OrderId int not null,
	orderdate date not null,
	CustomerId int not null,
	primary key (OrderId)
);

create table product
(
	ProductId int not null,
	name varchar(30) not null,
	Price number(9,2) not null,
	primary key (ProductId)
);

create table orderlines
(
	OrderId int not null,
	ProductId int not null,
	linenumber smallint,
	primary key(OrderId, ProductId)
);

----------------------
--Alters

alter table orders
	add foreign key (CustomerId) references customer;
	
alter table orderlines
	add foreign key (OrderId) references orders;
alter table orderlines
	add foreign key (ProductId) references product;
	

	
insert into product (productid, name, price) values
(1,'Shirt', 19.99);

insert into product (productid, name, price) values
(2,'Shoes', 9.99);

insert into product (productid, name, price) values
(22,'Shoes', 9.99);

select productid, name from product;



--create or replace trigger jasonisawesome
--before insert on product
--begin
--	select max(productid) + 1 into productid from product;
--end;
--/
--drop trigger jasonisawesome;

	
	
	
	




