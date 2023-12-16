DROP DATABASE Veterinary_elmonas
GO
CREATE DATABASE Veterinary_elmonas
GO
USE Veterinary_elmonas
GO
CREATE TABLE customers
(
	customer_code INT IDENTITY(1,1),
	customer_name VARCHAR(30) NOT NULL,
	customer_sex BIT NOT NULL,
	creation_date DATETIME NOT NULL,
	termination_date DATETIME,
	CONSTRAINT pk_customers PRIMARY KEY (customer_code)
)
CREATE TABLE pet_types
(
	type_code INT IDENTITY(1,1),
	type_description VARCHAR(30) NOT NULL,
	creation_date DATETIME NOT NULL,
	termination_date DATETIME,
	CONSTRAINT pk_pet_types PRIMARY KEY (type_code)
)
CREATE TABLE pets
(
	pet_code INT IDENTITY(1,1),
	pet_name VARCHAR(30) NOT NULL,
	pet_type INT NOT NULL,
	birth_date DATETIME,
	owner_code INT,
	creation_date DATETIME NOT NULL,
	termination_date DATETIME,
	CONSTRAINT pk_pets PRIMARY KEY (pet_code),
	CONSTRAINT fk_pets_cus FOREIGN KEY (owner_code)
		REFERENCES customers (customer_code),
	CONSTRAINT fk_pets_types FOREIGN KEY (pet_type)
		REFERENCES pet_types(type_code)
)

CREATE TABLE attentions
(
	attention_code INT IDENTITY(1,1),
	attention_description VARCHAR(200) NOT NULL,
	attention_amount DECIMAL(10,2) NOT NULL,
	attention_date DATETIME NOT NULL,
	pet_code INT NOT NULL,
	termination_date DATETIME,
	CONSTRAINT pk_attention PRIMARY KEY (attention_code),
	CONSTRAINT fk_atte_pets FOREIGN KEY (pet_code)
		REFERENCES pets(pet_code)
)
GO

CREATE PROCEDURE SP_GET_CUSTOMER
	@code INT
AS
BEGIN
	SELECT customer_name, customer_sex, customer_code
	FROM customers
	WHERE termination_date IS NULL
	AND customer_code = @code
END

GO

CREATE PROCEDURE SP_GET_CUSTOMERS
AS
BEGIN
	SELECT customer_name, customer_sex, customer_code
	FROM customers
	WHERE termination_date IS NULL
END

GO

CREATE PROCEDURE SP_GET_CUSTOMERS_FILTERED
	@from_date DATETIME, @to_date DATETIME, @name VARCHAR(30), @sex VARCHAR(1) = '%', @code VARCHAR(12) = '%'
AS
BEGIN
	SELECT customer_code, customer_name, customer_sex, creation_date
	FROM customers
	WHERE termination_date IS NULL
	AND creation_date BETWEEN @from_date AND @to_date
	AND customer_name LIKE '%' + @name + '%'
	AND customer_sex LIKE @sex
	AND customer_code LIKE @code
END

GO

CREATE PROCEDURE SP_ADD_CUSTOMER
	@name VARCHAR(30), @sex BIT
AS
BEGIN
	INSERT INTO customers(customer_name, customer_sex, creation_date)
	OUTPUT inserted.customer_code
	VALUES (@name, @sex, GETDATE())
END

GO
CREATE PROCEDURE SP_DELETE_CUSTOMER
	@code INT
AS
BEGIN
	UPDATE customers
	SET creation_date = GETDATE()
	WHERE customer_code = @code;
	UPDATE pets
	SET termination_date = GETDATE()
	WHERE owner_code = @code;
	UPDATE attentions
	SET termination_date = GETDATE()
	WHERE attention_code IN (SELECT attention_code
	                       FROM attentions a JOIN pets p ON a.pet_code = p.pet_code
						   WHERE owner_code = @code)
END

GO

CREATE PROCEDURE SP_MODIFY_CUSTOMER
	@name VARCHAR(30), @sex BIT, @code INT
AS
BEGIN
	UPDATE customers
	SET customer_name = @name, customer_sex = @sex
	OUTPUT inserted.customer_code
	WHERE customer_code = @code
END

GO

CREATE PROCEDURE SP_GET_PETS_FILTERED
	@from_date DATETIME, @to_date DATETIME, @customer_name VARCHAR(30), @pet_name VARCHAR(30), @code VARCHAR(12) = '%', @type VARCHAR(12) = '%', @age VARCHAR(12) = '%'
AS
BEGIN
	SELECT pet_code, customer_name, pet_name, type_description, DATEDIFF(YEAR, birth_date, GETDATE()), p.creation_date, birth_date, customer_code, type_code
	FROM pets p JOIN pet_types t ON pet_type = type_code JOIN customers c ON owner_code = customer_code
	WHERE p.termination_date IS NULL
	AND customer_name LIKE '%' + @customer_name + '%'
	AND pet_name LIKE '%' + @pet_name + '%'
	AND p.creation_date BETWEEN @from_date AND @to_date
	AND pet_type LIKE @type
	AND pet_code LIKE @code
	AND DATEDIFF(YEAR, birth_date, GETDATE()) LIKE @age
END

GO

CREATE PROCEDURE SP_GET_PETS_BY_CUSTOMER
	@customer_code INT
AS
BEGIN
	SELECT pet_name, DATEDIFF(YEAR, birth_date, GETDATE()), type_description, pet_code, type_code
	FROM pets p JOIN pet_types t ON pet_type = type_code
	WHERE owner_code = @customer_code
	AND p.termination_date IS NULL
END

GO

