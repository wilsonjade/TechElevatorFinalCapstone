
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
	user_role varchar(50) NOT NULL,
	expertise_level int,
	first_name varchar(50) NOT NULL, 
	last_name varchar(50) NOT NULL, 
	email varchar(50) NOT NULL,
	region int NOT NULL,
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
	sun varchar(50) NOT NULL,
	water varchar(50) NOT NULL,
	fertilizer varchar(50) NOT NULL,
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
	zip varchar(10),
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
	zip varchar(10),
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

CREATE TABLE sellers_products (
	seller_id int NOT NULL,
	plant_id int NOT NULL
	CONSTRAINT [FK_inventory_seller] FOREIGN KEY (seller_id) REFERENCES [sellers](seller_id),
	CONSTRAINT [FK_inventory_plant] FOREIGN KEY (plant_id) REFERENCES [plants](plant_id)
)


	CREATE TABLE virtual_garden (
	user_id int NOT NULL,
	plant_id int NOT NULL,
	CONSTRAINT [FK_user_id] FOREIGN KEY (user_id) REFERENCES [users](user_id),
	CONSTRAINT [FK_plant_id] FOREIGN KEY (plant_id) REFERENCES [plants](plant_id),
	CONSTRAINT UC_plant_id UNIQUE (user_id,plant_id)
	)

CREATE TABLE [ratings] (
	rating_id int IDENTITY(1,1) NOT NULL,
	user_id int,
	seller_id int,
	title varchar(MAX),
	rating int,
	review varchar(MAX),
	CONSTRAINT [PK_rating_id] PRIMARY KEY (rating_id),
	CONSTRAINT [FK_user_rating] FOREIGN KEY (user_id) REFERENCES [users](user_id),
	CONSTRAINT [FK_seller_id] FOREIGN KEY (seller_id) REFERENCES [sellers](seller_id)
	)

	CREATE TABLE communications (
	communication_id int IDENTITY(1,1) NOT NULL,
	user_id int,
	type varchar(50),
	title varchar(160),
	start_time datetime NOT NULL,
	end_time datetime NOT NULL,
	CONSTRAINT [PK_communication_id] PRIMARY KEY (communication_id),
	CONSTRAINT [FK_user_communication] FOREIGN KEY (user_id) REFERENCES [users](user_id),
	)

	CREATE TABLE poll_options (
	option_id int IDENTITY(1,1) NOT NULL,
	poll_id int NOT NULL,
	text varchar(max),
	CONSTRAINT [PK_option_id] PRIMARY KEY (option_id),
	CONSTRAINT [FK_poll_id_options] FOREIGN KEY (poll_id) REFERENCES [communications](communication_id),
	)

	CREATE TABLE poll_response (
	response_id int IDENTITY(1,1) NOT NULL,
	user_id int,
	poll_id int,
	option_id int,
	submission_date datetime,
	CONSTRAINT [PK_response_id] PRIMARY KEY (response_id),
	CONSTRAINT [FK_user_id_poll_response] FOREIGN KEY (user_id) REFERENCES [users](user_id),
	CONSTRAINT [FK_poll_id_response] FOREIGN KEY (poll_id) REFERENCES [communications](communication_id),
	CONSTRAINT [FK_option_id] FOREIGN KEY (option_id) REFERENCES [poll_options](option_id),
	)


CREATE TABLE [tasks] (
	task_id int IDENTITY(1,1) NOT NULL,
	plant_id int NOT NULL,
	task_description varchar(MAX),
	task_category varchar(MAX),
	frequency_days int,
	CONSTRAINT [PK_task_id] PRIMARY KEY (task_id),
	CONSTRAINT [FK_plant_id2] FOREIGN KEY (plant_id) REFERENCES [plants](plant_id)
		)

CREATE TABLE [user_ack_task](
	user_id int NOT NULL,
	task_id int NOT NULL,
	last_ack datetime NOT NULL,
	CONSTRAINT [FK_user_id2] FOREIGN KEY (user_id) REFERENCES [users](user_id),
	CONSTRAINT [FK_task_id] FOREIGN KEY (task_id) REFERENCES [tasks](task_id),

)
--populate default data
INSERT INTO users (username, password_hash, salt, user_role, expertise_level, first_name, last_name, email, region) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user', 1, 'Jade', 'Wilson', 'jade@gmail.com', 2);
INSERT INTO users (username, password_hash, salt, user_role, expertise_level, first_name, last_name, email, region) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin', 2, 'Emily', 'Bates', 'emily@gmail.com', 3);

