USE [master];
GO

IF DB_ID('PetInfo') IS NOT NULL
BEGIN
	ALTER DATABASE [PetInfo] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE [PetInfo];
END

CREATE DATABASE [PetInfo];
GO

USE [PetInfo];
GO

CREATE TABLE owner (
	owner_id int IDENTITY PRIMARY KEY,
	name VARCHAR(60) NOT NULL,
	address VARCHAR(200) NOT NULL,
	phone VARCHAR(20) NOT NULL,
	email VARCHAR(40) NOT NULL,
);

CREATE TABLE available_procedure(
avail_procedures_id int  IDENTITY PRIMARY KEY,
name VARCHAR(60) NOT NULL,
pet_type VARCHAR(20) NOT NULL,
price DECIMAL (5,2)
)

CREATE TABLE [procedure](
procedure_id INT IDENTITY PRIMARY KEY,
pet_id int NOT NULL,
date DATE NOT NULL,
avail_procedure_id INT NOT NULL
)

CREATE TABLE pet(
pet_id int IDENTITY PRIMARY KEY,
name VARCHAR(60) NOT NULL,
type VARCHAR(20) NOT NULL,
age int NOT NULL,
)

INSERT INTO pet (name, type, age) VALUES ('Bella', 'dog', 6);

INSERT INTO available_procedure (name, pet_type, price) VALUES ('Nail Trim', 'dog', 20.00)

INSERT INTO [procedure] (pet_id, date, avail_procedure_id) VALUES (1, '2023-10-16', 1);



ALTER TABLE [procedure] WITH CHECK ADD CONSTRAINT [FK_procedure_id_available_procedure]
FOREIGN KEY (procedure_id) REFERENCES available_procedure(avail_procedures_id)


ALTER TABLE [procedure] WITH CHECK ADD CONSTRAINT [FK_pet_id_pet]
FOREIGN KEY (pet_id) REFERENCES pet(pet_id)

