CREATE DATABASE IF NOT EXISTS 'miBBDD';

use miBBDD;

create table if no exists 'users'
(
	'id' 		int(10) PRIMARY key Auto_increment,
	'name' 		varchar (255) not null,
	'lastname' 	varchar (255) not null,
);

insert into users(id, name,lastname) values (1,"nombre1","apellido1");
insert into users(id, name,lastname) values (1,"nombre2","apellido2");
insert into users(id, name,lastname) values (1,"nombre3","apellido3");