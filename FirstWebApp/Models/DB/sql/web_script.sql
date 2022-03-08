create database web_4b_g1 collate utf8mb4_general_ci;

use web_4b_g1;

create table users( 
	User_id int unsigned not null auto_increment,
	Username varchar(100) not null,
	Password varchar(300) not null,
	Email varchar(150) null,
	Birthdate date null,
	Gender int null,

constraint user_id_PK primary key(User_id)
);

insert into users values(null, "Kristof", sha2("Hallo123", 512), "k@gmail.com", "2004-05-21", 0);
insert into users values(null, "Jonny", sha2("Hallo123", 512), "j@gmail.com", "2004-06-01", 0);
insert into users values(null, "Noel", sha2("123", 512), "n@gmail.com", "2004-10-20", 0);

select * from users;