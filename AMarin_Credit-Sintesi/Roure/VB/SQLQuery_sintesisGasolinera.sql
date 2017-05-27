
CREATE DATABASE Gasolinera;
GO
USE Gasolinera;
GO
CREATE TABLE deposits
(
	iddeposit INT IDENTITY(1,1) PRIMARY KEY,
	idcarburant INT FOREIGN KEY REFERENCES carburant(idcarburant),
	capacitat DECIMAL(8,2) NOT NULL CHECK(Capacitat <= 10000),
) 

CREATE TABLE carburant
(
	idcarburant INT IDENTITY(1,1) PRIMARY KEY,
	tipus VARCHAR(100) NOT NULL,
	preu_litre DECIMAL(4,2),
)

CREATE TABLE estat_sortidor
(
	idestat INT IDENTITY(1,1) PRIMARY KEY,
	estat VARCHAR(100) NOT NULL,
)

CREATE TABLE sortidor
(
	idsortidor INT IDENTITY(1,1) PRIMARY KEY,
	estat INT FOREIGN KEY REFERENCES estat_sortidor(idestat),
	carburant1 INT FOREIGN KEY REFERENCES carburant(idcarburant),
	carburant2 INT FOREIGN KEY REFERENCES carburant(idcarburant),
	deposit1 INT FOREIGN KEY REFERENCES deposits(iddeposit),
	deposit2 INT FOREIGN KEY REFERENCES deposits(iddeposit),
)

CREATE TABLE comandes
(
	idcomanda INT IDENTITY(1,1) PRIMARY KEY,
	carburant INT FOREIGN KEY REFERENCES carburant(idcarburant),
	quantitat INT NOT NULL,
)

CREATE TABLE articles
(
	idarticle INT IDENTITY(1,1) PRIMARY KEY,
	article VARCHAR(100) NOT NULL,
	preu DECIMAL(4,2) NOT NULL,
)

CREATE TABLE usuaris
(
	idusuari INT IDENTITY(1,1) PRIMARY KEY,
	usuari VARCHAR(100) NOT NULL,
	pin VARCHAR(100) NOT NULL,
	targeta_credit VARCHAR(100),
)

 CREATE TABLE tickets_sortidors
(
	idticketsort INT IDENTITY(1,1) PRiMARY KEY,
	idusuari INT FOREIGN KEY REFERENCES usuaris(idusuari),
	carburant INT FOREIGN KEY REFERENCES carburant(idcarburant),
	sortidor INT FOREIGN KEY REFERENCES sortidor(idsortidor),
	data DATE NOT NULL,
	litres DECIMAL(8,2) NOT NULL,
	total DECIMAL(5,2) ,
)

CREATE TABLE tickets_articles
(
	idticketart INT IDENTITY(1,1) PRIMARY KEY,
	idusuari INT FOREIGN KEY REFERENCES usuaris(idusuari),
	data DATE NOT NULL,
	article INT FOREIGN KEY REFERENCES articles(idarticle),
	quantitat SMALLINT NOT NULL,
	total DECIMAL(5,2) ,
)


--Triggers para pedido y para los totales de tiquets
CREATE TRIGGER tr_comanda
ON deposits
AFTER UPDATE
AS
DECLARE @carburant INT = (SELECT idcarburant FROM deposits WHERE capacitat <= 1000)
DECLARE @capacitat DECIMAL(8,2) = (SELECT capacitat FROM deposits WHERE idcarburant=@carburant)
DECLARE @total DECIMAL(8,2) = (@capacitat+9000)
IF (@carburant IS NOT NULL)
BEGIN
	INSERT INTO comandes (carburant, quantitat) VALUES (@carburant,9000)
	UPDATE deposits SET capacitat = @total WHERE idcarburant = @carburant
END
GO