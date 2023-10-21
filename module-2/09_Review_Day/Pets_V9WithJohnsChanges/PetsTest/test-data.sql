BEGIN TRANSACTION;

CREATE TABLE Pet (
    id   INT NOT NULL IDENTITY (1,1),
	name NVARCHAR(60) NOT NULL,
	age INT NOT NULL,
	type NVARCHAR(60) NOT NULL,
	CONSTRAINT PK_id PRIMARY KEY (id)
);

INSERT INTO Pet (name, age, type) VALUES ('BBBBB', 6, 'dog');
INSERT INTO Pet (name, age, type) VALUES ('PPPPP', 12, 'cat');
INSERT INTO Pet (name, age, type) VALUES ('GGGGG', 12, 'cat');
INSERT INTO Pet (name, age, type) VALUES ('Penny', 12, 'cat');

COMMIT TRANSACTION;
