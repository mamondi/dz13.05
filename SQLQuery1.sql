CREATE DATABASE FruitsAndVegetables;

USE FruitsAndVegetables;

CREATE TABLE [Products] (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Type VARCHAR(10) NOT NULL CHECK (Type IN ('Fruit', 'Vegetable')),
    Color VARCHAR(30) NOT NULL,
    Calories INT NOT NULL
);

INSERT INTO [Products] (Name, Type, Color, Calories)
VALUES
    ('Apple', 'Fruit', 'Red', 52),
    ('Banana', 'Fruit', 'Yellow', 96),
    ('Carrot', 'Vegetable', 'Orange', 41),
    ('Spinach', 'Vegetable', 'Green', 23);

SELECT * FROM Products;