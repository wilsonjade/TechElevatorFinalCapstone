USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)
CREATE TABLE plants (
	plant_id int IDENTITY(1,1) NOT NULL,
	kingdom varchar(50),
	[order] varchar(50),
	family varchar(50),
	subfamily varchar(50),
	genus varchar(50),
	species varchar(50),
	common_name varchar(50),
	description varchar(max),
	CONSTRAINT PK_plant PRIMARY KEY (plant_id),
	)
CREATE TABLE sellers (
	seller_id int IDENTITY(1,1) NOT NULL,
	seller_name varchar(50) NOT NULL,
	seller_type varchar(50) NOT NULL,
	is_user int NOT NULL,
	user_id int,
	address1 varchar(100),
	address2 varchar(100),
	city varchar(100),
	state nchar(2),
	zip varchar(9),
	website varchar(max)
	CONSTRAINT [PK_seller] PRIMARY KEY (seller_id),
	CONSTRAINT [FK_user] FOREIGN KEY (user_id) REFERENCES [users](user_id), 
)

--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

--populate test data
INSERT INTO plants (kingdom, species, description) VALUES ('Plantae','Poa Pratensis', 'Kentucky bluegrass');
INSERT INTO plants (kingdom, species, description) VALUES ('Plantae','Plantus scientificus', 'This is a plant!');
INSERT INTO sellers (seller_name, seller_type, is_user) VALUES ('Fake Nursery', 'Retailer', 0);

GO