--populate test data
INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, sun, water, fertilizer, img_url) VALUES ('Plantae','Poales', 'Poaceae','Pooideae','Poa','Poa Pratensis', 'Kentucky bluegrass', 'Poa pratensis, commonly known as Kentucky bluegrass (or blue grass), smooth meadow-grass, or common meadow-grass, is a perennial species of grass native to practically all of Europe, North Asia and the mountains of Algeria and Morocco. Although the species is spread over all of the cool, humid parts of the United States, it is not native to North America.','full-sun','daily','biannually','https://www.picturethisai.com/image-handle/website_cmsname/image/1080/154159742233608208.jpeg');
INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, sun, water, fertilizer, img_url) VALUES ('Plantae','Orderia', 'Familius','SubFamilius','Geniusius', 'Plantus Supra Coolius','Very Cool Plant', 'Plants are extremely cool, we all love plants!!','partial-sun','weekly','annually','https://m.media-amazon.com/images/I/71iJ0ZK5rsL.__AC_SX300_SY300_QL70_FMwebp_.jpg');
INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, sun, water, fertilizer, img_url) VALUES('Plantae', 'Pinales', 'Pinaceae','', 'Pinus', 'P. sylvestris', 'Scoth Pine', 'Pinus sylvestris is an evergreen coniferous tree growing up to 35 metres (115 feet) in height[3] and 1 m (3 ft 3 in) in trunk diameter when mature,[4] exceptionally over 45 m (148 ft) tall and 1.7 m (5+1⁄2 ft) in trunk diameter on very productive sites.', 'shade','weekly','biannually','https://upload.wikimedia.org/wikipedia/commons/thumb/9/91/Skuleskogen_pine.jpg/330px-Skuleskogen_pine.jpg');
INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, sun, water, fertilizer, img_url) VALUES('Plantae', 'Zingiberales', 'Strelitziaceae', '', 'Strelitzia', 'S. reginia', 'Bird of Paradise', ' The leaves are evergreen and arranged in two ranks, making a fan-shaped crown. The flowers stand above the foliage at the tips of long stalks. The hard, beak-like sheath from which the flower emerges is termed the spathe.', 'partial-sun','daily','annually', 'https://upload.wikimedia.org/wikipedia/commons/thumb/5/55/Bird_of_Paradise_flower.JPG/330px-Bird_of_Paradise_flower.JPG');
INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, sun, water, fertilizer, img_url) VALUES('Plantae', 'Caryophyllales', 'Cactaceae', 'Cactoideae', 'Rhipsalidopsis', 'R. gaertneri', 'Spring Cactus', 'R. gaertneri grows on trees (epiphytic) or less often rocks (lithophytic) in sub-tropical rain forest. Together with the hybrid with R. rosea, Rhipsalidopsis × graeseri, it is known, in English speaking countries in the Northern Hemisphere, as Easter cactus or Whitsun cactus and is a widely cultivated ornamental plant.', 'full-sun','daily','biannually', 'https://upload.wikimedia.org/wikipedia/commons/c/c0/Hatiora_gaertneri.jpg');

INSERT INTO events (user_id , address1 , city, state, zip, website, name, short_description, long_description, is_virtual, start_time, end_time) VALUES (2, '123 Main St',  'Columbus', 'OH', '12345', 'www.website.com', 'Columbus Garden Tour', 'Visit local home gardens in Columbus', 'This is a long description. It is so long.  I love plants', 0, '2023-08-17 09:30:00', '2023-08-17 13:45:00')
INSERT INTO events (user_id , website, name, short_description, long_description, is_virtual, start_time, end_time) VALUES (2, 'www.zoom.com/meeting123456', 'Green Morning America', 'Zoom chat for gardener talk', 'This is a long description. It is so long.  I love plants', 1, '2023-08-15 10:00:00', '2023-08-16 11:00:00')
--past
INSERT INTO events (user_id , website, name, short_description, long_description, is_virtual, start_time, end_time) VALUES (2, 'www.pasteventtest.com/meeting123456', 'Green Morning America', 'Zoom chat for gardener talk', 'This is a long description. It is so long.  I love plants', 1, '2023-08-09 10:00:00', '2023-08-10 11:00:00')