CREATE PROCEDURE SP_ADD_PET
	@name VARCHAR(30), @type INT, @birth_date DATETIME, @owner_code INT
AS
BEGIN
	INSERT INTO pets(pet_name, pet_type, birth_date, pet_code, creation_date)
	OUTPUT inserted.pet_code
	VALUES(@name, @type, @birth_date, @owner_code, GETDATE())
END

GO

CREATE PROCEDURE SP_DELETE_PET
	@code INT
AS
BEGIN
	UPDATE pets
	SET termination_date = GETDATE()
	WHERE pet_code = @code;
	UPDATE attentions
	SET termination_date = GETDATE()
	WHERE pet_code = @code;
END

GO

CREATE PROCEDURE SP_MODIFY_PET
	@code INT, @name VARCHAR(30), @type INT, @birth_date DATETIME
AS
BEGIN
	UPDATE pets
	SET pet_name = @name, pet_type = @type, birth_date = @birth_date
	WHERE pet_code = @code
END

GO
CREATE PROCEDURE SP_GET_TYPES
AS
BEGIN
	SELECT type_code, type_description
	FROM pet_types
	WHERE creation_date IS NULL
END

GO

CREATE PROCEDURE SP_ADD_TYPE
	@description VARCHAR(30)
AS
BEGIN
	INSERT INTO pet_types(type_description, creation_date)
	VALUES (@description, GETDATE())
END

GO

CREATE PROCEDURE SP_GET_ATTENTION
	@code INT
AS
BEGIN
	SELECT attention_code, attention_description, attention_amount, attention_date
	FROM attentions
	WHERE attention_code = @code
END

GO

CREATE PROCEDURE SP_GET_ATTENTIONS
	@from_date DATETIME, @to_date DATETIME, @code VARCHAR(12) = '%', @min_amount DECIMAL(10,2) = -99999999.99, @max_amount DECIMAL(10,2) = 99999999.99, @customer_name VARCHAR(30), @pet_name VARCHAR(30), @description VARCHAR(200)
AS
BEGIN
	SELECT attention_code, customer_code, pet_name + ' - ' + type_description, attention_description, attention_date, attention_amount
	FROM attentions a JOIN pets p ON a.pet_code = p.pet_code JOIN customers c ON owner_code = customer_code JOIN pet_types t ON pet_type = type_code
	WHERE a.termination_date IS NULL
	AND attention_date BETWEEN @from_date AND @to_date
	AND attention_code LIKE @code
	AND attention_amount BETWEEN @min_amount AND @max_amount
	AND customer_name LIKE '%' + @customer_name + '%'
	AND pet_name LIKE '%' + @pet_name + '%'
	AND attention_description LIKE '%' + @description + '%'
END

GO

CREATE PROCEDURE SP_GET_ATTENTIONS_BY_PET
	@pet_code INT
AS
BEGIN
	SELECT attention_code, attention_description, attention_amount, attention_date
	FROM attentions
	WHERE pet_code = @pet_code
	AND termination_date IS NULL
END

GO

CREATE PROCEDURE SP_ADD_ATTENTION
	@description VARCHAR(200), @amount DECIMAL(10,2), @date DATETIME, @pet_code INT
AS
BEGIN
	INSERT INTO attentions(attention_description, attention_amount, attention_date, pet_code) VALUES (@description, @amount, @date, @pet_code)
END

GO

CREATE PROCEDURE SP_DELETE_ATTENTION
	@code INT
AS
BEGIN
	UPDATE attentions
	SET termination_date = GETDATE()
	WHERE attention_code = @code
END
GO

CREATE PROCEDURE SP_MODIFY_ATTENTION
	@description VARCHAR(200), @amount DECIMAL(10,2), @date DATETIME, @code INT
AS
BEGIN
	UPDATE attentions
	SET attention_description = @description, attention_amount = @amount, attention_date = @date
	WHERE attention_code = @code
END

GO
SET DATEFORMAT DMY
INSERT INTO customers(customer_name, customer_sex, creation_date) VALUES ('Thomas', 1, '04/10/2022')
INSERT INTO customers(customer_name, customer_sex, creation_date) VALUES ('Mary', 0, '15/08/2023')
GO
INSERT INTO pet_types(type_description, creation_date) VALUES ('Dog', '01/01/2022')
INSERT INTO pet_types(type_description, creation_date) VALUES ('Cat', '01/01/2022')
INSERT INTO pet_types(type_description, creation_date) VALUES ('Spider', '01/01/2022')
INSERT INTO pet_types(type_description, creation_date) VALUES ('Iguana', '01/01/2022')
GO
INSERT INTO pet_types(type_description, creation_date) VALUES ('Boby', 1, '20/05/2022', 1, '29/12/2022')
INSERT INTO pet_types(type_description, creation_date) VALUES ('Puff', 2, '30/03/2021', 1, '04/10/2022')
INSERT INTO pet_types(type_description, creation_date) VALUES ('Kosmo', 3, '10/05/2022', 2, '10/05/2022')
INSERT INTO pet_types(type_description, creation_date) VALUES ('Cactus', 4, '02/06/2023', 2, '15/08/2023')
GO
INSERT INTO attentions(attention_description, attention_amount, attention_date, pet_code) VALUES ('Complete vaccination', 600,'29/12/2022', 1)
INSERT INTO attentions(attention_description, attention_amount, attention_date, pet_code) VALUES ('Castration', 200,'04/10/2022', 2)
INSERT INTO attentions(attention_description, attention_amount, attention_date, pet_code) VALUES ('Checkup', 900,'15/08/2023', 4)
