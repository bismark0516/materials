/* Deployment script for PetInfo */
USE master;
GO

IF DB_ID('PetInfo') IS NOT NULL
BEGIN
	ALTER DATABASE PetInfo SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE PetInfo;
END
GO

CREATE DATABASE PetInfo;
GO

USE PetInfo
GO

CREATE TABLE Pet (
    id   INT NOT NULL IDENTITY (1,1),
	name NVARCHAR(60) NOT NULL,
	age INT NOT NULL,
	type NVARCHAR(60) NOT NULL,
	CONSTRAINT PK_id PRIMARY KEY (id)
);


INSERT INTO Pet (name, age, type) VALUES ('Bella', 6, 'dog');
INSERT INTO Pet (name, age, type) VALUES ('Primrose', 12, 'cat');
INSERT INTO Pet (name, age, type) VALUES ('Gabe', 12, 'cat');
INSERT INTO Pet (name, age, type) VALUES ('Penny', 12, 'cat');