INSERT INTO sellers (seller_name, seller_type) VALUES ('Fake Nursery', 'Retailer');
INSERT INTO sellers (seller_name ,seller_type ,address1 ,address2 ,city ,state ,zip ,website) VALUES ('Oakland Nursery Dublin','Retailer','4261 West Dublin-Granville Road','','Dublin','OH','43017','https://www.oaklandnursery.com/page/garden-centers/dublin');
INSERT INTO sellers (seller_name ,seller_type ,address1 ,address2 ,city ,state ,zip ,website) VALUES ('Oakland Nursery Columbus','Retailer','1156 Oakland Park Avenue','','Columbus','OH','43224-3317','https://www.oaklandnursery.com/page/garden-centers/columbus');
INSERT INTO sellers (seller_name ,seller_type ,address1 ,address2 ,city ,state ,zip ,website) VALUES ('Nature Hills','Online Seller','2336 S 156th Circle','','Omaha','NE','68130','https://www.naturehills.com/');
--populate test inventory records
INSERT INTO sellers_products (seller_id, plant_id) VALUES (1,1);
INSERT INTO sellers_products (seller_id, plant_id) VALUES (1,2);
INSERT INTO sellers_products (seller_id, plant_id) VALUES (1,3);
INSERT INTO sellers_products (seller_id, plant_id) VALUES (1,4);
INSERT INTO sellers_products (seller_id, plant_id) VALUES (2,2);
INSERT INTO sellers_products (seller_id, plant_id) VALUES (2,3);
INSERT INTO sellers_products (seller_id, plant_id) VALUES (3,1);
INSERT INTO sellers_products (seller_id, plant_id) VALUES (3,4);

INSERT INTO virtual_garden (user_id, plant_id) VALUES (1,1);
INSERT INTO virtual_garden (user_id, plant_id) VALUES (1,2);
INSERT INTO virtual_garden (user_id, plant_id) VALUES (2,3);
INSERT INTO virtual_garden (user_id, plant_id) VALUES (2,4);
INSERT INTO virtual_garden (user_id, plant_id) VALUES (2,5);


INSERT INTO ratings (user_id, seller_id, title, rating, review) VALUES (1, 1, 'Rating 1', 5, 'This is a review')
INSERT INTO ratings (user_id, seller_id, title, rating, review) VALUES (2, 2, 'Rating 2', 5, 'This is a review also')
INSERT INTO ratings (user_id, seller_id, title, rating, review) VALUES (2, 3, 'Rating 3', 5, 'This is a review also also')
INSERT INTO ratings (user_id, seller_id, title, rating, review) VALUES (1, 4, 'Rating 4', 5, 'This is a review also also also')
INSERT INTO ratings (user_id, seller_id, title, rating, review) VALUES (2, 1, 'Rating 5', 5, 'This is a review also also also also')

--communication id1
INSERT INTO communications (user_id, type, title,  start_time, end_time) 
	VALUES (2, 'poll', 'Which is your favorite hanging plant?', '2023-08-12 10:00:00', '2023-08-20 11:00:00');
INSERT INTO poll_options (poll_id, text) VALUES (1, 'Pothos');
INSERT INTO poll_options (poll_id, text) VALUES (1, 'String of Peals');
INSERT INTO poll_options (poll_id, text) VALUES (1, 'Spider Plant');
INSERT INTO poll_options (poll_id, text) VALUES (1, 'Philodendron');
INSERT INTO poll_response (user_id, poll_id, option_id, submission_date)
	VALUES (1, 1, 2, GETDATE());
INSERT INTO poll_response (user_id, poll_id, option_id, submission_date)
	VALUES (2, 1, 4, GETDATE());

--communication id2
INSERT INTO communications (user_id, type, title, start_time, end_time) 
	VALUES (2, 'competition', 'Enter your tallest plant height in order to win!', '2023-08-22 09:30:00', '2023-08-29 09:30:00');

--communication id3
INSERT INTO communications (user_id, type, title, start_time, end_time) 
	VALUES (2, 'challenge', 'Water your plants on time for one week to win a badge!', '2023-08-22 09:30:00', '2023-08-29 09:30:00');

