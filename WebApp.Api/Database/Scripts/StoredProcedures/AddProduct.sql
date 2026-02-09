DROP PROCEDURE IF EXISTS AddProduct;
CREATE PROCEDURE AddProduct(
    IN Name VARCHAR(100),
    IN Description VARCHAR(500),
    IN Price DECIMAL(18,2),
    IN CategoryId INT
)
BEGIN
    INSERT INTO Products (Id, Name, Description, Price, CategoryId)
    VALUES (UUID(), Name, Description, Price, CategoryId);
    SELECT LAST_INSERT_ID() AS NewProductId;
END;