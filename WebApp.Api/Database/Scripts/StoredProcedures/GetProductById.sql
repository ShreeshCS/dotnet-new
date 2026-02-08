CREATE PROCEDURE GetProductById(IN productId CHAR(36))
BEGIN
    SELECT p.Id, p.Name, p.Price, p.Description, c.Id AS CategoryId, c.Name AS CategoryName
    FROM Products p
    LEFT JOIN Categories c ON p.CategoryId = c.Id
    WHERE p.Id = productId;
END;
