create database sqlday2;
USE sqlday2;
 -----------------------level 1-1 problem ------------------------------
 CREATE TABLE Customers(
 Cust_id INT PRIMARY KEY,
 first_name VARCHAR(50) ,
 last_name VARCHAR(50) );
  

  INSERT INTO Customers VALUES
(1, 'Rahul', 'Sharma'),
(2, 'Priya', 'Reddy'),
(3, 'Arjun', 'Patel'),
(4, 'Sneha', 'Kumar'),
(5, 'Ravi', 'Verma');
SELECT * FROM Customers

 CREATE TABLE Orders(
 order_id INT PRIMARY KEY,
 Cust_id INT,
 Order_date DATE,
 Order_status INT,
 FOREIGN KEY (Cust_id) REFERENCES Customers (Cust_id));

 INSERT INTO Orders VALUES
 (101, 1, '2024-01-10', 1),
(102, 2, '2024-02-05', 4),
(103, 3, '2024-02-15', 2),
(104, 4, '2024-03-01', 1),
(105, 5, '2024-03-10', 3),
(106, 2, '2024-03-15', 4),
(107, 1, '2024-04-01', 2),
(108, 3, '2024-04-10', 4);

SELECT * FROM Orders

SELECT c.first_name,c.last_name,o.order_id,o.Order_date,o.Order_status FROM Customers c
INNER JOIN Orders o ON c.Cust_id = o.Cust_id ;

SELECT * FROM Orders WHERE Order_status =1 or Order_status = 4

SELECT * FROM Orders ORDER BY Order_date DESC


--------------------------- level 1 -2 problem ---------------------
CREATE TABLE Brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(50)
);

INSERT INTO Brands VALUES
(1, 'Nike'),
(2, 'Adidas'),
(3, 'Puma'),
(4, 'Reebok');

CREATE TABLE Categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50)
);

INSERT INTO Categories VALUES
(1, 'Shoes'),
(2, 'Clothing'),
(3, 'Accessories');


CREATE TABLE Products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),
    FOREIGN KEY (brand_id) REFERENCES Brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES Categories(category_id)
);

INSERT INTO Products VALUES
(101, 'Air Max Shoes', 1, 1, 2022, 750),
(102, 'Running T-Shirt', 2, 2, 2023, 450),
(103, 'Sports Cap', 3, 3, 2021, 300),
(104, 'Training Shoes', 2, 1, 2024, 900),
(105, 'Gym Jacket', 4, 2, 2022, 650),
(106, 'Casual Shoes', 3, 1, 2023, 550),
(107, 'Sports Bag', 1, 3, 2024, 800);

SELECT p.product_name, b.brand_name, c.category_name, p.model_year, p.list_price FROM Products p INNER JOIN
Brands b ON p.brand_id = b.brand_id INNER JOIN Categories c ON p.category_id = c.category_id;

SELECT * FROM Products  WHERE list_price >500

SELECT list_price FROM Products ORDER BY list_price ASC


--------------------------------------level 2 -1 problem -----------------------------------

CREATE TABLE Stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(50)
);

INSERT INTO Stores VALUES
(1, 'Hyderabad Store'),
(2, 'Mumbai Store'),
(3, 'Delhi Store');

CREATE TABLE Orders1 (
    order_id INT PRIMARY KEY,
    store_id INT,
    order_status INT,
    order_date DATE,
    FOREIGN KEY (store_id) REFERENCES Stores(store_id)
);

INSERT INTO Orders1 VALUES
(101, 1, 4, '2024-01-10'),
(102, 2, 4, '2024-01-15'),
(103, 1, 2, '2024-02-01'),
(104, 3, 4, '2024-02-10'),
(105, 2, 3, '2024-02-20'),
(106, 1, 4, '2024-03-05');

CREATE TABLE Order_Items (
    item_id INT PRIMARY KEY,
    order_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),
    FOREIGN KEY (order_id) REFERENCES Orders1(order_id)
);

INSERT INTO Order_Items VALUES
(1, 101, 2, 500, 0.10),
(2, 101, 1, 800, 0.05),
(3, 102, 3, 300, 0.00),
(4, 103, 2, 400, 0.10),
(5, 104, 1, 1000, 0.20),
(6, 106, 4, 250, 0.05);
Select * from  Order_Items
SELECT 
    s.store_name,
    SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
FROM Stores s
INNER JOIN Orders1 o
    ON s.store_id = o.store_id
INNER JOIN Order_Items oi
    ON o.order_id = oi.order_id
WHERE o.order_status = 4
GROUP BY s.store_name
ORDER BY total_sales DESC;


------------------------level 2-2 problem-------------------------


CREATE TABLE Products2 (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100)
);
INSERT INTO Products2 VALUES
(1, 'Laptop'),
(2, 'Smartphone'),
(3, 'Headphones'),
(4, 'Keyboard');

CREATE TABLE Stores2 (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(50)
);
INSERT INTO Stores2 VALUES
(1, 'Hyderabad Store'),
(2, 'Mumbai Store'),
(3, 'Delhi Store');


CREATE TABLE Stocks2 (
    store_id INT,
    product_id INT,
    quantity INT,
    PRIMARY KEY (store_id, product_id),
    FOREIGN KEY (store_id) REFERENCES Stores2(store_id),
    FOREIGN KEY (product_id) REFERENCES Products2(product_id)
);

INSERT INTO Stocks2 VALUES
(1, 1, 50),
(1, 2, 40),
(2, 1, 30),
(2, 3, 60),
(3, 2, 25),
(3, 4, 45);

CREATE TABLE Orders2 (
    order_id INT PRIMARY KEY,
    store_id INT,
    order_status INT,
    order_date DATE,
    FOREIGN KEY (store_id) REFERENCES Stores2(store_id)
);
INSERT INTO Orders2 VALUES
(101, 1, 4, '2024-01-10'),
(102, 2, 4, '2024-01-15'),
(103, 1, 2, '2024-02-01'),
(104, 3, 4, '2024-02-10');

CREATE TABLE Order_Items2 (
    item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (order_id) REFERENCES Orders2(order_id),
    FOREIGN KEY (product_id) REFERENCES Products2(product_id)
);

INSERT INTO Order_Items2 VALUES
(1, 101, 1, 5),
(2, 101, 2, 3),
(3, 102, 3, 7),
(4, 104, 2, 4),
(5, 104, 4, 6);



SELECT 
    p.product_name,
    s.store_name,
    st.quantity AS available_stock_quantity,
    SUM(oi.quantity) AS total_quantity_sold
FROM Stocks2 st
INNER JOIN Products2 p
    ON st.product_id = p.product_id
INNER JOIN Stores2 s
    ON st.store_id = s.store_id
LEFT JOIN Order_Items2 oi
    ON st.product_id = oi.product_id
GROUP BY 
    p.product_name,
    s.store_name,
    st.quantity
ORDER BY 
    p.product_name;