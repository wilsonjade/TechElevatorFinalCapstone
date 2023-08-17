
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
INSERT INTO users (username, password_hash, salt, user_role, expertise_level, first_name, last_name, email, region) VALUES ('mitch','uVCwKlk+qTovYsiaZQtaQjFqMvI=', 'j5du0U5vQa0=','user', 2, 'Mitch', 'Essig', 'mitch.essig@gmail.com', 6);

--populate test data
INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, sun, water, fertilizer, img_url) VALUES ('Plantae','Poales', 'Poaceae','Pooideae','Poa','Poa Pratensis', 'Kentucky bluegrass', 'Poa pratensis, commonly known as Kentucky bluegrass (or blue grass), smooth meadow-grass, or common meadow-grass, is a perennial species of grass native to practically all of Europe, North Asia and the mountains of Algeria and Morocco. Although the species is spread over all of the cool, humid parts of the United States, it is not native to North America.','full-sun','daily','biannually','https://www.picturethisai.com/image-handle/website_cmsname/image/1080/154159742233608208.jpeg');
INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, sun, water, fertilizer, img_url) VALUES('Plantae', 'Pinales', 'Pinaceae','', 'Pinus', 'P. sylvestris', 'Scoth Pine', 'Pinus sylvestris is an evergreen coniferous tree growing up to 35 metres (115 feet) in height[3] and 1 m (3 ft 3 in) in trunk diameter when mature,[4] exceptionally over 45 m (148 ft) tall and 1.7 m (5+1⁄2 ft) in trunk diameter on very productive sites.', 'shade','weekly','biannually','https://upload.wikimedia.org/wikipedia/commons/thumb/9/91/Skuleskogen_pine.jpg/330px-Skuleskogen_pine.jpg');
INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, sun, water, fertilizer, img_url) VALUES('Plantae', 'Zingiberales', 'Strelitziaceae', '', 'Strelitzia', 'S. reginia', 'Bird of Paradise', ' The leaves are evergreen and arranged in two ranks, making a fan-shaped crown. The flowers stand above the foliage at the tips of long stalks. The hard, beak-like sheath from which the flower emerges is termed the spathe.', 'partial-sun','daily','annually', 'https://upload.wikimedia.org/wikipedia/commons/thumb/5/55/Bird_of_Paradise_flower.JPG/330px-Bird_of_Paradise_flower.JPG');
INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, sun, water, fertilizer, img_url) VALUES('Plantae', 'Caryophyllales', 'Cactaceae', 'Cactoideae', 'Rhipsalidopsis', 'R. gaertneri', 'Spring Cactus', 'R. gaertneri grows on trees (epiphytic) or less often rocks (lithophytic) in sub-tropical rain forest. Together with the hybrid with R. rosea, Rhipsalidopsis × graeseri, it is known, in English speaking countries in the Northern Hemisphere, as Easter cactus or Whitsun cactus and is a widely cultivated ornamental plant.', 'full-sun','daily','biannually', 'https://upload.wikimedia.org/wikipedia/commons/c/c0/Hatiora_gaertneri.jpg');
--test data for search plant
INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, sun, water, fertilizer, img_url) VALUES('Plantae', 'Zingiberales', 'Strelitziaceae', '', 'Strelitzia', 'S. caudata', 'Wild Banana', 'Growing up to 8 metres tall, it has a leafless woody stem and has a fan shaped crown.The leaves are 2 by 0.6m, greyish-green in colour and are arranged in two vertical ranks. The seeds are black with a tuft of bright orange hairs.', 'partial-sun','daily','annually', 'https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/Fleur_du_Strelitzia_Caudata_._Elle_est_tr%C3%A8s_ressemblante_a_celle_du_Strelitzia_Nicolai_%28_Strelitzia_blanc_%29.jpg/800px-Fleur_du_Strelitzia_Caudata_._Elle_est_tr%C3%A8s_ressemblante_a_celle_du_Strelitzia_Nicolai_%28_Strelitzia_blanc_%29.jpg');
INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, sun, water, fertilizer, img_url) VALUES('Plantae', 'Zingiberales', 'Strelitziaceae', '', 'Phenakospermim', 'P.guyannense', 'Phenakospermum Guyannense', 'Phenakospermum is a monotypic genus in the family Strelitziaceae. Only one species is recognized, Phenakospermum guyannense, native to Suriname, French Guiana and the eastern Amazon River basin. This plant grows to over 10 m in height but can be felled with a single blow with a machete.', 'full-sun','daily','biannually', 'https://upload.wikimedia.org/wikipedia/commons/thumb/1/10/Phenakospermum_guyannense_BotGardBln08112010C.JPG/800px-Phenakospermum_guyannense_BotGardBln08112010C.JPG');
INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, sun, water, fertilizer, img_url) VALUES('Plantae', 'Zingiberales', 'Strelitziaceae', '', 'Ravenala', 'R. madagascariensis', 'Travellers Palm', 'The enormous paddle-shaped leaves are borne on long petioles, in a distinctive fan shape aligned in a single plane (distichous). The large white flowers are structurally similar to those of its relatives, the bird-of-paradise flowers Strelitzia reginae and Strelitzia nicolai, but are generally considered less attractive, with a green bract.[8] These flowers, upon being pollinated, produce brilliant blue seeds. In tropical and subtropical regions, the plant is widely cultivated for its distinctive habit and foliage. ', 'full-sun','daily','biannually', 'https://upload.wikimedia.org/wikipedia/commons/thumb/a/a4/Ravenala%2C_travellers_palms%2C_on_Maui.jpg/1024px-Ravenala%2C_travellers_palms%2C_on_Maui.jpg');

INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, sun, water, fertilizer, img_url) VALUES('Plantae', 'Poales', 'Poaceae', 'Poaceae', 'Cynodon', 'Cynodon dactylon', 'Bermuda Grass', 'Cynodon dactylon, commonly known as Bermuda grass, is a grass found worldwide. It is native to Europe, Africa, Australia and much of Asia. It has been introduced to the Americas. Contrary to its common name, it is not native to Bermuda and is in fact an abundant invasive species there. In Bermuda it has been known as "crab grass" (also a name for Digitaria sanguinalis). Other names are Dhoob, dūrvā grass, ethana grass, dubo, dog grass, dog''s tooth grass, Bahama grass, crab grass, devil''s grass, couch grass, Indian doab, arugampul, grama, wiregrass and scutch grass.', 'full-sun','daily','biannually', 'https://www.thespruce.com/thmb/o8JqOHMESycqIX2V7bmzeVD1st0=/750x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/GettyImages-1257704064-bc64303b209d440da1660384b6cb60a8.jpg');
INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, sun, water, fertilizer, img_url) VALUES ('Plantae','Poales', 'Poaceae','Pooideae','Festuca','Festuca arundinacea', 'Turf-type Tall Fescue', 'Festuca arundinacea (syn., Schedonorus arundinaceus and Lolium arundinaceum) is a species of grass commonly known as tall fescue. It is a cool-season perennial C3 species of bunchgrass native to Europe. It is an important forage grass throughout Europe, and many cultivars have been used in agriculture. It is also an ornamental grass in gardens, and a phytoremediation plant.','full-sun','weekly','annually','https://i0.wp.com/twincityseed.com/wp-content/uploads/Resilience-TTTF-Dearstone-scaled.jpg?fit=1200%2C1143&ssl=1');
INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, sun, water, fertilizer, img_url) VALUES ('Plantae','Polypodiales', 'Nephrolepidaceae','Nephrolepis','Nephrolepis','Nephrolepis exaltata', 'Boston Fern', 'Nephrolepis exaltata, known as the sword fern or Boston fern, is a species of fern in the family Lomariopsidaceae (sometimes treated in the families Davalliaceae or Oleandraceae, or in its own family, Nephrolepidaceae). It is native to the Americas. This evergreen plant can reach as high as 40–90 centimetres (16–35 in), and in extreme cases up to 1.5 metres (4 ft 11 in). It is also known as the Boston sword fern, wild Boston fern, Boston Blue Bell Fern, tuber ladder fern, or fishbone fern.','shade','bi-weekly','annually','https://upload.wikimedia.org/wikipedia/commons/3/30/Boston_Fern_%282873392811%29.png');
INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, sun, water, fertilizer, img_url) VALUES ('Plantae','Lamiales', 'Lamiaceae','Lamiaceae','Salvia','Salvia rosmarinus', 'Rosemary', 'Salvia rosmarinus, commonly known as rosemary, is a shrub with fragrant, evergreen, needle-like leaves and white, pink, purple, or blue flowers, native to the Mediterranean region. Until 2017, it was known by the scientific name Rosmarinus officinalis (/ˌrɒsməˈraɪnəs əˌfɪsɪˈneɪlɪs/), now a synonym. It is a member of the sage family Lamiaceae, which includes many other medicinal and culinary herbs. The name "rosemary" derives from Latin ros marinus (lit. ''dew of the sea'').','full-sun','semi-weekly','annually','https://encrypted-tbn3.gstatic.com/licensed-image?q=tbn:ANd9GcQ1B_QCcuzG0Md1PJt0ssfug9VTlM-jDoGYz6KYF1TJYY_lnQ-Ebvof-BwNQd_Xh1YmSUJYQqEgbGFw7yw');
INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, sun, water, fertilizer, img_url) VALUES ('Plantae','Lamiales', 'Lamiaceae','Lamiaceae','Salvia','Salvia officinalis', 'Sage', 'Salvia officinalis, the common sage or sage, is a perennial, evergreen subshrub, with woody stems, grayish leaves, and blue to purplish flowers. It is a member of the mint family Lamiaceae and native to the Mediterranean region, though it has been naturalized in many places throughout the world. It has a long history of medicinal and culinary use, and in modern times it has been used as an ornamental garden plant. The common name "sage" is also used for closely related species and cultivars.','full-sun','semi-weekly','annually','https://cdn.britannica.com/10/198810-050-A2364A2D/sage-plant.jpg');
INSERT INTO plants (kingdom, [order], family, subfamily, genus, species, common_name, description, sun, water, fertilizer, img_url) VALUES ('Plantae','Lamiales', 'Lamiaceae','Lamiaceae','Origanum','Origanum vulgare', 'Oregano', 'Oregano is a species of flowering plant in the mint family Lamiaceae. It was native to the Mediterranean region, but widely naturalised elsewhere in the temperate Northern Hemisphere. Oregano is a woody perennial plant, growing 20–80 cm (8–31 in) tall, with opposite leaves 1–4 cm (1⁄2–1+1⁄2 in) long. The flowers which can be white, pink or light purple, are 3–4 mm (1⁄8–3⁄16 in) long, and produced in erect spikes in summer. It is sometimes called wild marjoram, and its close relative, O. majorana, is known as sweet marjoram. Both are widely used as culinary herbs, especially in Turkish, Greek, Spanish, Italian, Hispanic, and French cuisine. Oregano is also an ornamental plant, with numerous cultivars bred for varying leaf colour, flower colour and habit.','full-sun','bi-weekly','annually','https://encrypted-tbn2.gstatic.com/licensed-image?q=tbn:ANd9GcTXdtU-avb2v_kMvyO1RUeVQscDRjAJEFJWWsdqpK_V8os4ClLFX0KQ7Tq4XdpqFZF4C4n-nd7fNaB3IWQ');

