Create database sqlDay17;
use sqlDay17;

CREATE TABLE products
(
product_id INT PRIMARY KEY,
product_name VARCHAR(50)
);

CREATE TABLE stocks
(
product_id INT PRIMARY KEY,
quantity INT,
FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TABLE orders
(
order_id INT PRIMARY KEY,
customer_id INT,
order_status INT,
order_date DATE
);

CREATE TABLE order_items
(
item_id INT IDENTITY(1,1) PRIMARY KEY,
order_id INT,
product_id INT,
quantity INT,
list_price DECIMAL(10,2),

FOREIGN KEY(order_id) REFERENCES orders(order_id),
FOREIGN KEY(product_id) REFERENCES products(product_id)
);

INSERT INTO products VALUES
(1,'Laptop'),
(2,'Mobile'),
(3,'Keyboard');

INSERT INTO stocks VALUES
(1,10),
(2,15),
(3,20);

SELECT * FROM products;
SELECT * FROM stocks;
-------------------------------------------------Problem 1: Transactions and Trigger Implementation---------------
CREATE TRIGGER trg_UpdateStock
ON order_items
AFTER INSERT
AS
BEGIN

IF EXISTS(
SELECT 1
FROM stocks s
JOIN inserted i
ON s.product_id = i.product_id
WHERE s.quantity < i.quantity
)
BEGIN
RAISERROR('Insufficient Stock',16,1);
ROLLBACK TRANSACTION;
RETURN;
END

UPDATE s
SET s.quantity = s.quantity - i.quantity
FROM stocks s
JOIN inserted i
ON s.product_id = i.product_id;

END



BEGIN TRY

BEGIN TRANSACTION;

INSERT INTO orders
VALUES(101,1,1,GETDATE());

INSERT INTO order_items(order_id,product_id,quantity,list_price)
VALUES
(101,1,2,50000),
(101,2,1,20000);

COMMIT TRANSACTION;

PRINT 'Order placed successfully';

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION;

PRINT 'Order failed';

END CATCH

SELECT * FROM stocks;


----------------------------------Atomic Order Cancellation (SAVEPOINT)

BEGIN TRY

BEGIN TRANSACTION;

SAVE TRANSACTION BeforeRestore;

UPDATE s
SET s.quantity = s.quantity + oi.quantity
FROM stocks s
JOIN order_items oi
ON s.product_id = oi.product_id
WHERE oi.order_id = 101;

UPDATE orders
SET order_status = 3
WHERE order_id = 101;

COMMIT TRANSACTION;

PRINT 'Order Cancelled';

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION BeforeRestore;

PRINT 'Error restoring stock';

ROLLBACK TRANSACTION;

END CATCH



SELECT * FROM orders;
SELECT * FROM order_items;
SELECT * FROM stocks;