--communication id4
INSERT INTO communications (user_id, type, title, start_time, end_time) 
	VALUES (2, 'poll', 'How many plants do you have in your home?', '2023-08-15 10:00:00', '2023-08-22 11:00:00');
INSERT INTO poll_options (poll_id, text) VALUES (4, '0-8');
INSERT INTO poll_options (poll_id, text) VALUES (4, '8-15');
INSERT INTO poll_options (poll_id, text) VALUES (4, '15-25');
INSERT INTO poll_options (poll_id, text) VALUES (4, '25+');
INSERT INTO poll_response (user_id, poll_id, option_id, submission_date)
	VALUES (1, 2, 5, GETDATE());
INSERT INTO poll_response (user_id, poll_id, option_id, submission_date)
	VALUES (2, 2, 7, GETDATE());
		   
--communication id5
INSERT INTO communications (user_id, type, title, start_time, end_time) 
	VALUES (2, 'poll', 'What was your first houseplant?', '2023-08-20 09:30:00', '2023-08-27 09:30:00');
INSERT INTO poll_options (poll_id, text) VALUES (5, 'Cactus');
INSERT INTO poll_options (poll_id, text) VALUES (5, 'Pothos');
INSERT INTO poll_options (poll_id, text) VALUES (5, 'Monstera');
INSERT INTO poll_options (poll_id, text) VALUES (5, 'Succulent');
INSERT INTO poll_response (user_id, poll_id, option_id, submission_date)
	VALUES (1, 3, 10, GETDATE());
INSERT INTO poll_response (user_id, poll_id, option_id, submission_date)
	VALUES (2, 3, 12, GETDATE());

--communication id6
INSERT INTO communications (user_id, type, title, start_time, end_time) 
	VALUES (2, 'poll', 'Do you prefer indoor plants or outdoor gardening?', '2023-08-16 09:30:00', '2023-08-23 09:30:00');
INSERT INTO poll_options (poll_id, text) VALUES (6, 'Indoor');
INSERT INTO poll_options (poll_id, text) VALUES (6, 'Outdoor');
INSERT INTO poll_options (poll_id, text) VALUES (6, 'Standard programmer answer: it depends.');
INSERT INTO poll_options (poll_id, text) VALUES (6, 'Little of both!');
INSERT INTO poll_response (user_id, poll_id, option_id, submission_date)
	VALUES (1, 4, 14, GETDATE());
INSERT INTO poll_response (user_id, poll_id, option_id, submission_date)
	VALUES (2, 4, 15, GETDATE());

--communication id7
INSERT INTO communications (user_id, type, title, start_time, end_time) 
	VALUES (2, 'poll', 'What is the best houseplant for beginners?', '2023-08-22 09:30:00', '2023-08-29 09:30:00');
INSERT INTO poll_options (poll_id, text) VALUES (7, 'Succulent');
INSERT INTO poll_options (poll_id, text) VALUES (7, 'Palm');
INSERT INTO poll_options (poll_id, text) VALUES (7, 'Snake Plant');
INSERT INTO poll_options (poll_id, text) VALUES (7, 'Pothos');
INSERT INTO poll_response (user_id, poll_id, option_id, submission_date)
	VALUES (1, 5, 18, GETDATE());
INSERT INTO poll_response (user_id, poll_id, option_id, submission_date)
	VALUES (2, 5, 20, GETDATE());


--populate tasks table
INSERT INTO tasks (plant_id, task_category, frequency_days) VALUES (1, 'water', 1)
INSERT INTO tasks (plant_id, task_category, frequency_days) VALUES (1, 'fertilizer', 180)
INSERT INTO tasks (plant_id, task_category, frequency_days) VALUES (2, 'water', 7)
INSERT INTO tasks (plant_id, task_category, frequency_days) VALUES (2, 'fertilizer', 365)

--populate user_ack_task table

INSERT INTO user_ack_task(user_id, task_id, last_ack) VALUES (1, 1, '2023-08-13')
INSERT INTO user_ack_task(user_id, task_id, last_ack) VALUES (1, 2, '2023-02-13')
INSERT INTO user_ack_task(user_id, task_id, last_ack) VALUES (1, 3, '2023-08-03')
INSERT INTO user_ack_task(user_id, task_id, last_ack) VALUES (1, 4, '2023-05-13')

GO

