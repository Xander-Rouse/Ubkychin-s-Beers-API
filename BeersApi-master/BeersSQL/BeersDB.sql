CREATE DATABASE BeersDB;

USE beersdb;

IF OBJECT_ID('Beer') IS NOT NULL
    DROP TABLE Beer;

CREATE Table Beer (
    [name] VARCHAR(50) PRIMARY KEY,
    brewery VARCHAR(50),
    abv DECIMAL,
    ibu INT,
    amount INT,
    cost DECIMAL,
    [open] BIT
)

INSERT INTO Beer VALUES ('Fosters', 'CUB', 4.5, 10, 375, 6.5, 0);
INSERT INTO Beer VALUES ('Fosters2', 'CUB', 4.5, 10, 375, 6.5, 0);
INSERT INTO Beer VALUES ('Fosters3', 'CUB', 4.5, 10, 375, 6.5, 0);
INSERT INTO Beer VALUES ('VB', 'CUB', 100, 10, 500, 7.5, 0);

SELECT *
FROM Beer