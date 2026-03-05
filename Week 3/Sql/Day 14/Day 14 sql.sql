CREATE DATABASE SQLDAY4;
USE SQLDAY4
CREATE TABLE Products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    model_year INT,
    category_id INT,
    list_price DECIMAL(10,2)
);
INSERT INTO Products VALUES
(1, 'Mountain Bike', 2018, 1, 500),
(2, 'Road Bike', 2019, 1, 700),
(3, 'Touring Bike', 2020, 1, 900),
(4, 'Electric Scooter', 2021, 2, 1200),
(5, 'Electric Bike', 2022, 2, 1500),
(6, 'Kids Bicycle', 2017, 3, 200),
(7, 'Balance Bike', 2018, 3, 150);
SELECT * FROM Products

SELECT 
    product_name + ' (' + CAST(model_year AS VARCHAR) + ')' AS Product_Details,
    list_price,
    list_price - (
        SELECT AVG(list_price)
        FROM Products p2
        WHERE p2.category_id = p1.category_id
    ) AS Price_Difference
FROM Products p1
WHERE list_price > (
        SELECT AVG(list_price)
        FROM Products p2
        WHERE p2.category_id = p1.category_id
);

----------------------level 1-2 problem---------------------

CREATE TABLE Customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);

CREATE TABLE Orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_value DECIMAL(10,2),
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id)
);

INSERT INTO Customers VALUES
(1,'Ravi','Kumar'),
(2,'Anita','Sharma'),
(3,'Rahul','Verma'),
(4,'Sneha','Reddy'),
(5,'Arjun','Patel');


INSERT INTO Orders VALUES
(101,1,3000),
(102,1,2500),
(103,2,7000),
(104,3,12000),
(105,3,2000);


SELECT 
c.first_name + ' ' + c.last_name AS Full_Name,

(SELECT SUM(o.order_value)
 FROM Orders o
 WHERE o.customer_id = c.customer_id) AS Total_Order_Value,

CASE
WHEN (SELECT SUM(o.order_value)
      FROM Orders o
      WHERE o.customer_id = c.customer_id) > 10000 THEN 'Premium'

WHEN (SELECT SUM(o.order_value)
      FROM Orders o
      WHERE o.customer_id = c.customer_id) BETWEEN 5000 AND 10000 THEN 'Regular'

ELSE 'Basic'
END AS Customer_Category

FROM Customers c
JOIN Orders o
ON c.customer_id = o.customer_id

GROUP BY c.customer_id, c.first_name, c.last_name


UNION


SELECT 
c.first_name + ' ' + c.last_name AS Full_Name,
NULL AS Total_Order_Value,
'No Orders' AS Customer_Category

FROM Customers c
WHERE c.customer_id NOT IN
(
SELECT customer_id FROM Orders
);






----------------------------level 2-1 problem------------------------------

CREATE TABLE stores1(
store_id INT PRIMARY KEY,
store_name VARCHAR(50)
);

CREATE TABLE products1(
product_id INT PRIMARY KEY,
product_name VARCHAR(50),
list_price DECIMAL(10,2)
);

CREATE TABLE orders1(
order_id INT PRIMARY KEY,
store_id INT,
FOREIGN KEY(store_id) REFERENCES stores1(store_id)
);

CREATE TABLE order_items1(
order_id INT,
product_id INT,
quantity INT,
discount DECIMAL(10,2),
FOREIGN KEY(order_id) REFERENCES orders1(order_id),
FOREIGN KEY(product_id) REFERENCES products1(product_id)
);

CREATE TABLE stocks1(
store_id INT,
product_id INT,
quantity INT,
FOREIGN KEY(store_id) REFERENCES stores1(store_id),
FOREIGN KEY(product_id) REFERENCES products1(product_id)
);

INSERT INTO stores1 VALUES
(1,'Hyderabad Store'),
(2,'Mumbai Store');

INSERT INTO products1 VALUES
(1,'Laptop',60000),
(2,'Mobile',20000),
(3,'Headphones',3000);

INSERT INTO orders1 VALUES
(101,1),
(102,1),
(103,2);

INSERT INTO order_items1 VALUES
(101,1,2,2000),
(101,2,3,500),
(102,3,5,100),
(103,1,1,1000);

INSERT INTO stocks1 VALUES
(1,1,10),
(1,2,0),
(1,3,0),
(2,1,5),
(2,2,8);


SELECT 
s.store_name,
p.product_name,
SUM(sales.quantity) AS total_quantity_sold,

SUM((sales.quantity * p.list_price) - sales.discount) AS total_revenue

FROM
(
SELECT o.store_id, oi1.product_id, oi1.quantity, oi1.discount
FROM orders1 o
JOIN order_items1 oi1
ON o.order_id = oi1.order_id
) AS sales

JOIN stores1 s
ON sales.store_id = s.store_id

JOIN products1 p
ON sales.product_id = p.product_id

GROUP BY s.store_name, p.product_name;

----------------------------------------level2-4 problem---------------

CREATE TABLE orders2(
order_id INT PRIMARY KEY,
customer_id INT,
order_date DATE,
required_date DATE,
shipped_date DATE,
order_status INT
);

INSERT INTO orders2 VALUES
(1,101,'2023-01-10','2023-01-15','2023-01-14',2),
(2,102,'2023-02-05','2023-02-12','2023-02-15',2),
(3,103,'2022-01-01','2022-01-10','2022-01-09',3),
(4,104,'2021-12-15','2021-12-20','2021-12-21',3),
(5,101,'2023-03-01','2023-03-10','2023-03-09',2);


CREATE TABLE archived_orders(
order_id INT,
customer_id INT,
order_date DATE,
required_date DATE,
shipped_date DATE,
order_status INT
);

INSERT INTO archived_orders
SELECT *
FROM orders2
WHERE order_status = 3
AND order_date < DATEADD(YEAR,-1,GETDATE());


DELETE FROM orders2
WHERE order_id IN
(
SELECT order_id
FROM archived_orders
);


SELECT customer_id
FROM orders2
WHERE customer_id NOT IN
(
SELECT customer_id
FROM orders2
WHERE order_status <> 2
);


SELECT 
order_id,
order_date,
shipped_date,
DATEDIFF(DAY, order_date, shipped_date) AS processing_delay
FROM orders2;


SELECT
order_id,
order_date,
required_date,
shipped_date,

CASE
WHEN shipped_date > required_date THEN 'Delayed'
ELSE 'On Time'
END AS delivery_status

FROM orders2;