INSERT INTO events (user_id , address1 , city, state, zip, website, name, short_description, long_description, is_virtual, start_time, end_time) VALUES (2, '123 Main St',  'Columbus', 'OH', '12345', 'www.website.com', 'Monthly Franklin Park Meet up', 'Visit the botanical gardens at Franklin Park', 'Meet up with other Columbus gardeners for the sights and scents of the Franklin Park Gardens!  Always free on the third Saturday of the month.', 0, '2023-08-19 09:30:00', '2023-08-19 13:45:00')
INSERT INTO events (user_id , website, name, short_description, long_description, is_virtual, start_time, end_time) VALUES (2, 'www.zoom.com/meeting123456', 'Green Morning America', 'Weekly show for gardener Q&A', 'Join our hosts and bring your questions for an hour of live talk and viewer Q&A on Zoom! Every Friday!', 1, '2023-08-18 12:00:00', '2023-08-19 13:00:00')
--past
INSERT INTO events (user_id , website, name, short_description, long_description, is_virtual, start_time, end_time) VALUES (2, 'www.pasteventtest.com/meeting123456', 'Green Morning America', 'Weekly show for gardener Q&A', 'Join our hosts and bring your questions for an hour of live talk and viewer Q&A on Zoom! Every Friday!', 1,  '2023-08-09 10:00:00', '2023-08-10 11:00:00')

