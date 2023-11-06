USE master
GO

IF DB_ID('petinfo') IS NOT NULL
BEGIN
	ALTER DATABASE petinfo SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE petinfo;
END

CREATE DATABASE petinfo
GO

USE petinfo
GO

CREATE TABLE petinfo_user (
	user_id int IDENTITY(1001,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	[role] varchar(20) NOT NULL,
	CONSTRAINT PK_user PRIMARY KEY (user_id),
	CONSTRAINT UQ_username UNIQUE (username)
)

CREATE TABLE Pet (
    id   INT NOT NULL IDENTITY (1,1),
	name NVARCHAR(60) NOT NULL,
	age INT NOT NULL,
	type NVARCHAR(60) NOT NULL,
	owner INT NOT NULL DEFAULT 0
	CONSTRAINT PK_pet_id PRIMARY KEY (id)
);

CREATE TABLE Owner (
    id   INT NOT NULL IDENTITY (1,1),
	name NVARCHAR(60) NOT NULL,
	email NVARCHAR(60) NOT NULL,
	CONSTRAINT PK_owner_id PRIMARY KEY (id)
);

SET IDENTITY_INSERT Pet ON 
INSERT INTO Pet (id, name, age, type, owner) VALUES (1, 'Bella', 6, 'dog', 1);
INSERT INTO Pet (id, name, age, type, owner) VALUES (2, 'Primrose', 12, 'cat', 2);
INSERT INTO Pet (id, name, age, type, owner) VALUES (3, 'Gabe', 12, 'cat', 2);
INSERT INTO Pet (id, name, age, type, owner) VALUES (4, 'Penny', 12, 'cat', 2);
SET IDENTITY_INSERT Pet OFF 

SET IDENTITY_INSERT Owner ON 
INSERT INTO Owner (id, name, email) VALUES (1, 'John', 'john@johnfulton.org');
INSERT INTO Owner (id, name, email) VALUES (2, 'Lisa', 'lisa@bruegge-fulton.org');
SET IDENTITY_INSERT Owner Off 

ALTER TABLE Pet
ADD CONSTRAINT FK_pet_id_owner_id 
FOREIGN KEY (owner) REFERENCES Owner(id);
