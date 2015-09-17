CREATE DATABASE db_scription

USE db_scription
GO

CREATE TABLE Contato(
	IDContato INT IDENTITY(1,1) PRIMARY KEY NOT NULL ,
	Nome varchar(100) NOT NULL,
	Telefone varchar(20) NOT NULL,
	Email varchar (100) NOT NULL
)

