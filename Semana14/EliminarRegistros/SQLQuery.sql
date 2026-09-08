SELECT * FROM Categories;

select * from Products where CategoryID=13

update products set categoryid=14 where ProductID=87;

SELECT * FROM Categories where CategoryID=1

delete FROM Categories where CategoryID=1

ALTER TABLE Products
ADD CONSTRAINT FK_Products_Categories 
FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID) ON DELETE CASCADE;

SELECT * FROM Products
WHERE CategoryID=13

INSERT INTO Products(ProductName,UnitPrice,CategoryID)
VALUES ('Producto 1',10,13);
INSERT INTO Products(ProductName,UnitPrice,CategoryID)
VALUES ('Producto 2',10,13);
INSERT INTO Products(ProductName,UnitPrice,CategoryID)
VALUES ('Producto 3',10,13);

BEGIN TRAN;
delete FROM Products OUTPUT DELETED.ProductID,DELETED.ProductName,
DELETED.UnitPrice,DELETED.CategoryID
WHERE CategoryID=13;
COMMIT;
ROLLBACK;
