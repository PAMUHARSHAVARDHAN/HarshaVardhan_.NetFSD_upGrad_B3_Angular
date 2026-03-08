CREATE DATABASE Ecomdb

USE Ecomdb

CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100) NOT NULL
);

CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(100) NOT NULL
);


CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),
    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    city VARCHAR(50),
    phone VARCHAR(20),
    email VARCHAR(100)
);

CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100),
    city VARCHAR(50)
);


INSERT INTO categories VALUES
(1,'Motorcycles'),
(2,'Cars'),
(3,'Trucks'),
(4,'Electric Vehicles'),
(5,'Scooters');

INSERT INTO brands VALUES
(1,'Honda'),
(2,'Toyota'),
(3,'Tesla'),
(4,'BMW'),
(5,'Ford');


INSERT INTO products VALUES
(1,'Honda Shine',1,1,2022,85000),
(2,'Toyota Camry',2,2,2023,3500000),
(3,'Tesla Model 3',3,4,2023,4500000),
(4,'BMW X5',4,2,2022,7500000),
(5,'Ford F150',5,3,2021,4200000);


INSERT INTO customers VALUES
(1,'Rahul','Sharma','Hyderabad','9876543210','rahul@gmail.com'),
(2,'Anita','Reddy','Hyderabad','9876543211','anita@gmail.com'),
(3,'Kiran','Patel','Mumbai','9876543212','kiran@gmail.com'),
(4,'Priya','Singh','Delhi','9876543213','priya@gmail.com'),
(5,'Arjun','Verma','Hyderabad','9876543214','arjun@gmail.com');

INSERT INTO stores VALUES
(1,'Hyderabad Auto Store','Hyderabad'),
(2,'Mumbai Car Hub','Mumbai'),
(3,'Delhi Auto Mall','Delhi'),
(4,'Bangalore Motor Store','Bangalore'),
(5,'Chennai Auto Center','Chennai');


-------------------- Retrieve all products with their brand categorey-------

SELECT p.product_name, b.brand_name, c.category_name,p.model_year,p.list_price
FROM products p
JOIN brands b ON p.brand_id = b.brand_id
JOIN categories c ON p.category_id = c.category_id;

---------------------------- all customers from a specific city.-------------------------

SELECT * FROM customers WHERE city = 'Hyderabad';

---------------------------------Total Number of Products in Each Category--------------------

SELECT c.category_name, COUNT(p.product_id) AS total_products
FROM categories c LEFT JOIN products p 
ON c.category_id = p.category_id
GROUP BY c.category_name;

-------------------------------------------------------------------------------------------------------------------
------------------VIEW----------------
CREATE TABLE staffs (
    staff_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    store_id INT,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

INSERT INTO staffs VALUES
(1,'Ravi','Kumar',1),
(2,'Sneha','Reddy',2),
(3,'Amit','Sharma',3),
(4,'Karan','Singh',4),
(5,'Neha','Patel',5);


CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    store_id INT,
    staff_id INT,
    order_date DATE,

    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (staff_id) REFERENCES staffs(staff_id)
);

INSERT INTO orders VALUES
(1,1,1,1,'2023-01-10'),
(2,2,1,1,'2023-02-15'),
(3,3,2,2,'2023-03-20'),
(4,4,3,3,'2023-04-12'),
(5,5,4,4,'2023-05-05');


CREATE VIEW vw_ProductDetails
AS
SELECT 
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
JOIN brands b 
ON p.brand_id = b.brand_id
JOIN categories c
ON p.category_id = c.category_id;

DROP VIEW vw_ProductDetails;

CREATE VIEW vw_ProductDetails
AS
SELECT p.product_name,b.brand_name,c.category_name,p.model_year,p.list_price
FROM products p
JOIN brands b ON p.brand_id = b.brand_id
JOIN categories c ON p.category_id = c.category_id;

SELECT * FROM vw_ProductDetails;


CREATE VIEW vw_OrderSummary
AS
SELECT
o.order_id,
c.first_name + ' ' + c.last_name AS customer_name,
s.store_name,
st.first_name + ' ' + st.last_name AS staff_name,
o.order_date
FROM orders o
JOIN customers c 
ON o.customer_id = c.customer_id
JOIN stores s 
ON o.store_id = s.store_id
JOIN staffs st 
ON o.staff_id = st.staff_id;

SELECT * FROM vw_OrderSummary;


CREATE INDEX idx_products_brand
ON products(brand_id);

CREATE INDEX idx_products_category
ON products(category_id);

CREATE INDEX idx_orders_customer
ON orders(customer_id);

CREATE INDEX idx_orders_store
ON orders(store_id);

CREATE INDEX idx_orders_staff
ON orders(staff_id);

SELECT *
FROM orders
WHERE customer_id = 1;