create database dbTintas;

drop database dbTintas;

use dbTintas;

create table Tintas(

	Id_Tinta int auto_increment not null primary key,
    Cor varchar(50) not null,
    Marca varchar(50) not null,
    Preco decimal(10,2) not null

);

insert into Tintas (Cor,Marca,Preco) values ("Azul", "Suvinil", 69.99) , 
("Verde", "Lukscolor" , 79.99),
("Vermelho Sangue", "Impertotal", 199.99);

delete from Tintas where Id_Tinta = 2;

select * from Tintas;