INSERT INTO sellers (seller_name ,seller_type ,address1 ,address2 ,city ,state ,zip ,website) VALUES ('Oakland Nursery Dublin','Retailer','4261 West Dublin-Granville Road','','Dublin','OH','43017','https://www.oaklandnursery.com/page/garden-centers/dublin');
INSERT INTO sellers (seller_name ,seller_type ,address1 ,address2 ,city ,state ,zip ,website) VALUES ('Oakland Nursery Columbus','Retailer','1156 Oakland Park Avenue','','Columbus','OH','43224-3317','https://www.oaklandnursery.com/page/garden-centers/columbus');
INSERT INTO sellers (seller_name ,seller_type ,address1 ,address2 ,city ,state ,zip ,website) VALUES ('Nature Hills','Online Seller','2336 S 156th Circle','','Omaha','NE','68130','https://www.naturehills.com/');
INSERT INTO sellers (seller_name ,seller_type ,address1 ,address2 ,city ,state ,zip ,website) VALUES ('Columbus Turf Nursery','Online Seller','14337 Rt 23','','Ashville','OH','43103','https://www.columbus-turf.com/');
--populate test inventory records
INSERT INTO sellers_products (seller_id, plant_id) VALUES (1,1);
INSERT INTO sellers_products (seller_id, plant_id) VALUES (1,2);
INSERT INTO sellers_products (seller_id, plant_id) VALUES (1,3);
INSERT INTO sellers_products (seller_id, plant_id) VALUES (1,4);
INSERT INTO sellers_products (seller_id, plant_id) VALUES (2,2);
INSERT INTO sellers_products (seller_id, plant_id) VALUES (2,3);
INSERT INTO sellers_products (seller_id, plant_id) VALUES (3,1);
INSERT INTO sellers_products (seller_id, plant_id) VALUES (3,4);
INSERT INTO sellers_products (seller_id, plant_id) VALUES (4,1);
INSERT INTO sellers_products (seller_id, plant_id) VALUES (4,8);
INSERT INTO sellers_products (seller_id, plant_id) VALUES (4,9);

INSERT INTO virtual_garden (user_id, plant_id) VALUES (1,1);
INSERT INTO virtual_garden (user_id, plant_id) VALUES (1,2);
INSERT INTO virtual_garden (user_id, plant_id) VALUES (2,3);
INSERT INTO virtual_garden (user_id, plant_id) VALUES (2,4);
INSERT INTO virtual_garden (user_id, plant_id) VALUES (2,5);
INSERT INTO virtual_garden (user_id, plant_id) VALUES (3,1);
INSERT INTO virtual_garden (user_id, plant_id) VALUES (3,11);
INSERT INTO virtual_garden (user_id, plant_id) VALUES (3,13);

