SELECT contactname as "Guest Name", customerid, city
FROM customers 
WHERE contactname = "Antonio Moreno";

select customerid from customers
where contactname = "Antonio Moreno";

select orderid from orders 
where customerid = 'anton';

select unitprice * quantity from [order details] where
orderid  = 10365;

select unitprice * quantity from [order details], orders, customers where
contactname = "Antonio Moreno"
and customers.customerid = orders.customerid
and orders.orderid = [order details].orderid;

select count([order details].orderid), contactname from [order details], orders, customers where
customers.customerid = orders.customerid
and orders.orderid = [order details].orderid
group by contactname;

select count([order details].orderid) as ordertotal, contactname from [order details], orders, customers where
customers.customerid = orders.customerid
and orders.orderid = [order details].orderid
group by contactname
order by count([order details].orderid) desc;



--note for trigger

Yes, you should create a sequence object and use it with a trigger for your auto number.
 
CREATE SEQUENCE resources_s
   MINVALUE 1
   MAXVALUE 999999999999999999999999999
   INCREMENT BY 1
   START WITH 100
   CACHE 60
   ORDER
   NOCYCLE;
 
CREATE TABLE resources (res_id NUMBER (38));
 
ALTER TABLE resources ADD CONSTRAINT resources_pk PRIMARY KEY (res_id);
 
CREATE OR REPLACE TRIGGER resources_t
   BEFORE INSERT
   ON resources
   FOR EACH ROW
BEGIN
   SELECT resources_s.NEXTVAL INTO :new.res_id FROM DUAL;
END;
/
SHOW ERRORS;
