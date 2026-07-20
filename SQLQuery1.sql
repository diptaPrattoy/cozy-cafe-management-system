
CREATE TABLE Project_User (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(255) NULL,
    Password VARCHAR(255) NULL,
    Profile_Image VARCHAR(255) NULL,
    Role VARCHAR(255) NULL,
    Status VARCHAR(255) NULL,
    Date_Reg DATE NULL
);


SELECT * FROM Project_User;
SELECT * FROM project_User;

INSERT INTO Project_User (username, password, profile_image, role, status, date_reg) VALUES ('Admin', 'admin123', '', 'Admin', 'Active', '2025-02-03');



DROP TABLE Project_User ;

SELECT * FROM project_user WHERE status = 'Approval';




SELECT * FROM orders;

CREATE TABLE orders
(
id INT PRIMARY KEY IDENTITY(1,1),
customer_id INT NULL,
prod_id VARCHAR(MAX) NULL,
prod_type VARCHAR(MAX) NULL,
prod_price FLOAT NULL,
order_date DATE NULL,
delete_order DATE NULL
)



CREATE TABLE customers
(
id INT PRIMARY KEY IDENTITY(1,1),
customer_id INT NULL,
total_price FLOAT NULL,
date DATE NULL
)

ALTER TABLE customers
ADD amount FLOAT NULL

ALTER TABLE customers
ADD change FLOAT NULL


ALTER TABLE customer
ADD users VARCHAR (MAX) NULL


SELECT * FROM customers
INSERT INTO customers (customer_id, total_price, date) VALUES
(101, 250.75, '2024-01-01'),
(102, 180.50, '2024-01-02'),
(103, 320.00, '2024-01-03'),
(104, 150.25, '2024-01-04'),
(105, 275.60, '2024-01-05'),
(106, 400.90, '2024-01-06'),
(107, 125.75, '2024-01-07'),
(108, 350.40, '2024-01-08'),
(109, 290.20, '2024-01-09'),
(110, 310.80, '2024-01-10'),
(111, 275.00, '2024-01-11'),
(112, 185.30, '2024-01-12'),
(113, 295.40, '2024-01-13'),
(114, 450.60, '2024-01-14'),
(115, 210.90, '2024-01-15'),
(116, 360.75, '2024-01-16'),
(117, 140.50, '2024-01-17'),
(118, 280.60, '2024-01-18'),
(119, 335.20, '2024-01-19'),
(120, 500.00, '2024-01-20');

ALTER TABLE customers
ADD amount FLOAT NULL

ALTER TABLE customers
ADD change FLOAT NULL


ALTER TABLE customer
ADD users VARCHAR (MAX) NULL

SELECT * FROM customers
SELECT * FROM customers
INSERT INTO customers (customer_id, total_price, date) VALUES
(101, 250.75, '2024-01-01'),
(102, 180.50, '2024-01-02'),
(103, 320.00, '2024-01-03'),
(104, 150.25, '2024-01-04'),
(105, 275.60, '2024-01-05'),
(106, 400.90, '2024-01-06'),
(107, 125.75, '2024-01-07'),
(108, 350.40, '2024-01-08'),
(109, 290.20, '2024-01-09'),
(110, 310.80, '2024-01-10'),
(111, 275.00, '2024-01-11'),
(112, 185.30, '2024-01-12'),
(113, 295.40, '2024-01-13'),
(114, 450.60, '2024-01-14'),
(115, 210.90, '2024-01-15'),
(116, 360.75, '2024-01-16'),
(117, 140.50, '2024-01-17'),
(118, 280.60, '2024-01-18'),
(119, 335.20, '2024-01-19'),
(120, 500.00, '2024-01-20');




CREATE TABLE products2
(
id INT PRIMARY KEY IDENTITY(1,1),
prod_id VARCHAR(MAX) NULL,
prod_name VARCHAR(MAX) NULL,
prod_type VARCHAR(MAX) NULL,
prod_stock INT NULL,
prod_price FLOAT NULL,
prod_status VARCHAR(MAX) NULL,
date_insert DATE NULL,
date_update DATE NULL,
date_delete DATE NULL
)

INSERT INTO products2
(prod_id, prod_name, prod_type, prod_stock, prod_price, prod_status, date_insert)
VALUES
('PROD001', 'Cappuccino', 'Beverage', 50, 4.99, 'Available', GETDATE());


INSERT INTO products2 (prod_id, prod_name, prod_type, prod_stock, prod_price, prod_status, date_insert, date_update, date_delete)
VALUES
('PROD-1', 'Espresso', 'Beverage', 50, 2.50, 'Available', GETDATE(), NULL, NULL),
('PROD-2', 'Cappuccino', 'Beverage', 40, 3.50, 'Available', GETDATE(), NULL, NULL),
('PROD-3', 'Latte', 'Beverage', 45, 3.75, 'Available', GETDATE(), NULL, NULL),
('PROD-4', 'Mocha', 'Beverage', 35, 4.00, 'Available', GETDATE(), NULL, NULL),
('PROD-5', 'Americano', 'Beverage', 50, 2.75, 'Available', GETDATE(), NULL, NULL),
('PROD-6', 'Macchiato', 'Beverage', 30, 3.25, 'Available', GETDATE(), NULL, NULL),
('PROD-7', 'Iced Coffee', 'Beverage', 60, 3.00, 'Available', GETDATE(), NULL, NULL),
('PROD-8', 'Croissant', 'Pastry', 25, 2.50, 'Available', GETDATE(), NULL, NULL),
('PROD-9', 'Muffin', 'Pastry', 30, 2.75, 'Available', GETDATE(), NULL, NULL),
('PROD-10', 'Bagel', 'Pastry', 20, 3.00, 'Available', GETDATE(), NULL, NULL),
('PROD-11', 'Cheesecake', 'Dessert', 15, 4.50, 'Available', GETDATE(), NULL, NULL),
('PROD-12', 'Brownie', 'Dessert', 25, 3.25, 'Available', GETDATE(), NULL, NULL),
('PROD-13', 'Tiramisu', 'Dessert', 10, 5.00, 'Available', GETDATE(), NULL, NULL),
('PROD-14', 'Sandwich', 'Food', 35, 4.75, 'Available', GETDATE(), NULL, NULL),
('PROD-15', 'Panini', 'Food', 30, 5.25, 'Available', GETDATE(), NULL, NULL);





SELECT * FROM products2 WHERE date_delete IS NULL;


SELECT * FROM products2

SELECT * FROM products2 WHERE date_delete IS NULL
DELETE FROM products2 WHERE id = 2
SELECT * FROM products2 WHERE
DELETE FROM products2 WHERE prod_id = 'PROD-3'

CREATE TABLE orders
(
id INT PRIMARY KEY IDENTITY(1,1),
customer_id INT NULL,
prod_id VARCHAR(MAX) NULL,
prod_name VARCHAR(MAX) NULL,
prod_type VARCHAR(MAX) NULL,
prod_price FLOAT NULL,
order_date DATE NULL,
delete_order DATE NULL
)



CREATE TABLE orders
(
id INT PRIMARY KEY IDENTITY(1,1),
customer_id INT NULL,
prod_id VARCHAR(MAX) NULL,
prod_name VARCHAR(MAX) NULL,
prod_type VARCHAR(MAX) NULL,
prod_price FLOAT NULL,
order_date DATE NULL,
delete_order DATE NULL
)

select * from orders
DROP TABLE orders ;

ALTER TABLE orders
ADD qty INT NULL


SELECT COUNT(id) FROM users WHERE role = @role AND status = @status

                  