INSERT INTO ratings (user_id, seller_id, title, rating, review) VALUES (1, 1, 'Rating 1', 5, 'This is a review')
INSERT INTO ratings (user_id, seller_id, title, rating, review) VALUES (2, 2, 'Rating 2', 5, 'This is a review also')
INSERT INTO ratings (user_id, seller_id, title, rating, review) VALUES (2, 3, 'Rating 3', 5, 'This is a review also also')
INSERT INTO ratings (user_id, seller_id, title, rating, review) VALUES (1, 4, 'Rating 4', 5, 'This is a review also also also')
INSERT INTO ratings (user_id, seller_id, title, rating, review) VALUES (2, 1, 'Rating 5', 5, 'Good location, I love to stop here every weekend and see what''s new!')
INSERT INTO ratings (user_id, seller_id, title, rating, review) VALUES (3, 1, 'Friendly', 5, 'Nice people and great selection! Will buy here again')
INSERT INTO ratings (user_id, seller_id, title, rating, review) VALUES (3, 3, 'Cacti too spiky', 2, 'I purchased several cacti here for my grandma and they were too thorny!')

INSERT INTO communications (user_id, type, title,  start_time, end_time) 
	VALUES (2, 'poll', 'Which is your favorite hanging plant?', '2023-08-12 10:00:00', '2023-08-20 11:00:00');
INSERT INTO poll_options (poll_id, text) VALUES (1, 'Pothos');
INSERT INTO poll_options (poll_id, text) VALUES (1, 'String of Peals');
INSERT INTO poll_options (poll_id, text) VALUES (1, 'Spider Plant');
INSERT INTO poll_options (poll_id, text) VALUES (1, 'Philodendron');

INSERT INTO communications (user_id, type, title, start_time, end_time) 
	VALUES (2, 'competition', 'Enter your tallest plant height in order to win!', '2023-08-22 09:30:00', '2023-08-29 09:30:00');
INSERT INTO communications (user_id, type, title, start_time, end_time) 
	VALUES (2, 'challenge', 'Water your plants on time for one week to win a badge!', '2023-08-22 09:30:00', '2023-08-29 09:30:00');

INSERT INTO communications (user_id, type, title, start_time, end_time) 
	VALUES (2, 'poll', 'How many plants do you have in your home?', '2023-08-15 10:00:00', '2023-08-22 11:00:00');
INSERT INTO poll_options (poll_id, text) VALUES (2, '0-8');
INSERT INTO poll_options (poll_id, text) VALUES (2, '8-15');
INSERT INTO poll_options (poll_id, text) VALUES (2, '15-25');
INSERT INTO poll_options (poll_id, text) VALUES (2, '25+');
		   
INSERT INTO communications (user_id, type, title, start_time, end_time) 
	VALUES (2, 'poll', 'What was your first houseplant?', '2023-08-20 09:30:00', '2023-08-27 09:30:00');
INSERT INTO poll_options (poll_id, text) VALUES (3, 'Cactus');
INSERT INTO poll_options (poll_id, text) VALUES (3, 'Pothos');
INSERT INTO poll_options (poll_id, text) VALUES (3, 'Monstera');
INSERT INTO poll_options (poll_id, text) VALUES (3, 'Succulent');

INSERT INTO communications (user_id, type, title, start_time, end_time) 
	VALUES (2, 'poll', 'Do you prefer indoor plants or outdoor gardening?', '2023-08-16 09:30:00', '2023-08-23 09:30:00');
INSERT INTO poll_options (poll_id, text) VALUES (4, 'Indoor');
INSERT INTO poll_options (poll_id, text) VALUES (4, 'Outdoor');
INSERT INTO poll_options (poll_id, text) VALUES (4, 'Standard programmer answer: it depends.');
INSERT INTO poll_options (poll_id, text) VALUES (4, 'Little of both!');

INSERT INTO communications (user_id, type, title, start_time, end_time) 
	VALUES (2, 'poll', 'What is the best houseplant for beginners?', '2023-08-22 09:30:00', '2023-08-29 09:30:00');
INSERT INTO poll_options (poll_id, text) VALUES (5, 'Succulent');
INSERT INTO poll_options (poll_id, text) VALUES (5, 'Palm');
INSERT INTO poll_options (poll_id, text) VALUES (5, 'Snake Plant');
INSERT INTO poll_options (poll_id, text) VALUES (5, 'Pothos');


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

