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
	img_url varchar(max),
	CONSTRAINT PK_plant PRIMARY KEY (plant_id),
	)
CREATE TABLE sellers (
	seller_id int IDENTITY(1,1) NOT NULL,
	seller_name varchar(50) NOT NULL,
	seller_type varchar(50) NOT NULL,
	address1 varchar(100),
	address2 varchar(100),
	city varchar(100),
	state nchar(2),
	zip varchar(9),
	website varchar(max)
	CONSTRAINT [PK_seller] PRIMARY KEY (seller_id),
	
	)

CREATE TABLE [events] (
	event_id int IDENTITY(1,1) NOT NULL,
	user_id int,
	address1 varchar(100),
	address2 varchar(100),
	city varchar(100),
	state nchar(2),
	zip varchar(9),
	website varchar(max),
	name varchar(max) NOT NULL,
	short_description varchar(max),
	long_description varchar(max),
	is_virtual bit NOT NULL,
	start_time datetime NOT NULL,
	end_time datetime NOT NULL,
	CONSTRAINT [PK_event] PRIMARY KEY (event_id),
	CONSTRAINT [FK_user_event] FOREIGN KEY (user_id) REFERENCES [users](user_id),
	)
--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

--populate test data
INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, img_url) VALUES ('Plantae','Poales', 'Poaceae','Pooideae','Poa','Poa Pratensis', 'Kentucky bluegrass', 'Poa pratensis, commonly known as Kentucky bluegrass (or blue grass), smooth meadow-grass, or common meadow-grass, is a perennial species of grass native to practically all of Europe, North Asia and the mountains of Algeria and Morocco. Although the species is spread over all of the cool, humid parts of the United States, it is not native to North America.','https://www.picturethisai.com/image-handle/website_cmsname/image/1080/154159742233608208.jpeg');
INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, img_url) VALUES ('Plantae','Orderia', 'Familius','SubFamilius','Geniusius', 'Plantus Supra Coolius','Very Cool Plant', 'Plants are extremely cool, we all love plants!!','./assets/genericplant.png');
INSERT INTO sellers (seller_name, seller_type) VALUES ('Fake Nursery', 'Retailer');
INSERT INTO events (user_id , address1 , city, state, zip, website, name, short_description, long_description, is_virtual, start_time, end_time) VALUES (2, '123 Main St',  'Columbus', 'OH', '12345', 'www.website.com', 'Columbus Garden Tour', 'Visit local home gardens in Columbus', 'This is a long description. It is so long.  I love plants', 0, '2023-08-14 09:30:00', '2023-08-14 13:45:00')
INSERT INTO events (user_id , website, name, short_description, long_description, is_virtual, start_time, end_time) VALUES (2, 'www.zoom.com/meeting123456', 'Green Morning America', 'Zoom chat for gardener talk', 'This is a long description. It is so long.  I love plants', 1, '2023-08-15 10:00:00', '2023-08-14 11:00:00')
GO