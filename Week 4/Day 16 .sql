
--------------LEVEL 2 PROBLEM 1 ----------
CREATE DATABASE WEEK4DAY5
USE WEEK4DAY5;

CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(50)
);
CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    customer_name VARCHAR(50)
);
CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    list_price DECIMAL(10,2)
);
CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    store_id INT,
    order_date DATE,
    order_status INT,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);
CREATE TABLE order_items (
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);
INSERT INTO stores VALUES
(1,'Hyderabad Store'),
(2,'Mumbai Store'),
(3,'Delhi Store');

INSERT INTO customers VALUES
(1,'Rahul'),
(2,'Priya'),
(3,'Arjun');


INSERT INTO products VALUES
(1,'Laptop',50000),
(2,'Mobile',20000),
(3,'Headphones',3000),
(4,'Keyboard',1500);


INSERT INTO orders VALUES
(1,1,1,'2023-01-10',1),
(2,2,2,'2023-02-15',1),
(3,3,1,'2023-03-20',1);

INSERT INTO order_items VALUES
(1,1,1,1,50000,0.10),
(2,1,3,2,3000,0.05),
(3,2,2,1,20000,0.15),
(4,3,4,3,1500,0);


SELECT * FROM order_items;

CREATE  PROCEDURE sp_TotalSalesPerStore
AS
BEGIN 
SELECT s.store_id,s.store_name,SUM(oi.quantity*oi.list_price*(1-ISNULL(oi.discount,0))) AS Total_sales
FROM stores s
join orders o
ON s.store_id = o.store_id
join
order_items oi
ON o.order_id = oi.order_id
GROUP BY s.store_id,s.store_name
END

EXEC sp_TotalSalesPerStore

------------------ORDERS  BY DATE RANGE----------------
CREATE PROCEDURE sp_GetOrdersbydaterange
@StartDate DATE,
@EndDate DATE
AS
BEGIN
SELECT order_id,customer_id, order_date,order_status FROM orders
WHERE order_date BETWEEN @StartDate AND @EndDate
END
EXEC sp_GetOrdersbydaterange '2016-01-01','2023-03-20'

------------------------------------------------------------SCALER FUNCTION AFTER DISCOUNT----------------
CREATE FUNCTION fn_TotalPriceAfterDiscount
(
    @Price DECIMAL(10,2),
    @Discount DECIMAL(4,2)
)
RETURNS DECIMAL(10,2)

AS
BEGIN
RETURN (@Price*(1-ISNULL(@Discount,0)))
END


SELECT dbo.fn_TotalPriceAfterDiscount(1000,0.10) AS FinalPrice

SELECT order_id,product_id,list_price,discount,
dbo.fn_TotalPriceAfterDiscount(list_price,discount) AS final_price
FROM order_items;


--------------------------------------------------TOP 5 SELLING PRODUCTS-----

CREATE FUNCTION fn_Top5SellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.product_name,
        SUM(oi.quantity) AS total_sold
    FROM order_items oi
    JOIN products p
        ON oi.product_id = p.product_id
    GROUP BY p.product_name
    ORDER BY total_sold DESC
)


SELECT * FROM dbo.fn_Top5SellingProducts()



-----********PROBLEM  2  Stock Auto-Update Trigger-----

CREATE TABLE stocks
(
    product_id INT PRIMARY KEY,
    quantity INT
);

INSERT INTO stocks VALUES
(1,50),
(2,40),
(3,30),
(4,20);
SELECT * FROM stocks

CREATE TRIGGER trg_UpdateStock
ON order_items
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        IF EXISTS
        (
            SELECT 1
            FROM stocks s
            JOIN inserted i
            ON s.product_id = i.product_id
            WHERE s.quantity < i.quantity
        )
        BEGIN
            RAISERROR('Insufficient stock available',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        UPDATE s
        SET s.quantity = s.quantity - i.quantity
        FROM stocks s
        INNER JOIN inserted i
        ON s.product_id = i.product_id;

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END


INSERT INTO order_items
VALUES (5,1,1,5,50000,0.1)

SELECT * FROM stocks

INSERT INTO order_items
VALUES (6,1,1,100,50000,0.1)


--------------------------********************************

SELECT * FROM order_items
DROP TABLE stocks;
DROP TABLE order_items;
DROP TRIGGER trg_UpdateStock;

DROP TABLE IF EXISTS order_items;
DROP TABLE IF EXISTS stocks;

------------------------------------------------------------------Level-2 Problem 3: Order Status Validation Trigger


ALTER TABLE orders
ADD shipped_date DATE;

CREATE TRIGGER trg_OrderStatusValidation
ON orders
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        IF EXISTS
        (
            SELECT 1
            FROM inserted
            WHERE order_status = 4
            AND shipped_date IS NULL
        )
        BEGIN
            RAISERROR('Shipped date must not be NULL when order is completed',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END

UPDATE orders
SET order_status = 4
WHERE order_id = 1;

UPDATE orders
SET order_status = 4,
    shipped_date = '2023-03-25'
WHERE order_id = 1;

------------------------------------------Level-2 Problem 3: Cursor-Based Revenue Calculation

CREATE TABLE #StoreRevenue
(
    store_id INT,
    order_id INT,
    revenue DECIMAL(12,2)
);




SELECT 
s.store_name,
SUM(sr.revenue) AS total_store_revenue
FROM #StoreRevenue sr
JOIN stores s
ON sr.store_id = s.store_id
GROUP BY s.store_name

