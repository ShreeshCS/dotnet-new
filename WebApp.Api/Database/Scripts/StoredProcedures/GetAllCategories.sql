DROP PROCEDURE IF EXISTS GetAllCategories;
CREATE PROCEDURE GetAllCategories()
BEGIN
    SELECT Id, Name FROM Categories;
END;
